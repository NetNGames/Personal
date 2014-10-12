/************************************************* 
 
  File: CSC690_Proj0_5 
   By: Elbert Dang
  Date: 9/21/2014
 
  Usage: Run using Processing 2.x
  System: JVM 
 
  Description: For displaying 1st image in data folder 
 
*************************************************/ 
 

// Example 15-3: Swapping images

//int maxImages = 10; // Total # of images
//int imageIndex = 0; // Initial image to be displayed is the first
//import java.io.*;
// Declaring an array of images.
//PImage[] images = new PImage[maxImages];
PImage img;
float imgHeight;
float imgWidth;
float imgRatio;
float thumbHeight;
float thumbWidth;
float thumbRatio;
float maxWidth = 300;
float maxHeight = 200;

void setup() {
  size(400,300);
  //Resets thumbnail values
  //thumbHeight = 200;
  //thumbWidth = 300;
  thumbRatio = maxWidth/maxHeight;
  // Loading the images into the array
  // Don't forget to put the JPG files in the data folder!
  //for (int i = 0; i < images.length; i ++ ) {
  //  images[i] = loadImage( "animal" + i + ".jpg" ); 
  //}
  img = loadImage("Pentakill.jpg");
  //img = loadImage("image.jpg");
  //String path = sketchPath+"/data/"; 
  //File[] files = listFiles(path);
  //img=loadImage(files.getName());
    imgHeight = img.height;
    imgWidth = img.width;
    imgRatio = imgWidth/imgHeight;
    //If thumbnail width is larger than its height
    if(thumbRatio > imgRatio){
      thumbHeight = maxHeight;
      thumbWidth = maxHeight * imgRatio;
    } else {      
      thumbHeight = maxWidth * (1/imgRatio);
      thumbWidth = maxWidth;
    }
    println("imgheight="+imgHeight);
    println("imgwidth="+imgWidth);
    println("imgratio="+imgRatio);
    println("thumbheight="+thumbHeight);
    println("thumbwidth="+thumbWidth);
    println("thumbratio="+thumbRatio);
}

void draw() {
  background(#897D7D);
    //Set before you draw image or it'll draw it twice
  //noStroke();
  imageMode(CENTER);
  // Displaying one image to center
  image(img,200,150, thumbWidth, thumbHeight); 
  //Centers rectangle http://processing.org/reference/rectMode_.html
  rectMode(CENTER);
  //Border size http://processing.org/reference/strokeWeight_.html
  strokeWeight(50);
  //Transparent
  noFill();
  //http://processing.org/reference/rect_.html
  //rect(200, 150, 350, 250);
  rect(200, 150, thumbWidth+50, thumbHeight+50);

  //print(height + "x" width);
  
}

//void mousePressed() {
//  // A new image is picked randomly when the mouse is clicked
//  // Note the index to the array must be an integer!
//  imageIndex = int(random(images.length));
//}
