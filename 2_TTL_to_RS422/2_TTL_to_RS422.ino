const int CLOCK_PIN = 9;  // Use digital pin 9 as the clock pin (supports PWM)
const int DATA_PIN = 10;   // Data pin for encoder
const int BIT_COUNT = 13; // Number of bits for Gray code
const int READ_DELAY = 21; // Delay between readings in microseconds

void setup() {
  // Set the data pin
  pinMode(DATA_PIN, INPUT);
  pinMode(CLOCK_PIN, OUTPUT);
  // Set the clock pin to high initially
  digitalWrite(CLOCK_PIN, HIGH);
  // Initialize serial communication
  Serial.begin(19200);
}

void loop() {
  unsigned long grayCode = readGrayCode();
  unsigned long binaryValue = grayToBinary(grayCode);
  Serial.print("Gray Code: ");
  printBinary(grayCode, BIT_COUNT);
  Serial.print(" Binary: ");
  printBinary(binaryValue, BIT_COUNT);
  Serial.print(" Position: ");
  Serial.println(binaryValue, DEC);
  delayMicroseconds(READ_DELAY); // Delay to meet encoder's timing requirements
}

void setupPWM() {
  // Configure Timer1 for 100 kHz PWM
  TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
  TCCR1B = _BV(WGM12) | _BV(CS10);  // CTC mode, no prescaler
  OCR1A = 159; // Set OCR1A for 50Khz frequency 
}

// Read the 13-bit Gray code
unsigned long readGrayCode() {
  unsigned long data = 0;
// Ensure clock is high before starting the read cycle
//  digitalWrite(CLOCK_PIN, HIGH);
//  delayMicroseconds(5);
  // Setup PWM for clock signal
  setupPWM();
  // Generate 13 clock cycles and read the data
  for (int i = 0; i < BIT_COUNT; i++) {
    // Wait for the clock to go low
    while (digitalRead(CLOCK_PIN) == HIGH);
    // Wait for the clock to go high
    while (digitalRead(CLOCK_PIN) == LOW);
    data <<= 1;
    data |= digitalRead(DATA_PIN); // Read the data during the high phase
  }
  // Disable PWM and set the clock pin high
  TCCR1A = 0;
  TCCR1B = 0;
  digitalWrite(CLOCK_PIN, HIGH);
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
