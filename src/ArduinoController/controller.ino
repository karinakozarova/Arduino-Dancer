#include <SerialCommand.h>

const int left_pin = 8;
const int right_pin = 9;
const int up_pin = 10;
const int down_pin = 11;
SerialCommand sCmd;

void setup() {
  // initalizing directions
  pinMode(left_pin,INPUT_PULLUP);
  pinMode(right_pin,INPUT_PULLUP);
  pinMode(up_pin,INPUT_PULLUP);
  pinMode(down_pin,INPUT_PULLUP);
  
  Serial.begin(9600); // for writing to serial monitor
  while (!Serial);
 // sCmd.addCommand("PING", pingHandler);
}

void loop() {
  int left_status =  digitalRead(left_pin); // reads button state for left
  if(!left_status){ // left was clicked
    Serial.println("left"); 
  }

  int right_status =  digitalRead(right_pin); // reads button state for right
  if(!right_status){ // right was clicked
    Serial.println("right"); 
  }

  int up_status =  digitalRead(up_pin); // reads button state for up 
  if(!up_status){ // up was clicked
    Serial.println("up"); 
  }
  
  int down_status =  digitalRead(down_pin); // reads button state for down
  if(!down_status){ // down was clicked
    Serial.println("down");
  }

  
}
