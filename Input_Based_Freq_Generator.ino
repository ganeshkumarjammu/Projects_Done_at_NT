
int IN[6] = {2, 3, 4, 5, 6, 7};
int sig[6] = {50,100,200,500,1000,2000}; //KHZ
int inputPin ; 
void setup() {
  // put your setup code here, to run once:
  for (int i = 0; i < 7; i++) {
    pinMode(IN[i], INPUT_PULLUP);
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  for (int i = 0 ; i < 7 ; i++) {
    if (!digitalRead(IN[i])){
      inputPin = i;
      Serial.print("Given Input on Pin:");
      Serial.println(inputPin+2);
      Serial.print("Generate Sginal of KHZ:");
      Serial.println(sig[6]);
    }
  } 
}
