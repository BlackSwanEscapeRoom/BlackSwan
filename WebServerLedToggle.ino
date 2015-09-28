#include <SPI.h>
#include <Ethernet.h>

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = {
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
};
IPAddress ip(192, 168, 1, 1);
IPAddress remote(74,125,232,128);
bool ledStatus = true;
int led = 7;

// Initialize the Ethernet server library
// with the IP address and port you want to use
// (port 80 is default for HTTP):
EthernetServer server(80);

void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }

  pinMode(led, OUTPUT);
  // start the Ethernet connection and the server:
  Ethernet.begin(mac, ip);
  server.begin();
  Serial.print("server is at ");
  Serial.println(Ethernet.localIP());
}

void loop() {
  digitalWrite(led, ledStatus ? LOW : HIGH);
  
  webserver();  
}

void webserver(){  
  EthernetClient client = server.available();
 
  if (client) {
    boolean currentLineIsBlank = true;
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();
        
        if (c == '\n' && currentLineIsBlank) {
          ledStatus = !ledStatus; 
                   
          client.println("HTTP/1.1 200 OK");
          client.println("Connection: close");
  
          client.println();
          break;
        }
        if (c == '\n') {
          // you're starting a new line
          currentLineIsBlank = true;
        }
        else if (c != '\r') {
          // you've gotten a character on the current line
          currentLineIsBlank = false;
        }
      }
    }
    // give the web browser time to receive the data
    delay(1);
    // close the connection:
    client.stop();
    
    //sendUpdateLed(client);
  }

}

void sendUpdateLed(){
  EthernetClient client = server.available();
 
  if (client.connect(remote, 80)) {
    Serial.println("connected");
    // Make a HTTP request:
    client.println("GET /updatedLed HTTP/1.1");
    client.println("Host: 192.168.1.2");
    client.print("Led: ");
    client.println(ledStatus);
    client.println();
    
    client.stop();
  }
}

