
char message[10];
int mess_len;

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  message[0] = 0;
  mess_len = 0;
  pinMode(LED_BUILTIN, OUTPUT);     
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
    {
      digitalWrite(LED_BUILTIN, HIGH); 
    }
    else if (ch=='0')
    {
      digitalWrite(LED_BUILTIN, LOW); 
    }
    Serial.println();  
    break;
  }
  message[0] = 0;
  mess_len = 0;
  delay(10);
  while (Serial.available()>0) Serial.read();
}

// the loop routine runs over and over again forever:
void loop() {
  if(Serial.available() > 0)
  {
    char ch = Serial.read();
    if (ch>='0')
    {
      message[mess_len] = ch;
      mess_len++; 
    }
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




