
int led = 13; 
char message[10];
int mess_len;
char response[10];

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  message[0] = 0;
  mess_len = 0;
  pinMode(led, OUTPUT);     
}

void Parse()
{
  char ch = toupper(message[0]);
  int val;

  switch (ch) {
  case 'A':
    val = analogRead(0);
    Serial.println(val, DEC);
    break;
  case 'B':
    ch = message[1];
    if (ch=='1')
      digitalWrite(led, HIGH); 
    else
      if (ch=='0')
        digitalWrite(led, LOW); 
    Serial.println();  
    break;
  }
  message[0] = 0;
  mess_len = 0;
}

// the loop routine runs over and over again forever:
void loop() {
  if(Serial.available() > 0)
  {
    char ch = Serial.read();
    message[mess_len] = ch;
    mess_len++; 
    if(ch==13||mess_len==10)
    {
      Parse();
    }
    else
    {
      Serial.write(ch);
    }
  }
}




