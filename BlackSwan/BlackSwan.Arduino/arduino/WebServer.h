#include <Arduino.h>

class WebServer{
private:
  static String _method, _path;
  static int _spaceCount;
  static int _backslashCount;
 
public:
  static void Listen(EthernetClient client);
  static bool ledIsOn;
  
private:
  static void splitIntoHeaders(char c);
  static void setResponse(EthernetClient client);
  static String handleRequest(String method, String category, String component, String value);
  static String splitUrl(String method, String path);

};
