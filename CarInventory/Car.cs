using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventory
{
    internal class Car
    {
        //class attributes
        public string year, make, colour, mileage;

        //constructor method
        public Car(string _year, string _make, string _colour, string _mileage) 
        { 
            year = _year;
            make = _make;
            colour = _colour;
            mileage = _mileage;
        }
    }
}
