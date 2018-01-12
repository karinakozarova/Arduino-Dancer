void setup() {
  // put your setup code here, to run once:
  pinMode(8,INPUT_PULLUP); // logic for button click
  pinMode(13,OUTPUT); // diode that lights up
}

void loop() {
  // put ryour main code here, to run repeatedly:
  int info =  digitalRead(8); // reads button state
  digitalWrite(13,!info); // writes diode if is pressed
}
