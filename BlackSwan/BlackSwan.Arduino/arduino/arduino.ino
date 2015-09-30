#include <string.h>
#include <SPI.h>
#include <Ethernet.h>

#include "BlackSwan.h"

bool ledState = false;
int ledPin = 7;
int switchPin = 6;

void setup() 
{
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
   
  pinMode(ledPin, OUTPUT);
  pinMode(switchPin, OUTPUT);
  
  int ip[] = {192, 168, 1, 177};
  
  BlackSwan::Init(ip);
  BlackSwan::RegisterComponent("/led", getLedState, changeLedState);
  BlackSwan::RegisterComponent("/switch", getSwitchState, 0);
}

void loop(){
  BlackSwan::Loop();
  
  digitalWrite(ledPin, ledState); 
}

bool changeLedState(int value){
  ledState = value == 1;
  return true;
}

int getLedState(){
  return ledState; 
}

int getSwitchState(){
  return digitalRead(switchPin);
}



