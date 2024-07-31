#include <LiquidCrystal_I2C.h>
const int CLOCK_PIN = 9;  // Use digital pin 9 as the clock pin (supports PWM)
const int DATA_PIN = 10;   // Data pin for encoder
const int BIT_COUNT = 13; // Number of bits for Gray code
const int READ_DELAY = 21; // Delay between readings in microseconds
LiquidCrystal_I2C lcd(0x27, 20, 04);
unsigned long start, now, elapsed,unfoldTime,startMicros;
unsigned long delayMicros = 2500000;// 2.5 seconds in microseconds

int angle = 0 ; //current Angle
int iAngle = 0; //initial Angle
int fAngle = 0; //final Angle
int prevAngle = 0; //prevAnge
int count = 0;
bool timerOn = false;
bool show = false;
void setup() {
  // Set the data pin
  pinMode(DATA_PIN, INPUT);
  pinMode(CLOCK_PIN, OUTPUT);
  // Set the clock pin to high initially
  digitalWrite(CLOCK_PIN, HIGH);
  Serial.begin(19200);
  //Serial.println("Programm Started Running");
  // Initialize serial communication
  lcd.begin();
  lcd.clear();
  printMsg("Absolute Encoder  ", "Angle Reader", "Push Button To Read");
  delay(1000);
  readAngle();
  iAngle = angle;
  //printMsg("Angle: " + String(angle) + (char)223 + "      ", "Duration: "+String(elapsed)+"ms    ", "Push Start Button");
  printMsg("Angle      : " + String(angle) + (char)223 + "     ", "Unfold Time: 00ms   ", "Push Start Button");
}

void loop() {
  readAngle();
  checkAngle();
}

void readAngle() {
  unsigned long grayCode = readGrayCode();
  unsigned long binaryValue = grayToBinary(grayCode);
  angle = round((binaryValue / 8190.0) * 360.0);
  //Serial.print("Gray Code: ");
  //printBinary(grayCode, BIT_COUNT);
  //Serial.print(" Binary: ");
  // printBinary(binaryValue, BIT_COUNT);
  //Serial.print(" Angle: ");
  //Serial.print(binaryValue, DEC);
  //  Serial.print("\nAngle: ");
  //  Serial.println(angle);
}

void checkAngle() {
  delayMicroseconds(READ_DELAY); // Delay to meet encoder's timing requirements
  if ((angle == iAngle) && (iAngle == prevAngle)) {
    // Serial.println("\nNo Change in Angle");
    //printMsg("No Change in Angle");
    // count = 0;
  }
  else if ((angle == iAngle) && (iAngle != prevAngle)) {
    //Serial.println("\nNoise Angle:" + String(angle));
    prevAngle = angle;
    //stopTimer();
    timerOn = false ;
    count = 0;
  }
  else if ((angle != prevAngle) && timerOn) {
    prevAngle = angle ;
    count = 0;
  }
  else if ((angle != prevAngle) && (!timerOn))
  {
    //startTimer();
    start = micros();
    timerOn = true ;
    prevAngle = angle;
    count = 0;
  }
  else if (angle == prevAngle) {
    count++;
    if (count == 5) {
      unfoldTime = duration();
    }
    else if (count == 25) {
      //unsigned long duration = stopTimer();
      Serial.print("\nInitial Angle: " + String(iAngle) + " deg ,Final Angle: " + String(angle) + " deg ,Unfold Time: " + String(unfoldTime) + " ms");
      printMsg("Initial Angle:" + String(iAngle) + (char)223 , "Final Angle  :" + String(angle) + (char)223 , "Unfold Time: " + String(unfoldTime) + "ms");
      show = true;
      startMicros = micros();
      iAngle = angle;
      timerOn = false ;
      count = 0;
    } 
  }
  //Serial.print("\nInitial Angle: " + String(iAngle) + " deg ,Final Angle: " + String(angle) + " deg ,Unfold Time: " + String(unfoldTime) + " ms");
  //Serial.println("\nprevAngle :" + String(prevAngle) + " iAngle :" + String(iAngle) + " Angle :" + String(angle));
  if((micros() - startMicros > delayMicros)&&show) {
    show = false;
    printMsg("Angle      : " + String(angle) + (char)223 , "Unfold Time: " + String(unfoldTime) + "ms", "Push Start Button");
    delay(500);
  }
}

unsigned long duration() {
  now = micros();
  elapsed = (now - start) / 1000;
  return  elapsed ;
}

void setupPWM() {
  // Configure Timer1 for 50 kHz PWM
  TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
  TCCR1B = _BV(WGM12) | _BV(CS10);  // CTC mode, no prescaler
  OCR1A = 159; // Set OCR1A for 50Khz frequency
}

// Read the 13-bit Gray code
unsigned long readGrayCode() {
  unsigned long data = 0;
  // Ensure clock is high before starting the read cycle
  //digitalWrite(CLOCK_PIN, HIGH);
  //delayMicroseconds(5);
  //Setup PWM for clock signal
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

void printMsg(String msg1, String msg2, String msg3) {
  lcd.clear();
  lcd.setCursor(0, 0); //Title
  lcd.print("Navatej Technologies");
  lcd.setCursor(0, 1); //Angle
  lcd.print(msg1);
  lcd.setCursor(0, 2); //Time taken
  lcd.print(msg2);
  lcd.setCursor(0, 3); //Read Duration : On ,off
  lcd.print(msg3);
}

//void startTimer() {
//  start = millis();
//  timerOn = true ;
//}
