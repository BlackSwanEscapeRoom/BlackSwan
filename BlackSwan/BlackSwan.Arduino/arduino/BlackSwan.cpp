#include "BlackSwan.h"

Component* _components = new Component[100];
int _amountOfComponents = 0;

Component BlackSwan::RegisterComponent(String name, int (*get)(), bool (*set)(int)) {
  Component c;
  c.Name = name;
  c.Get = get;
  c.Set = set;
  
  _amountOfComponents++;
  _components[_amountOfComponents] = c;

  return c;
};

Component BlackSwan::GetComponent(String name){
  for(int i = 0; i <= _amountOfComponents; ++i) {
    if(_components[i].Name == name){
      return _components[i];
    }
  }
}

void BlackSwan::ComponentValueChange(Component c, int newValue){
  // Call webclient (c->Name, newValue)
}
