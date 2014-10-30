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

            var d = new Node();
            d.Add(new Leaf().Color("Green").Shape("Square"));
            d.Add(new Leaf());

            c.Add(d);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action();
        }
    }
}
