//Link to Sheets for this values: https://docs.google.com/spreadsheets/d/1KBi5O0dpadDuW_CeP1MCz1DQ4IypS_nGeOXi4cxVNZ8/edit?usp=sharing
uint8_t IN[6] = {2, 3, 4, 5, 6, 7};
unsigned long int sig[6] = {50, 100, 200, 500, 1000, 2000}; // Frequencies in kHz
unsigned int OCR[6]={159,79,39,15,7,3};  //OCR = ((16,000,000)/(2*sig(in hz))-1)
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
}

void loop() {
  for (int i = 0; i < 6; i++) {
    if (!digitalRead(IN[i])) {
      Serial.print("Given Input on Pin: ");
      Serial.println(inputPin + 2);
      Serial.print("Generate Signal of kHz: ");
      Serial.println(sig[i]);     
      if(inputPin!=i){
        inputPin = i ;
        TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
        TCCR1B = _BV(WGM12) | _BV(CS10);  // CTC mode, no prescaler
        OCR1A = OCR[i]; // Set OCR1A for 500 kHz frequency at 16 MHz clock
      }
    }
  } 
}
