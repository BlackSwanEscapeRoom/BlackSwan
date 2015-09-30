using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSwan.WinForm
{
    static class Program
    {
        public static ComponentsPanel ComponentsPanel;

        public static List<Arduino> Arduinos = new List<Arduino>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ComponentsPanel = new ComponentsPanel();
            
            Application.Run(ComponentsPanel);
        }
    }
}
