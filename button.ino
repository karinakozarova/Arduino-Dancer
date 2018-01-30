void setup() {
  pinMode(8,INPUT_PULLUP); // logic for button click
  pinMode(9,INPUT_PULLUP); // logic for button click
  pinMode(10,INPUT_PULLUP); // logic for button click
  pinMode(11,INPUT_PULLUP); // logic for button click

  pinMode(13,OUTPUT); // diode that lights up
  Serial.begin(9600);
}

void loop() {
  int left =  digitalRead(8); // reads button state
  digitalWrite(13,!left); // writes diode if is pressed
  if(!left)Serial.println("left"); // was clicked

  int right =  digitalRead(9); // reads button state
  digitalWrite(13,!right); // writes diode if is pressed
  if(!right)Serial.println("right"); // was clicked

  int up =  digitalRead(10); // reads button state
  digitalWrite(13,!up); // writes diode if is pressed
  if(!up)Serial.println("up"); // was clicked

  int down =  digitalRead(11); // reads button state
  digitalWrite(13,!down); // writes diode if is pressed
  if(!down)Serial.println("down"); // was clicked
}
