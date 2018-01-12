void setup() {
  // put your setup code here, to run once:
  pinMode(8,INPUT_PULLUP);
  pinMode(13,OUTPUT);
}

void loop() {
  // put ryour main code here, to run repeatedly:
  int info =  digitalRead(8);
  digitalWrite(13,!info);
}
