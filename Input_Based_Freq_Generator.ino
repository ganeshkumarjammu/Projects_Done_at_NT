uint8_t IN[6] = {2, 3, 4, 5, 6, 7};
unsigned long int sig[6] = {50, 100, 200, 500, 1000, 2000}; // Frequencies in kHz
long delayUS[6] = {0, 0, 0, 0, 0, 0};
uint8_t inputPin;
uint8_t OUT = 13;

void setup() {
  for (int i = 0; i < 6; i++) {
    pinMode(IN[i], INPUT_PULLUP);
  }
  pinMode(OUT, OUTPUT);
  Serial.begin(9600);
  Serial.println("Hello ");
  findHalfDutyCycle();
}

void loop() {
  for (int i = 0; i < 6; i++) {
    if (!digitalRead(IN[i])) {
      inputPin = i;
      Serial.print("Given Input on Pin: ");
      Serial.println(inputPin + 2);
      Serial.print("Generate Signal of kHz: ");
      Serial.println(sig[i]);
      Serial.print("Generated half duty delay: ");
      Serial.println(delayUS[i]);      
      delay(1500);
      
      while (1) {
        digitalWrite(OUT, HIGH);
        delayMicroseconds(delayUS[i]); 
        digitalWrite(OUT, LOW);
        delayMicroseconds(delayUS[i]); 
      }
    }
  } 
}

void findHalfDutyCycle() {
  for (int i = 0; i < 6; i++) {
    delayUS[i] = 1000000 / (2 * sig[i] * 1000); // Calculate half period in microseconds
    Serial.print("Half Delays are: ");
    Serial.println(delayUS[i]);
  }
}
