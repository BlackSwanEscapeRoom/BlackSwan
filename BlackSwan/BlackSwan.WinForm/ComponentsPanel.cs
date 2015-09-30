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
            listView1.Items.Add("test");
            listView1.Items.Add("test2");
            listView1.Items.Add("test3");
            listView1.Items.Add("test4");
            listView1.Items.Add("test5");
        }
    }
}
