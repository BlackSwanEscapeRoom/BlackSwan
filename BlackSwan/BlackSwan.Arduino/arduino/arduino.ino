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
	while (!Serial);

	pinMode(ledPin, OUTPUT);
	pinMode(switchPin, OUTPUT);

	int ip[] = { 192, 168, 1, 177 };

	BlackSwan::RegisterComponent("/led", getLedState, changeLedState);
	BlackSwan::RegisterComponent("/switch", getSwitchState, 0);

	BlackSwan::Init(ip);
}

void loop() {
	BlackSwan::Loop();

	digitalWrite(ledPin, ledState);
}

bool changeLedState(int value) {
	ledState = value == 1;
	return true;
}

int getLedState() {
	return ledState;
}

int getSwitchState() {
	return digitalRead(switchPin);
}



