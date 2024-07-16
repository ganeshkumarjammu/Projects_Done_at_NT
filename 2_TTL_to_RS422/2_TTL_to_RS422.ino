const int CLOCK_PIN = 9;   // Clock pin for encoder
const int DATA_PIN = 6;    // Data pin for encoder
const int BIT_COUNT = 13;  // Number of bits for Gray code
const int CLOCK = 10;
void setup() {
  // Set up our pins
  pinMode(DATA_PIN, INPUT);
  pinMode(CLOCK_PIN, OUTPUT);
  pinMode(CLOCK, OUTPUT);
  // Give some default values
  digitalWrite(CLOCK_PIN, LOW);
 digitalWrite(CLOCK, LOW);
  // Set up Timer1 for clock generation at 100 kHz
  TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
  TCCR1B = _BV(WGM12) | _BV(CS10);  // CTC mode, no prescaler
  OCR1A = 79; // Set OCR1A for 100 kHz frequency at 16 MHz clock 
  Serial.begin(19200);
}

void loop() {
  unsigned long reading = readPosition();
  unsigned long binaryValue = grayToBinary(reading);
  
  Serial.print("Gray Code: ");
  printBinary(reading, BIT_COUNT);
  Serial.print(" Binary: ");
  printBinary(binaryValue, BIT_COUNT);
  Serial.print(" Position: ");
  Serial.print(binaryValue);
  Serial.print(" Decimal: ");
  Serial.println(binaryValue, DEC);  // Print the binary value in decimal
  
  delay(1000);
}

// Read the current angular position
unsigned long readPosition() {
  // Read the same position data twice to check for errors
  unsigned long sample1 = shiftIn(DATA_PIN, CLOCK_PIN, BIT_COUNT);
  unsigned long sample2 = shiftIn(DATA_PIN, CLOCK_PIN, BIT_COUNT);

  delayMicroseconds(25);  // Clock must be high for 20 microseconds before a new sample can be taken

  if (sample1 != sample2) {
    Serial.print("Samples don't match: sample1=");
    Serial.print(sample1);
    Serial.print(", sample2=");
    Serial.println(sample2);
  }
  return sample1;
}

// Read in a byte of data from the digital input of the board.
unsigned long shiftIn(const int data_pin, const int clock_pin, const int bit_count) {
  unsigned long data = 0;
  for (int i = 0; i < bit_count; i++) {
    //digitalWrite(clock_pin, LOW);
    PORTB &= ~(1<<2);
    delayMicroseconds(5);  // Adjust delay to meet encoder's timing requirements
    data |= digitalRead(data_pin) << (bit_count - 1 - i);
    PORTB |= (1<<2);
    delayMicroseconds(5);  // Adjust delay to meet encoder's timing requirements
  }
  return data;
}

// Convert Gray code to binary
unsigned long grayToBinary(unsigned long gray) {
  unsigned long binary = gray;
  while (gray >>= 1) {
    binary ^= gray;
  }
  return binary;
}

// Function to print binary representation of a number
void printBinary(unsigned long number, uint8_t bits) {
  for (int i = bits - 1; i >= 0; i--) {
    Serial.print((number >> i) & 1);
  }
  Serial.print(" ");
}
