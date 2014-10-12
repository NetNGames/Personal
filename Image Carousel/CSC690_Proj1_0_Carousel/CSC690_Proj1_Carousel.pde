/************************************************* 
 
 File: CSC690_Proj1 
 By: Elbert Dang
 Date: 9/21/2014
 
 Usage: Run using Processing 2.x
 System: JVM 
 
 Description: Mode 0: Display images in carousels fashion
 Mode 1: Display images full screen
 
 *************************************************/


int selectedImage = 0; // Initial image to be displayed is the first
int leftmost = 0;
boolean fullscreenMode = false;
float thumbHeight;
float thumbWidth;
float thumbRatio;
int fullWidth = 800;
int windowWidth = fullWidth/5;
int fullHeight = 600;
int windowHeight = fullHeight/4;
int border = 50;

// Declaring an array of images.
PImage[] imageList;// = new PImage[maxImages]; 

void setup() {
  size(fullWidth, fullHeight);

  // Loading the images into the array
  //From http://processing.org/discourse/beta/num_1253083238.html and http://processing.org/discourse/beta/num_1247100666.html
  File dir = new File(sketchPath +"/data/");
  String[] list = dir.list();

  //Make imagelist the capable of holding all files in data
  imageList = new PImage[list.length];

  if (list == null) {
    println("Folder does not exist or cannot be accessed.");
  } else {
    int j=0;
    for (int i=0; i < list.length; i ++ ) { //Loops through data list
      if (list[i].endsWith("png")||  //Loads into image array if it's a picture
      list[i].endsWith("jpg")||
        list[i].endsWith("gif")||
        list[i].endsWith("bmp")) {
        imageList[j] = loadImage( list[i] );
        j++;
      }
    }
  }
 // println(imageList.length);
}


void draw() {
  background(#6A0E0E); //maroon background
  if (fullscreenMode) {
    thumbRatio=fullWidth/fullHeight;
    resizeImage(imageList[selectedImage]);
    imageMode(CENTER);
    image(imageList[selectedImage], fullWidth/2, fullHeight/2, thumbWidth, thumbHeight); 
    rectMode(CENTER);
    stroke(#000000); //black border
    strokeWeight(border);
    //Transparent rectangle
    noFill();
    //http://processing.org/reference/rect_.html
    rect(fullWidth/2, fullHeight/2, thumbWidth+border, thumbHeight+border);
  } else {
    thumbRatio=windowWidth/windowHeight;
    displayThumbnails();
  }
}
void displayThumbnails() {
  // Displaying images
  imageMode(CENTER);
  if (leftmost >=0 && leftmost <= imageList.length-5) { //Normal display from 0 to end-4
    drawImage(leftmost, 0);
    drawImage(leftmost+1, 1);
    drawImage(leftmost+2, 2);
    drawImage(leftmost+3, 3);
    drawImage(leftmost+4, 4);
  } else if (leftmost==imageList.length-4) {
    drawImage(leftmost, 0);
    drawImage(leftmost, 1);
    drawImage(leftmost, 2);
    drawImage(leftmost, 3);
    drawImage(0, 4);
  } else if (leftmost==imageList.length-3) {
    drawImage(leftmost, 0);
    drawImage(leftmost, 1);
    drawImage(leftmost, 2);
    drawImage(0, 3);
    drawImage(1, 4);
  } else if (leftmost==imageList.length-2) {
    drawImage(leftmost, 0);
    drawImage(leftmost, 1);
    drawImage(0, 2);
    drawImage(1, 3);
    drawImage(2, 4);
  } else if (leftmost==imageList.length-1) {
    drawImage(leftmost, 0);
    drawImage(0, 1);
    drawImage(1, 2);
    drawImage(2, 3);
    drawImage(3, 4);
  }
}
void drawImage(int index, int offset) {
  resizeImage(imageList[index]);
  image(imageList[index], //Displays images from leftmost and 4 more
  (windowWidth*offset)+(windowWidth/2), 
  fullHeight/2, //Vertical center
  thumbWidth, 
  thumbHeight);
  if (index==selectedImage) { //Draws border around selected image
    selectBorder(imageList[index]);
  }
}
void selectBorder(PImage image) {
  rectMode(CENTER);          
  stroke(#5755BC);
  strokeWeight(5);
  //Transparent rectangle
  noFill();
  //http://processing.org/reference/rect_.html
  rect((selectedImage-leftmost)*windowWidth+(windowWidth/2), fullHeight/2, windowWidth, windowHeight);
}

void shiftLeft() {
  //  if (leftmost>=5) {
  //    leftmost = leftmost-5;
  //    selectedImage = leftmost;
  //    displayThumbnails();
  //  } else {
  //    int temp = leftmost-5;
  //    if(temp<0){
  //      leftmost = imageList.length+temp;
  //    }else{
  //      leftmost = imageList.length-temp;
  //    }    
  //    selectedImage = leftmost;
  //    displayThumbnails();
  //  }
  //println("left: "+leftmost);
  leftmost = leftmost-5;
  //println("left: "+leftmost);
  if (leftmost < 0) {
    leftmost = imageList.length+leftmost;
  }
  displayThumbnails();
}
void shiftRight() {
  //  if (leftmost<=imageList.length-5) {
  //    leftmost = leftmost+5;
  //    selectedImage = leftmost;
  //    displayThumbnails();
  //  } else {
  //    int temp = leftmost+5;
  //    if(temp > imageList.length-1){
  //      leftmost = temp-imageList.length;
  //      selectedImage = leftmost;
  //    }else{
  //      leftmost = imageList.length-temp;
  //    }
  //    displayThumbnails();
  //  }
  leftmost = leftmost+5;
  //println("left: "+leftmost);
  if (leftmost>imageList.length-1) {
    leftmost = leftmost-imageList.length;
  }
  displayThumbnails();
}

void keyPressed() {
  if (key == CODED) {
    if (keyCode == LEFT) {
      selectedImage--;
      if (fullscreenMode && 0 > selectedImage) {          
        selectedImage=imageList.length-1;
      } else { //Not in fullscreen
        if (selectedImage<leftmost) { //If going left of leftmost image
          shiftLeft(); //Shift screen to left
          selectedImage = leftmost + 4; //Set selected image to rightmost
        }
        displayThumbnails();
      }
    } else if (keyCode == RIGHT) {
      selectedImage++;
      if (fullscreenMode && selectedImage>imageList.length-1) {  
        selectedImage=0;
      } else { //Not in fullscreen
        if (selectedImage>leftmost+4) { //If going right of rightmost image
          shiftRight(); //Shift screen to left
          selectedImage = leftmost; //Set selected image to leftmost
        }
        if (selectedImage > imageList.length-1) {//if going off last
          selectedImage = 0;
        }
        displayThumbnails();
      }
    } else if (keyCode == UP) {
      fullscreenMode = true;
    } else if (keyCode == DOWN) {
      fullscreenMode = false; //Centers selected image
      if (selectedImage==0) { 
        leftmost = imageList.length-3;
      } else if (selectedImage==1) {
        leftmost = imageList.length-2;
      } else {
        leftmost = selectedImage-2;
      }
    }
  } else if (key == '>') {
    if (!fullscreenMode) {//Does nothing if in fullscreenMode
      shiftRight();
      selectedImage=leftmost;
    }
  } else if (key == '<') {
    if (!fullscreenMode) {//Does nothing if in fullscreenMode
      shiftLeft();
      selectedImage=leftmost;
    }
  } 
//  println("left: "+ leftmost);
//  println("selected" + selectedImage);
} 

//Resizes image to appropriate size
void resizeImage(PImage img) {
  float imgHeight = img.height;
  float imgWidth = img.width;
  float imgRatio = imgWidth/imgHeight;
  if (fullscreenMode) { //If in fullscreen
    if (thumbRatio > imgRatio) { //If thumbnail width is larger than img height
      thumbHeight = fullHeight-border;
      thumbWidth = (fullHeight-border) * imgRatio;
    } else if (thumbRatio < imgRatio) {  //If thumbnail width is larger than img height
      thumbHeight = (fullWidth-border) * (1/imgRatio);
      thumbWidth = (fullWidth-border);
    } else {//If thumbnail ratio was equal to img
      thumbHeight = fullHeight-border;
      thumbWidth = fullWidth-border;
    }
  } else { //not in fullscreen
    if (thumbRatio > imgRatio) { //If thumbnail width is larger than img height
      thumbHeight = windowHeight-(border/2);
      thumbWidth = (windowHeight-(border/2)) * imgRatio;
    } else if (thumbRatio < imgRatio) {  //If thumbnail width is larger than img height
      thumbHeight = windowWidth * (1/imgRatio);
      thumbWidth = windowWidth-(border/2);
    } else {//If thumbnail ratio was equal to img
      thumbHeight = windowWidth-(border/2);
      thumbWidth = windowWidth-(border/2);
    }
  }
}

//Not working yet
//public void mouseClicked() {
//  if (!fullscreenMode && mouseButton == 37) { //Left mouse click
//    boolean select = false;
//
//    //int dimen[];
//    int imgCenterX;
//    int imgCenterY = fullHeight / 2;
//
//    //check each image on image bar
//    short i, j = -2;            
//    do {
//      //dimen = photoList.getScaling(j);
//      imgCenterX = width / 2 + (thumbWidth + 20) * j;
//
//      if (mouseX < imgCenterX + thumbWidth/2 && 
//        mouseX > imgCenterX - thumbWidth/2 &&
//        mouseY < imgCenterY + thumbHeight &&
//        mouseY > imgCenterY - thumbHeight)
//      {
//        i = 0;
//
//        if (j < 0) {
//          do {
//            photoList.prev();
//
//            i--;
//          } 
//          while (i > j);
//        } else if (j > 0) {
//          do {
//            photoList.next();
//
//            i++;
//          } 
//          while (i < j);
//        }
//
//        select = true;
//
//        break;
//      }
//
//      j++;
//    } 
//    while (j < 3);
//
//
//    if (select) {
//      fullscreenMode = true;
//    }
//  }
//}

