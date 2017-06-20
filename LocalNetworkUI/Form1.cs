using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkUI.UserClasses;
using LocalNetworkUI.Properties;

namespace LocalNetworkUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Device CreateNet()
        {
            Device root = new Router(0, Resources.router_, "192.168.0.1");
            Device sw1 = new Switch(1, Resources.switch_);
            Device sw2 = new Switch(2, Resources.switch_);
            Device pc1_1 = new Computer(11, Resources.computer_, "192.168.0.11");
            Device pc1_2 = new Computer(12, Resources.computer_, "192.168.0.12");
            Device pc2_1 = new Computer(21, Resources.computer_, "192.168.0.21");
            Device pc2_2 = new Computer(22, Resources.computer_, "192.168.0.22");

            root.Link.Add(sw1);
            root.Link.Add(sw2);
            sw1.Link.Add(pc1_1);
            sw1.Link.Add(pc1_2);
            sw2.Link.Add(pc2_1);
            sw2.Link.Add(pc2_2);

            Device sw3 = new Switch(3, Resources.switch_);
            Device sw4 = new Switch(4, Resources.switch_);
            Device pc3_1 = new Computer(31, Resources.computer_, "192.168.0.31");
            Device pc3_2 = new Computer(32, Resources.computer_, "192.168.0.32");
            Device pc4_1 = new Computer(41, Resources.computer_, "192.168.0.41");
            Device pc4_2 = new Computer(42, Resources.computer_, "192.168.0.42");

            sw1.Link.Add(sw3);
            sw3.Link.Add(sw4);
            sw3.Link.Add(pc3_1);
            sw3.Link.Add(pc3_2);
            sw4.Link.Add(pc4_1);
            sw4.Link.Add(pc4_2);

            return root;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Net = CreateNet();
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(Net.ToString()));
            TreeNode treeRoot = new TreeNode();
            Device deviceRoot = Net;
            treeRoot = treeView1.Nodes[0];

            GenerateTree(treeRoot, deviceRoot);
            treeView1.ExpandAll();
        }

        private static void GenerateTree(TreeNode treeRoot, Device deviceRoot)
        {
            for (int i = 0; i < deviceRoot.Link.Count; ++i)
            {
                treeRoot.Nodes.Add(new TreeNode(deviceRoot.Link[i].ToString()));
                GenerateTree(treeRoot.Nodes[i], deviceRoot.Link[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Net == null)
            {
                MessageBox.Show("Oh YOU ARE KHITRIY ZHOPA! WE WILL ESCHO TEB'YA POYMAEM!");
            }
            else
            MessageBox.Show("VOT VAM BUTILOCHKA, PROHODITE, PRISAZHIVAYTES'");
        }
    }
}
