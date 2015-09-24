#include <SPI.h>
#include <Ethernet.h>
#include <string.h>
#include "WebServer.h"
#include "BlackSwan.h"

byte mac[] = {
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
};

bool ledState = false;
IPAddress ip(192, 168, 1, 177);
EthernetServer server(80);

void setup() {
  pinMode(8, OUTPUT);

  Serial.begin(9600);
  while (!Serial) {
    ;
  }
  Ethernet.begin(mac, ip);
  server.begin();
  Serial.print("server is at ");
  Serial.println(Ethernet.localIP());

  BlackSwan::RegisterComponent("/led", getLedState, changeLedState);
}

void loop(){
 EthernetClient client = server.available();
  WebServer::Listen(client);
  digitalWrite(8, ledState ? HIGH : LOW); 
}

bool changeLedState(int value){
  ledState = value == 1;
   return true;
}

int getLedState(){
  return ledState;
}

