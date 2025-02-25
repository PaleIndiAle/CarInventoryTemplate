using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string year = yearInput.Text;
            string make = makeInput.Text;
            string colour = colourInput.Text;
            string mileage = mileageInput.Text;

            Car newCar = new Car(year, make, colour, mileage);
            cars.Add(newCar);

            yearInput.Text = makeInput.Text = colourInput.Text = mileageInput.Text = "";
            yearInput.Focus();

            outputLabel.Text = "";

            for (int i = 0; i < cars.Count; i++)
            {
                outputLabel.Text += $"{cars[i].year} - {cars[i].make}, {cars[i].colour}, {cars[i].mileage} \n";
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string makeRemove = makeInput.Text;

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].make == makeRemove)
                {
                    outputLabel.Text = $"{makeRemove} is now removed";
                    cars.RemoveAt(i);
                }
            }
        }
    }
}
