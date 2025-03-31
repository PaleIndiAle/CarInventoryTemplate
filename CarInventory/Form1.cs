using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();
            outputLabel.Text = "";
            loadDB();
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveDB();
        }

        public void loadDB()
        {
            XmlReader reader = XmlReader.Create("carData.xml", null);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    string year = reader.ReadString();

                    reader.ReadToNextSibling("make");
                    string make = reader.ReadString();

                    reader.ReadToNextSibling("colour");
                    string colour = reader.ReadString();

                    reader.ReadToNextSibling("mileage");
                    string mileage = reader.ReadString();

                    Car newCar = new Car(year, make, colour, mileage);
                    cars.Add(newCar);
                }
            }

            reader.Close();
        }

        public void saveDB()
        {
            XmlWriter writer = XmlWriter.Create("carData.xml", null);

            writer.WriteStartElement("Car");

            foreach (Car c in cars)
            {
                writer.WriteStartElement("Car");

                writer.WriteElementString("year", c.year);
                writer.WriteElementString("make", c.make);
                writer.WriteElementString("colour", c.colour);
                writer.WriteElementString("mileage", c.mileage);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
        }
    }
}
