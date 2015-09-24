#include <SPI.h>
#include <Ethernet.h>
#include <string.h>
#include "WebServer.h"

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = {
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
};


IPAddress ip(192, 168, 1, 177);

// Initialize the Ethernet server library
// with the IP address and port you want to use
// (port 80 is default for HTTP):
EthernetServer server(80);

//start boolean for the led1 on pin 8

void setup() {
  pinMode(8, OUTPUT);

  // Open serial communications and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }


  // start the Ethernet connection and the server:
  Ethernet.begin(mac, ip);
  server.begin();
  Serial.print("server is at ");
  Serial.println(Ethernet.localIP());
}


void loop(){
 EthernetClient client = server.available();
  WebServer::Listen(client); 

  //digitalWrite(8, WebServer::ledIsOn ? HIGH : LOW); 
}

