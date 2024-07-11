

uint8_t IN[6] = {2, 3, 4, 5, 6, 7};
unsigned long int sig[6] = {50, 100, 200, 500, 1000, 2000}; // Frequencies in kHz
unsigned int OCR[6]={159,79,39,15,7,3};
long delayUS[6] = {0, 0, 0, 0, 0, 0};
int inputPin = -1;
uint8_t OUT = 9; //OUTPUT SIGNAL PIN is 9
long wait ;
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
      Serial.print("Given Input on Pin: ");
      Serial.println(inputPin + 2);
      Serial.print("Generate Signal of kHz: ");
      Serial.println(sig[i]);
      Serial.print("Generated half duty delay: ");
      Serial.println(delayUS[i]);      
      //delay(1500);
      if(inputPin!=i){
        inputPin = i ;
        TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
        TCCR1B = _BV(WGM12) | _BV(CS10);  // CTC mode, no prescaler
        OCR1A = OCR[i]; // Set OCR1A for 500 kHz frequency at 16 MHz clock
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
