/*
  DigitalReadSerial
 Reads a digital input on pin 2, prints the result to the serial monitor 
 
 This example code is in the public domain.
 */
String message;

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
}

// the loop routine runs over and over again forever:
void loop() {
  if(Serial.available() > 0)
  {
    char character = Serial.read();
    message += character;
    if(character == '\n')
    {
      Serial.println(message);
    }
}}



