/************************************************* 
 
 File: CSC690_Proj3x ImageRemote
 By: Elbert Dang
 Date: 10/25/2014
 
 Usage: Run using Processing 2.x with Minim, ControlP5, and OSXP5 libraries
 -Load images into the data/img folder
 System: JVM 
 
 Description: Remotely controls ImageCarousel using mouse and keyboard
               -All mouse and keyboard actions work as they do in the Carousel, except for tagging.
               
              Mode 0: Display images in carousel fashion
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press UP or click image to bring it up in Mode 1
                 -Press < or > to shift left or right to the next group of images
              Mode 1: Display images full screen
                 -Navigate images with LEFT and RIGHT arrow keys
                 -Press DOWN or click image to go back to Mode 0
 
 *************************************************/

import oscP5.*;
import netP5.*;

OscP5 oscP5;
NetAddress myRemoteLocation;

void setup() {
  size(400, 300);
  frameRate(25);
  /* start oscP5, listening for incoming messages at port 12000 */
  oscP5 = new OscP5(this, 12000);

  /* myRemoteLocation is a NetAddress. a NetAddress takes 2 parameters,
   * an ip address and a port number. myRemoteLocation is used as parameter in
   * oscP5.send() when sending osc packets to another computer, device, 
   * application. usage see below. for testing purposes the listening port
   * and the port of the remote location address are the same, hence you will
   * send messages back to this sketch.
   */
  myRemoteLocation = new NetAddress("127.0.0.1", 12000); //Local
}

void draw() {
  background(0);
}
void mouseClicked() {
  //Only sends if left mouse is clicked
  if (mouseButton ==LEFT) {
    // make new message "/mouseClicked"
    OscMessage myMessage = new OscMessage("/mouseClicked");

    /* send the message */
    oscP5.send(myMessage, myRemoteLocation);
  }
}

void keyPressed() {
  // make new message "/keyPressed"
  OscMessage myMessage = new OscMessage("/keyPressed");
  myMessage.add(key);
  myMessage.add(keyCode);

  /* send the message */
  oscP5.send(myMessage, myRemoteLocation);
}

void mouseMoved() {
  OscMessage myMessage = new OscMessage("/mouseMoved");
  myMessage.add(mouseX);
  myMessage.add(mouseY);
  oscP5.send(myMessage, myRemoteLocation);
}

