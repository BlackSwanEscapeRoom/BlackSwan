#include "BlackSwan.h"
#include "WebClient.h"
#include "WebServer.h"

EthernetServer server = EthernetServer(80);
Component* _components = new Component[5];
int _amountOfComponents = 0;
bool _registeredToRemote = false;

void BlackSwan::Init(int ipAdres[]) {
	if (_amountOfComponents < 1) {
		Serial.println("Warning: Register your components before calling BlackSwan::Init");
	}

	byte mac[] = {
	  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
	};

	IPAddress ip(ipAdres[0], ipAdres[1], ipAdres[2], ipAdres[3]);

	Ethernet.begin(mac, ip);
	server.begin();
	Serial.print("Server is running at ");
	Serial.println(Ethernet.localIP());


	EthernetClient webClientClient;
	while (!WebClient::RegisterToRemote(webClientClient));
}

void BlackSwan::Loop() {
	EthernetClient webServerClient = server.available();
	WebServer::Listen(webServerClient);

	for (int i = 0; i < _amountOfComponents; ++i) {
		Component c = _components[i];
		int currentValue = c.Get();

		if (currentValue != c.Value) {
			c.Value = currentValue;
			_components[i] = c;

			EthernetClient webClientClient;
			WebClient::SendComponentUpdate(webClientClient, c.Name, c.Value);

			Serial.print("Value changed of ");
			Serial.print(c.Name);
			Serial.print(" to: ");
			Serial.println(c.Value);
		}
	}

	delay(100);
}

Component BlackSwan::RegisterComponent(String name, int(*get)(), bool(*set)(int)) {
	Serial.print("Component registered: ");
	Serial.println(name);

	Component c;
	c.Name = name;
	c.Get = get;
	c.Set = set;

	_components[_amountOfComponents] = c;
	_amountOfComponents++;

	return c;
};

Component BlackSwan::GetComponent(String name) {
	for (int i = 0; i < _amountOfComponents; ++i) {
		if (_components[i].Name == name) {
			return _components[i];
		}
	}
}

String BlackSwan::GetMeta() {
	String result = "{\"components\":[";
	for (int i = 0; i < _amountOfComponents; ++i) {
		Component c = _components[i];
		result += "{\"name\":\"";
		result += c.Name;
		result += "\",\"getable\":";
		result += String(((long)(*c.Get)) != 0);
		result += ",\"setable\":";
		result += String(((long)(*c.Set)) != 0);

		result += (i != _amountOfComponents - 1 ? "}," : "}");
	}

	result += "]}";
	return result;
}


