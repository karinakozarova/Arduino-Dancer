const int left_pin = 8;
const int right_pin = 9;
const int up_pin = 10;
const int down_pin = 11;

void setup() {
  // initalizing directions
  pinMode(left_pin,INPUT_PULLUP);
  pinMode(right_pin,INPUT_PULLUP);
  pinMode(up_pin,INPUT_PULLUP);
  pinMode(down_pin,INPUT_PULLUP);
  
  Serial.begin(9600); 
}

void loop() {
  int left_status =  digitalRead(left_pin); 
  if(!left_status){ 
   Serial.write(1); 
   Serial.flush();
  }
  int right_status =  digitalRead(right_pin); 
  if(!right_status){ 
    Serial.write(2); 
    Serial.flush();
  }
  int up_status =  digitalRead(up_pin); 
  if(!up_status){ 
      Serial.write(3); 
      Serial.flush();
  }
  
  int down_status =  digitalRead(down_pin); 
  if(!down_status){ 
    Serial.write(4);
    Serial.flush();
  }
}
