
#include <Arduino.h>
#include <Ethernet.h>


class WebServer{
public:
  static void Listen(EthernetClient);
  
private:
  static String createResponseBody(String[]);
};



