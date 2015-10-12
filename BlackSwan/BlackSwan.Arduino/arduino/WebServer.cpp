#include "WebServer.h"
#include "BlackSwan.h"
    
int _spaceCount = 0;

void WebServer::Listen(EthernetClient client) {
  // listen for incoming clients
  if (client) {
    // Reset request variables
    String request = "",  requestPart = "";
    String requestParts[10];
    int partCount = 0;
    
    // an request ends with a blank line
    boolean currentLineIsBlank = true;
    
    Serial.println("New request incomming");
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();

        if (c == '\n' && currentLineIsBlank) {
          client.println(createResponseBody(requestParts));
          //client.println(requestParts[0]);
          client.println();          
          break;
        }
        
        if (c == '\n') {
          requestParts[partCount] = requestPart;
          requestPart = "";
          currentLineIsBlank = true;
        }
        else if (c != '\r') {
            requestPart += c;
          currentLineIsBlank = false;
        }
      }
    }

    // give the web browser time to receive the data
    delay(1);
    // close the connection:
    client.stop();
    
    _spaceCount = 0;
    Serial.println("client disconnected");
    Ethernet.maintain();
  };
};

String WebServer::createResponseBody(String parts[]) {
 if(parts[0] == "getmeta"){
  return BlackSwan::GetMeta();
 }
 if(parts[0] == "getcomponent"){
  Component c = BlackSwan::GetComponent(parts[1]);
  if((long)(*c.Get) != 0){
    return String(c.Get());
  }
  return "Get of this device is not available";
 } 
 if(parts[0] == "setcomponent"){
  Component c = BlackSwan::GetComponent(parts[1]);
  if((long)(*c.Set) != 0){
    return String(c.Set(parts[2].toInt()));
  }
 }
}






