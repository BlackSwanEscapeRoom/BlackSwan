using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackSwan.WinForm
{
    class Arduino
    {
        public IPAddress Ip { get; set; }
        public int RoomNumber { get; set; }
        public IEnumerable<Component> Components { get; set; }
    }
}
