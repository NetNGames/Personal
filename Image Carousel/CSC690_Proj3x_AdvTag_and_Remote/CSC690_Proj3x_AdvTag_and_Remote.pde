/************************************************* 
 
 File: CSC690_Proj3x
 By: Elbert Dang
 Date: 10/25/2014
 
 Usage: Run using Processing 2.x with Minim, ControlP5, and OSXP5 libraries
         -Load images into the data/img folder
 System: JVM 
 
 Description: Mode 0: Display images in carousel fashion
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press UP or click image to bring it up in Mode 1
                 -Press < or > to shift left or right to the next group of images
              Mode 1: Display images full screen
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press DOWN or click image to go back to Mode 0
                 -Type text into textbox to add image tags
                  --Press Enter while in textbox to add tag
                  --Press SaveTags button to save all edited tags to file
                 -Press TagBox to create rectangular tag
                  --Press down on mouse, draw outline, release, and enter tag in popup menu.
                 
1.5 update - Add animated transitions and mouseclick to open
2.5 update - Add sounds for screen transitions
           - Add tags in Fullscreen mode
3x  update - Add drawing of custom, rectangular tag
           - Add remote control ability from 400 x 300 control
           --Remote Mouse and keyboard input should work for everything except tagging
           
 *************************************************/

String[] list;
int selectedImage = 0; // Initial image to be displayed is the first
int leftmost = 0;
boolean fullscreenMode = false; //Starts in thumbnail view
float thumbHeight;
float thumbWidth;
float thumbRatio;
float fullWidth = 800;
float windowWidth = fullWidth/5; //Makes room for 5 images = 160
float fullHeight = 600;
float windowHeight = fullHeight/4; //Tall, skinny images gets scaled down to 150
float border = 50;
float toAnimate = 0;
int[] currentDisplay = {0, 1, 2, 3, 4};
boolean shiftingRight = true;

// Declaring an array of images.
PImage[] imageList;

//Loading audio
import ddf.minim.*;
Minim minim;
AudioPlayer longSound;
AudioPlayer shortSound;

//Textfield for tags
import controlP5.*;
ControlP5 cp5;
Textfield tagInputField;
Button tagSaveButton;
String[] tagList; //List of all tags
String tagInput=""; //Input from textfield

//For advanced tagging
boolean isTagging=false;
String[] tagBoxList;
Textfield tagBoxInputField;
Button tagBoxButton;
String tagBoxInput="";
String tempTag;

//Remote control receiver from OSCReceiver
import oscP5.*;
import netP5.*;
OscP5 oscP5;

void setup() {
  size((int)fullWidth, (int)fullHeight);
  cp5 = new ControlP5(this);
  // Loading the images into the array
  //From http://processing.org/discourse/beta/num_1253083238.html and http://processing.org/discourse/beta/num_1247100666.html
  File dir = new File(sketchPath +"/data/img/");
  list = dir.list();
  //Make imagelist the capable of holding all files in data
  imageList = new PImage[list.length];

  if (list == null) {
    println("Folder does not exist, cannot be accessed, or is empty.");
  } else {
    int j=0;
    for (int i=0; i < list.length; i ++ ) { //Loops through data list
      if (list[i].endsWith("png")||  //Loads into image array if it's a picture
          list[i].endsWith("jpg")||
          list[i].endsWith("gif")||
          list[i].endsWith("bmp")) {
        imageList[j] = loadImage( "img/"+list[i] );
        j++;
      }
    }
  }

  //Load sounds
  minim = new Minim(this);
  longSound = minim.loadFile("aud/long.wav");
  shortSound = minim.loadFile("aud/short.mp3");

  //-----Load ControlP5 elements----\\
  //Textfield for adding tags
  tagInputField = cp5.addTextfield("tagInput")
    .setPosition((width / 2)-60, (border/4))
      .setSize(100, 20)
        .setVisible(false)
          .setCaptionLabel("Press Return to add tag")
            .setFocus(true);
  //Button for saving tags to file
  tagSaveButton = cp5.addButton("saveButton")
    .setPosition((width / 2)+50, (border/4))
      .setSize(70, 20)
        .setVisible(false)
          .setCaptionLabel("Save Tags");
  //Popup input field for box tags
  tagBoxInputField = cp5.addTextfield("tagBoxInput")
      .setSize(100, 20)
        .setVisible(false)
          .setCaptionLabel("Press Return to add tag");;
  //Button activate tagBox mode
  tagBoxButton = cp5.addButton("boxButton")
    .setPosition((width / 2)-120, (border/4))
      .setSize(50, 20)
        .setVisible(false)
          .setCaptionLabel("Tag Box");
            //.Toggle
  loadTags();
  
  /* start oscP5, listening for incoming messages at port 12000 */
  oscP5 = new OscP5(this, 12000);
}

void draw() {
  background(#6A0E0E); //maroon background
  
  if (fullscreenMode) {
    displayFullscreen();
  } else {
    tagInputField.setVisible(false);
    tagSaveButton.setVisible(false);
    tagBoxButton.setVisible(false);
    thumbRatio=windowWidth/windowHeight;
    displayThumbnails();
  }
  
  //Display curser on top
  stroke(#D2E327); //Gold border
  strokeWeight(5);
  fill(100); //Grey inside
  ellipse(mouseX, mouseY, 10, 10);
}

void displayFullscreen() {
  thumbRatio=(fullWidth-(border*2))/(fullHeight-(border*2));
  int offset;//offset of leftmost of current images
  if (toAnimate>0) { //if shifting right
    offset = -1;
  } else if (toAnimate<0) { //if shifting left
    offset = 1;
  } else {
    offset = 0;
  }
  //Render Selected image;
  resizeImage(imageList[selectedImage]);
  imageMode(CENTER);
  image(imageList[selectedImage], fullWidth*(toAnimate/100)+(fullWidth/2), fullHeight/2, thumbWidth, thumbHeight); 
  rectMode(CENTER);
  stroke(#5755BC);
  strokeWeight(border);
  //Transparent rectangle
  noFill();
  //http://processing.org/reference/rect_.html
  rect((fullWidth*(toAnimate/100))+(fullWidth/2), fullHeight/2, thumbWidth+border, thumbHeight+border);

  //Render next image    
  int nextImg = selectedImage+offset;
  if (nextImg > imageList.length-1) {
    nextImg = 0; //Loops to beginning if reached the end
  } else if (nextImg < 0) {
    nextImg = imageList.length-1; //Loops to end if reached the beginning
  }
  resizeImage(imageList[nextImg]);
  imageMode(CENTER);
  image(imageList[nextImg], (fullWidth*(offset+(toAnimate/100)))+(fullWidth/2), fullHeight/2, thumbWidth, thumbHeight); 
  rectMode(CENTER);
  stroke(#5755BC); //Light blue border
  strokeWeight(border);
  //Transparent rectangle
  noFill();
  //http://processing.org/reference/rect_.html
  rect((fullWidth*(offset+(toAnimate/100)))+(fullWidth/2), fullHeight/2, thumbWidth+border, thumbHeight+border);

  if (toAnimate>0) {
    toAnimate-=5;
    tagBoxButton.setVisible(false);
  } else if (toAnimate<0) {
    toAnimate+=5;
    tagBoxButton.setVisible(false);
  } else {
    //last so it appears on top of image and border
    //Only appears when images are not moving
    tagBoxButton.setVisible(true);
    displayTags();
    displayTagBoxes();
  }
}
void displayThumbnails() {  
  int[] display = new int[5];
  // Displaying images
  imageMode(CENTER);
  if (leftmost >=0 && leftmost <= imageList.length-5) { //Normal display from 0 to end-4
    display[0] = leftmost;
    display[1] = leftmost+1;
    display[2] = leftmost+2;
    display[3] = leftmost+3;
    display[4] = leftmost+4;
    drawThumbnails(display);
  } else if (leftmost==imageList.length-4) {
    display[0] = leftmost;
    display[1] = leftmost+1;
    display[2] = leftmost+2;
    display[3] = leftmost+3;
    display[4] = 0;
    drawThumbnails(display);
  } else if (leftmost==imageList.length-3) {
    display[0] = leftmost;
    display[1] = leftmost+1;
    display[2] = leftmost+2;
    display[3] = 0;
    display[4] = 1;
    drawThumbnails(display);
  } else if (leftmost==imageList.length-2) {
    display[0] = leftmost;
    display[1] = leftmost+1;
    display[2] = 0;
    display[3] = 1;
    display[4] = 2;
    drawThumbnails(display);
  } else if (leftmost==imageList.length-1||leftmost==-1) {
    leftmost=imageList.length-1;
    display[0] = leftmost;
    display[1] = 0;
    display[2] = 1;
    display[3] = 2;
    display[4] = 3;
    drawThumbnails(display);
  }
  if (toAnimate>0) {
    toAnimate-=10;
  } else if (toAnimate<0) {
    toAnimate+=10;
  } else { //When toAnimate==0, animation is complete
    currentDisplay = display;//Set current display to new display after animation finishes
  }
}

void drawThumbnails(int[] images) {
  int offset;//offset of leftmost of current images
  if (shiftingRight) { //if shifting right
    offset = -5;
  } else { //if shifting left
    offset=5;
  }
  for (int i=0; i<5; i++) {
    resizeImage(imageList[currentDisplay[i]]); 
    image(imageList[currentDisplay[i]], //Displays previous images
    (windowWidth*(offset+(toAnimate/100)))+(windowWidth/2), 
    fullHeight/2, //Vertical center
    thumbWidth, 
    thumbHeight); 
    if (currentDisplay[i]==selectedImage) { //Draws border around selected image
      selectBorder(imageList[currentDisplay[i]], i);
    }
    offset++;
    resizeImage(imageList[images[i]]); 
    image(imageList[images[i]], //Displays new images
    (windowWidth*(i+(toAnimate/100)))+(windowWidth/2), //starts from 5 from left and moves into position over time
    fullHeight/2, //Vertical center
    thumbWidth, 
    thumbHeight); 
    if (images[i]==selectedImage) { //Draws border around selected image
      selectBorder(imageList[images[i]], i);
    }
  }
}
//Draws border around currently selected image
void selectBorder(PImage image, int offset) {
  rectMode(CENTER); 
  stroke(#5755BC); 
  strokeWeight(5); 
  //Transparent rectangle
  noFill(); 
  //http://processing.org/reference/rect_.html
  rect((windowWidth*(offset+(toAnimate/100)))+(windowWidth/2), fullHeight/2, windowWidth, windowHeight);
}

void shiftLeft() { 
  longSound.rewind();
  longSound.play();
  shiftingRight = false;
  toAnimate = -500; 
  leftmost = leftmost-5; 
  if (leftmost < 0) {
    leftmost = imageList.length+leftmost;
  }
}
void shiftRight() {
  longSound.rewind();
  longSound.play();
  shiftingRight = true;
  toAnimate = 500; 
  leftmost = leftmost+5; 
  if (leftmost>imageList.length-1) { //If left+5 is greater than the index of the last image
    leftmost = leftmost-imageList.length; //Find difference and set new leftmost
  }
}
//Resizes image to appropriate size
void resizeImage(PImage img) {
  float imgHeight = img.height; 
  float imgWidth = img.width; 
  float imgRatio = imgWidth/imgHeight; 
  if (fullscreenMode) { //If in fullscreen
    if (thumbRatio > imgRatio) { //If thumbnail width is larger than img height
      thumbHeight = fullHeight-(border*2); 
      thumbWidth = (fullHeight-(border*2)) * imgRatio;
    } else if (thumbRatio < imgRatio) {  //If thumbnail width is larger than img height
      thumbHeight = (fullWidth-(border*2)) * (1/imgRatio); 
      thumbWidth = (fullWidth-(border*2));
    } else {//If thumbnail ratio was equal to img
      thumbHeight = fullHeight-(border*2); 
      thumbWidth = fullWidth-(border*2);
    }
  } else { //not in fullscreen
    if (thumbRatio > imgRatio) { //If thumbnail width is larger than img height
      thumbHeight = windowHeight-(border/2); 
      thumbWidth = (windowHeight-(border/2)) * imgRatio;
    } else if (thumbRatio < imgRatio) {  //If thumbnail width is smaller than img height
      thumbHeight = (windowWidth-(border/2)) * (1/imgRatio); 
      thumbWidth = windowWidth-(border/2);
    } else {//If thumbnail ratio was equal to img's
      thumbHeight = windowWidth-(border/2); 
      thumbWidth = windowWidth-(border/2);
    }
  }
}

//----------------------------------I/O Events-------------------------\\
void keyPressed() {
  if (key == CODED) {    
    if (keyCode == LEFT) {
      selectedImage--; 
      if (fullscreenMode) {
        shortSound.rewind();
        shortSound.play();

        tagInputField.setVisible(false);
        tagSaveButton.setVisible(false);        
        tagSaveButton.setCaptionLabel("Save Tags");
        toAnimate = -100; 
        if (0 > selectedImage) {
          selectedImage=imageList.length-1;
        }
      } else { //Not in fullscreen
        if (selectedImage==leftmost-1) { //If going left of leftmost image
          shiftLeft(); //Shift screen to left
          selectedImage = leftmost + 4; //Set selected image to rightmost
        }
        if (selectedImage==-1) { //If going negative
          selectedImage = imageList.length-1; //set to last one
        } else if (selectedImage>imageList.length-1) {
          selectedImage = leftmost-imageList.length+4;
        }
        displayThumbnails();
      }
    } else if (keyCode == RIGHT) {
      selectedImage++; 
      if (fullscreenMode) {
        shortSound.rewind();
        shortSound.play();

        tagInputField.setVisible(false);
        tagSaveButton.setVisible(false);
        tagSaveButton.setCaptionLabel("Save Tags");
        toAnimate = 100; 
        if (selectedImage>imageList.length-1) {
          selectedImage=0;
        }
      } else { //Not in fullscreen
        if (selectedImage>leftmost+4 //If going right of rightmost image
        ||(selectedImage==(leftmost-imageList.length+5))) { //If array had repeated
          shiftRight(); //Shift screen to left
          selectedImage = leftmost; //Set selected image to leftmost
        }
        if (selectedImage > imageList.length-1) {//if going off last
          selectedImage = 0;
        }
        displayThumbnails();
      }
    } else if ((keyCode == UP) && !fullscreenMode) {//Does nothing if in fullscreenMode
      shortSound.rewind();
      shortSound.play();
      fullscreenMode = true;
      toAnimate=0;
    } else if ((keyCode == DOWN)  && fullscreenMode) {//Does nothing if not in fullscreenMode{
      shortSound.rewind();
      shortSound.play();
      tagInputField.setVisible(false);
      tagSaveButton.setVisible(false);
      tagSaveButton.setCaptionLabel("Save Tags");
      fullscreenMode = false; //Centers selected image
      if (selectedImage==0) { 
        leftmost = imageList.length-2;
      } else if (selectedImage==1) {
        leftmost = imageList.length-1;
      } else {
        leftmost = selectedImage-2;
      }
    }
  } else if ((key == '>') && !fullscreenMode) {//Does nothing if in fullscreenMode
    shiftRight();
    selectedImage=leftmost; 
    displayThumbnails();
  } else if ((key == '<') && !fullscreenMode) {//Does nothing if in fullscreenMode
    shiftLeft();
    selectedImage=leftmost; 
    displayThumbnails();
  }
} 

void mouseClicked() {
  if (!fullscreenMode && mouseButton == LEFT) { //Left mouse click on thumbnail
    //println("leftclick");
    boolean thumbSelect = false; 
    //println("(" + mouseX+", " + mouseY +")");
    int offset; 
    for (offset = 0; offset<5; offset++) {
      if (mouseX > (windowWidth*offset) && //from left of thumbnail
          mouseX < ((windowWidth*offset) + windowWidth) && //to right of thumbnail
          mouseY < ((fullHeight/2) + windowHeight/2) && //from vertical center up to top of thumbnail window
          mouseY > ((fullHeight/2) - windowHeight/2)) //from vertical center down to bottom of thumbnail window
      {
        thumbSelect=true; 
        selectedImage = leftmost + offset; 
        if (selectedImage>imageList.length-1) {
          selectedImage=selectedImage-imageList.length;
        }
        break;
      }
    }
    if (thumbSelect) {
      shortSound.rewind();
      shortSound.play();
      fullscreenMode = true;
    }
  }//Removed ability to click back to thumbnail view
}

//----------------------------------Tagging-------------------------\\
int a=-50,b=-50,c,d;
void mousePressed() {
  if(isTagging){
    tagBoxInputField.setVisible(false);
    a=mouseX;
    b=mouseY;
  }  
}

void mouseDragged() {
  if(isTagging){
    tagBoxInputField.setVisible(false);
    c=mouseX-a;
    d=mouseY-b;
  }
}
void mouseReleased(){
  if(isTagging){
    if(a!=0 && b!=0 && c!=0 && d!=0){ //If values had changed
      tempTag = "("+a+","+b+","+c+","+d+",";
    }
    tagBoxInputField.setPosition(a+c/2-50, b+d/2);
    tagBoxInputField.setVisible(true);
    tagBoxInputField.setFocus(true);
  }  
}

void loadTags() {
  BufferedReader reader;
  //Creates list of tags corresponding to imageList
  tagList = new String[imageList.length];
  tagBoxList = new String[imageList.length];
  String currentLine = "";
  
  for (int i = 0; i<imageList.length; i++) {
    //Checks to see if file exists
    File f = new File(sketchPath + "/data/tag/" + list[i]+"_tag.txt");
    if (f.exists())
    {
      try {
        //If it exists, readline from the file 
        reader = createReader(sketchPath + "/data/tag/" + list[i]+"_tag.txt");
        while((currentLine=reader.readLine())!=null){
          if(currentLine.charAt(0)=='#'){ //If it's a standard tag
            if (tagList[i]==null){ //If list is empty
              tagList[i]=currentLine;
            } else{
              tagList[i]+=" "+ currentLine;
            }            
          }else if(currentLine.charAt(0)=='('){//If it's a box tag
            if (tagBoxList[i]==null){ //If list is empty
              tagBoxList[i]=currentLine;
            } else{
              tagBoxList[i]+=currentLine;
            }
          }
        }
       if(tagList[i]==null){ //If no standard tags
         tagList[i]="No tags";
       }
      } 
      catch (IOException e) {
        e.printStackTrace();
      }
    } else { //Adds "No tags" if tag file with image name wasn't found
      tagList[i]="No tags";
    }
  }
}

void displayTags() {
  if(isTagging){
    rectMode(CORNER);
    noFill();
    strokeWeight(5);
    stroke(#FF0000);
    rect(a, b, c, d);
    tagInputField.setVisible(false);
    tagSaveButton.setVisible(false);
  } else{
    tagInputField.setVisible(true);
    tagInputField.setFocus(true);
    tagSaveButton.setVisible(true);
    tagBoxButton.setVisible(true);
  }
  
  textSize(25);
  if(tagList[selectedImage]!=null){
    
  textAlign(CENTER);
    //Black Outline
    fill(#000000);
    text(tagList[selectedImage], (fullWidth/2)-1, (fullHeight)-(border/4)-1, fullWidth, border);
    text(tagList[selectedImage], (fullWidth/2)+1, (fullHeight)-(border/4)+1, fullWidth, border);

    //White text
    fill(#FFFFFF);
    text(tagList[selectedImage], (fullWidth/2), (fullHeight)-(border/4), fullWidth, border);
  }
}

void displayTagBoxes(){
  if(isTagging){
    tagBoxButton.setCaptionLabel("Tagging...");
  }else{
    tagBoxButton.setCaptionLabel("Tag Box");
  }
  if(tagBoxList[selectedImage]!=null){
    //From http://stackoverflow.com/a/5993823
    String[] parseTagBox = tagBoxList[selectedImage].split(",|\\(|\\)");
    //println("length= " + parseTagBox.length);
    if (parseTagBox.length%6==0){//If it has full tag info (5 strings)
      for(int i=1;i<parseTagBox.length;i+=6){ //Since it creates a null after '(', go up by 6 instead of 5
        int x=Integer.parseInt(parseTagBox[i]);
        int y=Integer.parseInt(parseTagBox[i+1]);
        int w=Integer.parseInt(parseTagBox[i+2]);
        int h=Integer.parseInt(parseTagBox[i+3]);
      
        rectMode(CORNER);
        noFill();
        strokeWeight(5);
        stroke(#FF0000);
        rect(x,y,w,h);
        if ((mouseX > x && mouseX < x+w && mouseY > y && mouseY < y+h) || //If rectangle was drawn upper left to lower right
            (mouseX > x+w && mouseX < x && mouseY > y && mouseY < y+h) || //If rectangle was drawn upper right to lower left
            (mouseX > x && mouseX < x+w && mouseY > y+h && mouseY < y) || //If rectangle was drawn lower left to upper right
            (mouseX > x+w && mouseX < x && mouseY > y+h && mouseY < y)) //If rectangle was drawn lower right to upper left
        {
          textSize(25);
          //Black Outline
          fill(#000000);
          text(parseTagBox[i+4], x+(w/2)-(parseTagBox[i+4].length()/2)+1, y+(h/2)+1);
          text(parseTagBox[i+4], x+(w/2)-(parseTagBox[i+4].length()/2)-1, y+(h/2)-1);
  
          //White Outline
          fill(#FFFFFF);
          text(parseTagBox[i+4], x+(w/2)-(parseTagBox[i+4].length()/2), y+(h/2));
        }
      }
    }
  }
}

void saveTags() {
  PrintWriter output;  
  for (int i = 0; i<imageList.length; i++) {
    String writeTag="";
    if (!tagList[i].equals("No tags") || tagBoxList[i]!=null) { //Don't create tag file if no new tags
      output = createWriter(sketchPath + "/data/tag/" + list[i]+"_tag.txt");//create tag file with originalName_tag.txt extension 
      if (!tagList[i].equals("No tags")){
        writeTag+=tagList[i]+"\n";
        //println("standard tags: " + writeTag);
      }
      if (tagBoxList[i]!=null){
        writeTag+=tagBoxList[i];
        //println("box tags: " + writeTag);
      }
      //println("all tags: " + writeTag);
      output.print(writeTag); //Overwrites tag file if it existed
      tagSaveButton.setCaptionLabel("Tags saved OK!");
      output.flush(); // Writes the remaining data to the file
      output.close(); // Finishes the file
    }
  }
}

//----------------------------Textfield and Button Controls-------------------------\\
//Listens for control input
void controlEvent(ControlEvent theEvent) {
  //From http://www.kasperkamperman.com/blog/processing-code/controlp5-library-example1/comment-page-1/
  //----Standard Tags---\\
  if (theEvent.controller().name()=="tagInput") { //Listens for input from tagInput textfield
    tagSaveButton.setCaptionLabel("Save Tags");  //Resets SaveButton label if needed
    if (tagList[selectedImage].equals("No tags")) {
      tagList[selectedImage]="#"+tagInput; //Overwrites tag if no previous tags
    } else {
      tagList[selectedImage]+=" #"+tagInput; //Adds to tag if previous tags detected
    }
  } else if (theEvent.controller().name()=="saveButton") {//Checks to see if saveButton was pressed
    saveTags();
    
  //----Box Tags---\\
  } else if (theEvent.controller().name()=="tagBoxInput") { //Listens for input from tagInput textfield
    tagBoxInputField.setVisible(false); //Removes popup
    tagInputField.setVisible(true);
    tagSaveButton.setVisible(true);
    tempTag+=tagBoxInput+")";
    if(tagBoxList[selectedImage]==null){
      tagBoxList[selectedImage]=tempTag;
    }else{
      tagBoxList[selectedImage]+=tempTag;
    }
    isTagging=false;
  }else if (theEvent.controller().name()=="boxButton") {
    isTagging = true;
    tempTag="";
    tagBoxInputField.setVisible(false);
    tagInputField.setVisible(false);
    tagSaveButton.setVisible(false);
    tagBoxButton.setCaptionLabel("Tagging...");
  }
}

//-------------------------------Remote-------------------------\\

/* incoming osc message are forwarded to the oscEvent method. */
void oscEvent(OscMessage theOscMessage) {

  if (theOscMessage.checkAddrPattern("/mouseClicked")==true) {
   mouseButton = LEFT;
   mouseClicked();
  }
  else if (theOscMessage.checkAddrPattern("/mouseMoved")==true) {
    int xCoord = theOscMessage.get(0).intValue();
    int yCoord = theOscMessage.get(1).intValue();
    mouseX = xCoord*2;
    mouseY = yCoord*2;
  }
  else if (theOscMessage.checkAddrPattern("/keyPressed")==true) {
    //isMouseDown = false;
   key = theOscMessage.get(0).charValue();
   keyCode = theOscMessage.get(1).intValue();
   keyPressed();
  }
}
