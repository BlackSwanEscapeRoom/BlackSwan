using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace BlackSwan.WinForm
{
    public partial class ComponentsPanel : Form
    {
        public ComponentsPanel()
        {
            InitializeComponent();
        }

        public void ComponentChange(string s)
        {
            Func<int> del = delegate ()
            {
                componentChanges.AppendText(s + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }

        public void UpdateComponentsView()
        {
            componentsView.Items.Clear();
            foreach (var arduino in Program.Arduinos)
            {
                var group = new ListViewGroup(arduino.Ip);
                foreach (var component in arduino.Components)
                {
                    var item = new ListViewItem(component.Name.TrimStart('/') + component.Value.ToString(), group);
                    componentsView.Items.Add(item);
                }
            }
        }

        private void ComponentsPanel_Load(object sender, EventArgs e)
        {
            var cph = new ComponentChangeHandler();
            ipAddress.Text = "192.168.1.177";
        }

        private void connectArduino_Click(object sender, EventArgs e)
        {
            var ip = ipAddress.Text;
            ComponentCommunicator.RegisterArduino(ip);
        }

        private void componentsView_DoubleClick(object sender, EventArgs e)
        {
            var componentInfo = new ComponentInfo();
            componentInfo.Show(componentsView.SelectedItems[0].SubItems[0].Text);
        }      
    }
}
