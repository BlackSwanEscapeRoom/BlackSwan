
#include "WebServer.h"
#include "BlackSwan.h"

String request = "",  _method = "", _path = "";
    
int _spaceCount = 0;

void WebServer::Listen(EthernetClient client) {
  // listen for incoming clients
  if (client) {
    // Reset request variables
    request = "",  _method = "", _path = "";
    
    // an http request ends with a blank line
    boolean currentLineIsBlank = true;
    
    Serial.println("New request incomming");
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();
        request += c;
        
        readMethodAndPath(c);

        // if you've gotten to the end of the line (received a newline
        // Stringacter) and the line is blank, the http request has ended,
        // so you can send a reply
        if (c == '\n' && currentLineIsBlank) {
          handleResponse(client);
          break;
        }
        if (c == '\n') {
          // you're starting a new line
          currentLineIsBlank = true;
        }
        else if (c != '\r') {
          // you've gotten a Stringacter on the current line
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


void WebServer::readMethodAndPath(char c) {
  if (c == ' ') {
    _spaceCount++;
  }
  else {
    switch (_spaceCount) {
      case 0:
        _method += c;
      case 1:
        _path += c;
    }
  }
};

void WebServer::handleResponse(EthernetClient client) {
  // send a standard http response header
  client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: application/json");
  client.println("Connection: close");
  client.println();

  String response = createResponseBody(_method, _path);
  client.println(response);
}

String WebServer::createResponseBody(String method, String path) {
  String category = "";
  String component = "";
  String value = "";
  
  int backslashCount = 0;

  for (int i = 0; i < path.length(); i++) {
    char c = path.charAt(i);
    if (c == '/') {
      backslashCount++;

    }

    switch (backslashCount) {
      case 1:
        category.concat(c);
        break;
      case 2:
        component.concat(c);
        break;
      case 3:
        value.concat(c);
        break;
    }
  }
 
  return handleRequest(method, category, component, value);
};

String WebServer::handleRequest(String method, String category, String component, String value) {
  if (method == "GET") {
    if (category == "/meta") {
      return BlackSwan::GetMeta();      
    }
    else if (category == "/component") {
      Component c = BlackSwan::GetComponent(component);
      if((long)(*c.Get) != 0){
        return String(c.Get());
      }
      return "Get of this device is not available";
    }
  }
  else if (method == "POST") {
    if (category == "/component") {
      Component c = BlackSwan::GetComponent(component);
      if((long)(*c.Set) != 0){
        c.Set(value == "/1" ? 1 : 0);
      }
      
    }
  }

  return  "Request not alowed";
};








