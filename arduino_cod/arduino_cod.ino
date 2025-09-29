const int ledPin = 13;
const int analogPin = A0;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  if (Serial.available())
  {
    String command = Serial.readStringUntil('\n');//чтение команды до новой строки
    if (command == "13H")
    {
      digitalWrite(ledPin, HIGH);
      Serial.println("LED is on");
    }
    else if (command = "13L")
    {
      digitalWrite(ledPin, LOW);
      Serial.println("LED is off");
    }
    else if (command == "read" or command == "READ")
    {
      int sensorValue = analogRead(analogPin);
      Serial.println(sensorValue);
    }
  }
}
