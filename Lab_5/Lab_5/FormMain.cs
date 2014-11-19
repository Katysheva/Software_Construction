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
        Component c;
        public FormMain()
        {
            InitializeComponent();
        }

        public void Action()
        {
            c = new Node();
            c.Add(new Leaf());
            c.Add(new Leaf());
            c.Add(new Leaf());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = pictureBoxTree.CreateGraphics();
            Action();
            c.Show(g, 0, 0);
            //for (int i = 0; i < 20; i++)
            //{
            //    c.DrawElement(g, i);
            //}
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
