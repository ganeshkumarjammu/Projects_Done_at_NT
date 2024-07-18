
# Frequency Generator with Arduino

## Overview
This project generates square wave signals at different frequencies using an Arduino and its Timer1. The frequencies can be selected by pressing buttons connected to specific pins, and the output signal is generated on pin 9.

## Pin Connections
- **Input Pins (for selecting frequencies):**
  - Pin 2: 50 kHz
  - Pin 3: 100 kHz
  - Pin 4: 200 kHz
  - Pin 5: 500 kHz
  - Pin 6: 1 MHz
  - Pin 7: 2 MHz

- **Output Pin:**
  - Pin 9: Generates the square wave signal.

### Pinout and Connections
- **IN[6]**: Input pins to select the desired frequency:
  - `IN[0]`: Pin 2
  - `IN[1]`: Pin 3
  - `IN[2]`: Pin 4
  - `IN[3]`: Pin 5
  - `IN[4]`: Pin 6
  - `IN[5]`: Pin 7

- **OUT**: Output pin for the generated signal:
  - Pin 9

### Frequency Calculation
The frequency of the signal is controlled using Timer1 in CTC (Clear Timer on Compare Match) mode. The formula used for calculating the OCR (Output Compare Register) value is:

      OCR = ( Clock_Speed / (2 x frequency_in_Hz) ) - 1 

This formula derives from the following:
- 16,000,000 is the clock speed of the Arduino (16 MHz).
- The factor of 2 accounts for the toggle mode, which generates a full cycle in two counts (one high and one low).
- Subtracting 1 adjusts for the zero-based counting of the timer.

### Calculations for Each Frequency

| Frequency (kHz) | Frequency (Hz) | OCR Calculation                                      | OCR Value |
|-----------------|----------------|-----------------------------------------------------|-----------|
| 50              | 50,000         | \(16,000,000/(2 x 50,000)) - 1\) = 159 | 159       |
| 100             | 100,000        | \(16,000,000/(2 x 100,000)) - 1\) = 79  | 79        |
| 200             | 200,000        | \(16,000,000/(2 x 200,000)) - 1\) = 39  | 39        |
| 500             | 500,000        | \(16,000,000/(2 x 500,000)) - 1\) = 15  | 15        |
| 1000            | 1,000,000      | \(16,000,000/(2 x 1,000,000)) - 1\) = 7 | 7         |
| 2000            | 2,000,000      | \(16,000,000/(2 x 2,000,000)) - 1\) = 3 | 3         |

For detailed calculations, refer to the Google Sheets [here](https://docs.google.com/spreadsheets/d/1KBi5O0dpadDuW_CeP1MCz1DQ4IypS_nGeOXi4cxVNZ8/edit?usp=sharing).

## Time Period Table

| Frequency (kHz) | Frequency (Hz) | OCR Value | Time Period |
|-----------------|----------------|-----------|-------------|
| 50              | 50,000         | 159       | 20          |
| 100             | 100,000        | 79        | 10          |
| 200             | 200,000        | 39        | 5           |
| 500             | 500,000        | 15        | 2           |
| 1000            | 1,000,000      | 7         | 1           |
| 2000            | 2,000,000      | 3         | 0.5         |



### Code Explanation

```cpp
// Define input pins
uint8_t IN[6] = {2, 3, 4, 5, 6, 7};

// Define corresponding signal frequencies in kHz
unsigned long int sig[6] = {50, 100, 200, 500, 1000, 2000}; // Frequencies in kHz

// Define OCR values for Timer1 to achieve the required frequencies
unsigned int OCR[6] = {159, 79, 39, 15, 7, 3}; // OCR values calculated for the respective frequencies

// Variable to store the current input pin that is active
int inputPin = -1;

// Define the output pin for the signal
uint8_t OUT = 9; // OUTPUT SIGNAL PIN is 9

void setup() {
  // Set up input pins with pull-up resistors
  for (int i = 0; i < 6; i++) {
    pinMode(IN[i], INPUT_PULLUP);
  }

  // Set up the output pin
  pinMode(OUT, OUTPUT);

  // Initialize Serial communication
  Serial.begin(9600);
  Serial.println("Hello ");
}

void loop() {
  bool signalSet = false;

  // Check each input pin
  for (int i = 0; i < 6; i++) {
    if (!digitalRead(IN[i])) {
      // Print the active pin and corresponding frequency
      Serial.print("Given Input on Pin: ");
      Serial.println(i + 2); // Print the actual pin number
      Serial.print("Generate Signal of kHz: ");
      Serial.println(sig[i]);     

      // Set up Timer1 for the corresponding frequency if a different pin is pressed
      if (inputPin != i) {
        inputPin = i;
        TCCR1A = _BV(COM1A0); // Toggle OC1A on Compare Match (PWM mode)
        TCCR1B = _BV(WGM12) | _BV(CS10); // CTC mode, no prescaler
        OCR1A = OCR[i]; // Set OCR1A for the desired frequency at 16 MHz clock
      }

      signalSet = true;
      break;
    }
  } 

  // Stop the signal if no button is pressed
  if (!signalSet && inputPin != -1) {
    TCCR1A = 0;
    TCCR1B = 0;
    inputPin = -1;
  }
}
```



## How It Works
1. **Setup:**
   - Initializes the input pins with pull-up resistors.
   - Sets up pin 9 as the output pin.
   - Initializes serial communication for debugging.

2. **Loop:**
   - Checks each input pin to see if a button is pressed.
   - If a button is pressed, it configures Timer1 to generate the corresponding frequency on pin 9.
   - If no button is pressed, it stops the signal by disabling Timer1.

## Usage
1. Connect buttons to pins 2 through 7.
2. Connect an oscilloscope or frequency counter to pin 9 to observe the output signal.
3. Press a button to generate the corresponding frequency. The signal will stop when no button is pressed.

---