#include "WebServer.h"
#include "WebClient.h"
#include "BlackSwan.h"

IPAddress remote(192,168,1,1);

void WebClient::SendComponentUpdate(EthernetClient client, String component, int value){
  if (client.connect(remote, 8080)) {
    Serial.println("connected");

    client.println("change");
    client.println(component);
    client.println(value);
  }
  else {
    // if you didn't get a connection to the server:
    Serial.println("connection to remote failed");
  }
}

bool WebClient::RegisterToRemote(EthernetClient client){
  if (client.connect(remote, 8080)) {
    Serial.println("connected");
    client.println("register");
    client.println(BlackSwan::GetMeta());
    return true;
  }
  return false;
}
