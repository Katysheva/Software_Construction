using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6_Observer
{
    public partial class FormMain : Form
    {
        TrafficLights trafficLights;
        List<Car> cars;
        List<FootPassenger> footPasengers;

        public FormMain()
        {
            InitializeComponent();
            InitObjects();
        }

        public void InitObjects()
        {
            trafficLights = new TrafficLights();
            cars = new List<Car>();
            footPasengers = new List<FootPassenger>();
            for (int i = 0; i < 3; i++)
            {
                var newCar = new Car();
                trafficLights.ColorChanged += newCar.React;
                cars.Add(newCar);

                var newPass = new FootPassenger();
                trafficLights.ColorChanged += newPass.React;
                footPasengers.Add(newPass);
            }
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            trafficLights.Color = Color.Red;
            OutputText();
            
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            trafficLights.Color = Color.Yellow;
            OutputText();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            trafficLights.Color = Color.Green;
            OutputText();

        }
        private void OutputText()
        {
            var i = 0;
            label1.Text = "";
            label1.Text += string.Format("Cars:\n");
            foreach (var item in cars)
            {
                i++;
                label1.Text += string.Format("Car {0} - {1}\n", i, item.State);
            }
            i = 0;
            label2.Text = "";
            label2.Text += string.Format("Passengers:\n");
            foreach (var item in footPasengers)
            {
                i++;
                label2.Text += string.Format("Passenger {0} - {1}\n", i, item.State);
            }
        }
    }
}
