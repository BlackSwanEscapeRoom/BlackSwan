using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private void ComponentsPanel_Load(object sender, EventArgs e)
        {
            var cph = new ComponentChangeHandler();

            componentChanges.Text += "Knopje 1 staat nu aan" + Environment.NewLine;
            componentChanges.Text += "Knopje 1 staat nu uit" + Environment.NewLine;
            componentChanges.Text += "Knopje 3 staat nu uit" + Environment.NewLine;
        }

        private async void connectArduino_Click(object sender, EventArgs e)
        {
            var ip = ipAddress.Text;

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + ip);

            var response = await client.GetStringAsync("/meta");
            var arduino = JsonConvert.DeserializeObject<Arduino>(response);

            foreach (var item in arduino.Components)
            {
                componentsView.Items.Add(item.Name);
            }

            ComponentChange("Connected" + Environment.NewLine +
                "Message send" + Environment.NewLine +
                "Host: " + ip);
        }
    }
}
