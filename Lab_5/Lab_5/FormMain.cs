using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class FormMain : Form
    {
        private Node[] nodes;
        private Leaf[] leafs;
        public FormMain()
        {
            InitializeComponent();
        }

        public void Init()
        {
            nodes = new Node[5];
            leafs = new Leaf[5];
            leafs = leafs.Select((leaf) => leaf = new Leaf()).ToArray();
            nodes = nodes.Select((node) => node = new Node()).ToArray();

            nodes[3].Add(leafs[1]);
            nodes[4].Add(leafs[2]);

            nodes[2].Add(nodes[3]);
            nodes[2].Add(nodes[4]);

            nodes[1].Add(leafs[0]);
            nodes[1].Add(nodes[2]);
            nodes[1].Add(leafs[3]);

            nodes[0].Add(nodes[1]);
            nodes[0].Add(leafs[4]);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBoxTree.CreateGraphics();
            Init();
            this.Text = (nodes[0].Show(g, 0, 0) + 1).ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
