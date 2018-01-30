Random code parts for the documentation:

````c
if(!digitalRead(left_pin)) Serial.println("left");
if(!digitalRead(right_pin)) Serial.println("right");
if(!digitalRead(up_pin)) Serial.println("up");
if(!digitalRead(down_pin)) Serial.println("down");
````
````c
  pinMode(left_pin,INPUT_PULLUP);
  pinMode(right_pin,INPUT_PULLUP);
  pinMode(up_pin,INPUT_PULLUP);
  pinMode(down_pin,INPUT_PULLUP);
````

````c
buttonState = digitalRead(buttonPin);
  if (buttonState == LOW ) {
    if(state==1){
      state = 0;
      Serial.print("The button with the coresponding pin was pressed!");
    }
  } else {
    state=1;
  }
````
