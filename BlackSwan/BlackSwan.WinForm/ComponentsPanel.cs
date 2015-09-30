using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSwan.WinForm
{
    public partial class ComponentsPanel : Form
    {
        public ComponentsPanel()
        {
            InitializeComponent();
        }

        private void ComponentsPanel_Load(object sender, EventArgs e)
        {
            var cph = new ComponentChangeHandler();

            componentsView.Items.Add("Led");
            componentsView.Items.Add("Led 2");
            componentsView.Items.Add("Led 3");
            componentsView.Items.Add("Led 4");
            componentsView.Items.Add("Led 5");

            componentChanges.Text += "Knopje 1 staat nu aan" + Environment.NewLine;
            componentChanges.Text += "Knopje 1 staat nu uit" + Environment.NewLine;
            componentChanges.Text += "Knopje 3 staat nu uit" + Environment.NewLine;
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
    }
}
