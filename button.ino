void setup() {
  pinMode(8,INPUT_PULLUP); // logic for button click
  pinMode(13,OUTPUT); // diode that lights up
}

void loop() {
  int info =  digitalRead(8); // reads button state
  digitalWrite(13,!info); // writes diode if is pressed
}
