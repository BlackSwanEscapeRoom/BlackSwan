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
            Text = string.Format("Informatie van component: {0}", name);
        }

        private void setComponentValue_Click(object sender, EventArgs e)
        {
            var componentName = Text;
            var value = componentValue.Text;

           // var httpClient = new HttpClient();
           // httpClient.BaseAddress = "";
        }
    }
}
