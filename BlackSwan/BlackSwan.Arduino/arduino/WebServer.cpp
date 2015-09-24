#include <SPI.h>
#include <Ethernet.h>
#include <string.h>
#include "WebServer.h"

  String WebServer::_httpRequest = "", WebServer::_method = "", WebServer::_path = "";
  int WebServer::_spaceCount = 0;
  int WebServer::_backslashCount = 0;
  //bool WebServer::ledIsOn;
  
  void WebServer::Listen(EthernetClient client){
    
    // listen for incoming clients
    if (client) {
      // an http request ends with a blank line
      boolean currentLineIsBlank = true;

      while (client.connected()) {
        if (client.available()) {
          char c = client.read();
          splitIntoHeaders(c);
          // if you've gotten to the end of the line (received a newline
          // character) and the line is blank, the http request has ended,
          // so you can send a reply
          if (c == '\n' && currentLineIsBlank) {
            setResponse(client);
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

      _method = "";
      _path = "";
      WebServer::_spaceCount = 0;
      WebServer::_backslashCount = 0;
      // give the web browser time to receive the data
      delay(1);
      // close the connection:
      client.stop();
      Serial.println("client disconnected");
      Ethernet.maintain();
    };
  };


  void WebServer::splitIntoHeaders(char c){
    Serial.print(c);
    _httpRequest.concat(c);
    if (c == ' '){
      _spaceCount++;
    }
    else{
      switch (_spaceCount){
      case 0:
        _method.concat(c);
        
        break;
      case 1:
        _path.concat(c);
        break;
      }
    }

  };

  void WebServer::setResponse(EthernetClient client){
    // send a standard http response header
    client.println("HTTP/1.1 200 OK");
    client.println("Content-Type: text/html");
    client.println("Connection: close");
    // the connection will be closed after completion of the response
    client.println();

    //handle reqeuest open on screen
    client.println(splitUrl(_method, _path));

  
  }

  String WebServer::handleRequest(String method, String category, String component, String value){

    if (method == "GET"){
      if (category == "meta"){
        return "meta";
      }
      else if (category == "component"){
        return  "component";
      }
      else if (category == "device"){

      }
    }
    else if (method == "POST"){
      if (category == "/component"){
     
      }
    }

    return  "error";
  };

  String WebServer::splitUrl(String method, String path){
    String category = "";
    String component = "";
    String value = "";
    
    
    for (int i = 0; i < path.length(); i++){
      char c = path.charAt(i);
      if (c == '/'){
        _backslashCount++;
      }

      switch (_backslashCount){
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

    handleRequest(method, category, component, value);

    return "IS DIT WAT HIJ TERUG GEEFT " + method + path;
    
  };



