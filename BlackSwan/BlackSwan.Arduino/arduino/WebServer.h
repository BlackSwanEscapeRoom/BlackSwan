
#include <Arduino.h>
#include <Ethernet.h>


class WebServer{
public:
  static void Listen(EthernetClient client);
  static bool ledIsOn;
  
private:
  static void readMethodAndPath(char c);
  static void handleResponse(EthernetClient client);
  static String handleRequest(String method, String category, String component, String value);
  static String createResponseBody(String method, String path);

};



