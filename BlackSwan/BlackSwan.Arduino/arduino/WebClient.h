
#include <Arduino.h>
#include <Ethernet.h>


class WebClient{
public:
  static void SendComponentUpdate(EthernetClient, String, int);
  static bool RegisterToRemote(EthernetClient);
    
private:


};



