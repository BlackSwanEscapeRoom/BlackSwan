
#include <Arduino.h>



class Component {
public:
  int Id;
  String Name;
  int(*Get)();
  bool(*Set)(int);
  int Value;
};



 
class BlackSwan {

public:
  static void Init(int ip[]);
  static void Loop();
  static Component RegisterComponent(String, int (*)(), bool (*)(int));
  static Component GetComponent(String);
  static void ComponentValueChange(Component c, int newValue);
  static String GetMeta();
};



