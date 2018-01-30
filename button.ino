int left_pin = 8;
int right_pin = 9;
int up_pin = 10;
int down_pin = 11;


void setup() {
  // initalizing directions
  pinMode(left_pin,INPUT_PULLUP);
  pinMode(right_pin,INPUT_PULLUP);
  pinMode(up_pin,INPUT_PULLUP);
  pinMode(down_pin,INPUT_PULLUP);

  pinMode(13,OUTPUT); // diode that lights up
  Serial.begin(9600);
}

void loop() {
  int left_status =  digitalRead(left_pin); // reads button state
  if(!left_status)Serial.println("left"); // was clicked

  int right_status =  digitalRead(right_pin); // reads button state
  if(!right_status)Serial.println("right"); // was clicked

  int up_status =  digitalRead(up_pin); // reads button state
  if(!up_status)Serial.println("up"); // was clicked

  int down_status =  digitalRead(down_pin); // reads button state
  if(!down_status)Serial.println("down"); // was clicked
}
