/************************************************* 
 
 File: CSC690_Proj1_5
 By: Elbert Dang
 Date: 9/21/2014
 
 Usage: Run using Processing 2.x
 System: JVM 
 
 Description: Mode 0: Display images in carousel fashion
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press UP or click image to bring it up in Mode 1
                 -Press < or > to shift left or right to the next group of images
              Mode 1: Display images full screen
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press DOWN or click image to go back to Mode 0
                 -Type text into textbox to edit image tags
 1.5 update - Add animated transitions and mouseclick to open
 2.5 update - Add sounds for screen transitions
            - Add tags in Fullscreen mode
 
 *************************************************/


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
int[] currentDisplay = { 0, 1, 2, 3, 4};
boolean right = true;

// Declaring an array of images.
PImage[] imageList;// = new PImage[maxImages]; 

//Loading audio
import ddf.minim.*;

Minim minim;
AudioPlayer longSound;
AudioPlayer shortSound;

//Textfield for tags
import java.awt.*;
TextField tagTextField = new TextField("", 10);

void setup() {
  size((int)fullWidth, (int)fullHeight);

  // Loading the images into the array
  //From http://processing.org/discourse/beta/num_1253083238.html and http://processing.org/discourse/beta/num_1247100666.html
  File dir = new File(sketchPath +"/data/img/");
  String[] list = dir.list();

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
  // println(imageList.length);
  
  //Load sounds
  minim = new Minim(this);
  longSound = minim.loadFile("aud/long.wav");
  shortSound = minim.loadFile("aud/short.mp3");
  
  //Lets textfield listen to key presses
  tagTextField.addKeyListener(this);
}


void draw() {
  background(#6A0E0E); //maroon background
  if (fullscreenMode) {
    displayFullscreen();
  } else {
    thumbRatio=windowWidth/windowHeight;
    displayThumbnails();
  }
}
void displayFullscreen() {
  thumbRatio=fullWidth/fullHeight;
  int offset;//offset of leftmost of current images
  if (toAnimate>0) { //if shifting right
    offset = -1;
  } else if (toAnimate<0) { //if shifting left
    offset = 1;
  }else{
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
  } else if (toAnimate<0) {
    toAnimate+=5;
  }
  //last so it appears on top
  displayTags();
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
  if (right) { //if shifting right
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
  right = false;
  toAnimate = -500; 
  leftmost = leftmost-5; 
  if (leftmost < 0) {
    leftmost = imageList.length+leftmost;
  }
  //displayThumbnails();  
}
void shiftRight() {
  longSound.rewind();
  longSound.play();
  right = true;
  toAnimate = 500; 
  leftmost = leftmost+5; 
  if (leftmost>imageList.length-1) { //If left+5 is greater than the index of the last image
    leftmost = leftmost-imageList.length; //Find difference and set new leftmost
  }
  //displayThumbnails();
}

void keyPressed() {
  if (key == CODED) {    
    if (keyCode == LEFT) {
      selectedImage--; 
      if (fullscreenMode) {
        shortSound.rewind();
        shortSound.play();
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
  }else if ((key == RETURN||key == ENTER)&&fullscreenMode) {
    //textField.setFocusable(false);
//       s = textField.getText();
//       println("textfield: "+textField.getText());
//       println("parsed text: "+s);
//       redraw();
//    
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
      thumbHeight = windowWidth * (1/imgRatio); 
      thumbWidth = windowWidth-(border/2);
    } else {//If thumbnail ratio was equal to img's
      thumbHeight = windowWidth-(border/2); 
      thumbWidth = windowWidth-(border/2);
    }
  }
}

void mouseClicked() {
  if (!fullscreenMode && mouseButton == LEFT) { //Left mouse click on thumbnail
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
  } else {//Already in fullscreenMode
    shortSound.rewind();
    shortSound.play();
    fullscreenMode = false; //Switch back to thumbnail view with selected image in center
    if (selectedImage==0) {
      leftmost = imageList.length-2;
    } else if (selectedImage==1) {
      leftmost = imageList.length-1;
    } else {
      leftmost = selectedImage-2;
    }
  }
}

void displayTags(){
  textSize(32);
  textAlign(CENTER);
  text("test", fullWidth/2, fullHeight-(border/4));
}
