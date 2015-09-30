
#include <Arduino.h> //It is very important to remember this! note that if you are using Arduino 1.0 IDE, change "WProgram.h" to "Arduino.h"

class Component;
 
class BlackSwan {

public:
  static void Init(int ip[]);
  static void Loop();
  static Component RegisterComponent(String name, int (*get)(), bool (*set)(int));
  static Component GetComponent(String name);
  static void ComponentValueChange(Component c, int newValue);
  static String GetMeta();
};


class Component {
public:
  int Id;
  String Name;
  int(*Get)();
  bool(*Set)(int);
  int Value;
};





