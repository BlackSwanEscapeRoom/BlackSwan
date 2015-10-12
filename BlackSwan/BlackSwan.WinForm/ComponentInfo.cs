using System;
using System.Net.Http;
using System.Windows.Forms;

namespace BlackSwan.WinForm
{
    public partial class ComponentInfo : Form
    {
        public ComponentInfo()
        {
            InitializeComponent();
        }

        public void Show(string name)
        {
            Show();
            Text = $"Informatie van component: {name}";
        }

        private void setComponentValue_Click(object sender, EventArgs e)
        {
            var componentName = Text;
            var value = componentValue.Text;

            ComponentCommunicator.UpdateComponentValue("192.168.1.177", "/led", int.Parse(value));
        }
    }
}
