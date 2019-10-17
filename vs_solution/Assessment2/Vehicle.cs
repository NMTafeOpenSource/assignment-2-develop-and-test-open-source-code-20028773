using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    public class Vehicle
    {
        private string _manufacturer;
        private string _model;
        private int _makeYear;
        private string _registrationNumber;
        private double _odometerReading;
        private double _tankCapacity;
        //  add Registration Number 
        //  add variable for OdometerReading (in KM), 
        //  add variable for TankCapacity (in litres)

        private FuelPurchase fuelPurchase;

        /**
         * Class constructor specifying name of make (manufacturer), model and year
         * of make.
         * @param manufacturer
         * @param model
         * @param makeYear
         */
        public Vehicle(string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            _manufacturer = manufacturer;
            _model = model;
            _makeYear = makeYear;
            _registrationNumber = registrationNumber;
            _odometerReading = odometerReading;
            _tankCapacity = tankCapacity;

            fuelPurchase = new FuelPurchase();
        }

        /**
         * Prints details for {@link Vehicle}
         */
        public string printDetails()
        {
            return string.Format("Vehicle: {0} {1} {2} {3} {4} {5}", _makeYear, _manufacturer, _model, _registrationNumber, _odometerReading, _tankCapacity);
        }


        // TODO Create an addKilometers method which takes a parameter for distance travelled 
        // and adds it to the odometer reading. 
        public void addKilometers(double distance)
        {
            _odometerReading += distance;
        }


        // adds fuel to the car
        public void addFuel(double litres, double price)
        {
            fuelPurchase.purchaseFuel(litres, price);
        }

    }
}
