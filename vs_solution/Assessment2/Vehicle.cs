using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment2
{
    public class Vehicle
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private int _makeYear;
        private string _registrationNumber;
        private double _odometerReading;
        private double _tankCapacity;

        public int Id { get { return _id; } set { _id = value; } }
        public string Manufacturer { get { return _manufacturer; } set { _manufacturer = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int MakeYear { get { return _makeYear; } set { _makeYear = value; } }
        public string RegistrationNumber { get { return _registrationNumber; } set { _registrationNumber = value; } }
        public double OdometerReading { get { return _odometerReading; } set { _odometerReading = value; } }
        public double TankCapacity { get { return _tankCapacity; } set { _tankCapacity = value; } }
        public DateTime ModifiedDate { get; set; }

        private FuelPurchase fuelPurchase;

        public Vehicle() { }

        /**
         * Class constructor specifying name of make (manufacturer), model and year
         * of make.
         * @param manufacturer
         * @param model
         * @param makeYear
         */
        private Vehicle(int id, string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            MakeYear = makeYear;
            RegistrationNumber = registrationNumber;
            OdometerReading = odometerReading;
            TankCapacity = tankCapacity;
            ModifiedDate = DateTime.Now;

            fuelPurchase = new FuelPurchase();
        }

        public void AddVehicle(List<Vehicle> vehicleList, string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            vehicleList.Add(new Vehicle((vehicleList.Count > 0 ? vehicleList.Last().Id + 1 : 1), manufacturer, model, makeYear, registrationNumber, odometerReading, tankCapacity));
            JsonData.Save(vehicleList);
        }

        public void EditVehicle(List<Vehicle> vehicleList, int id, string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            Vehicle v = vehicleList.Where(x => x.Id == id).FirstOrDefault();

            v.Manufacturer = manufacturer;
            v.Model = model;
            v.MakeYear = makeYear;
            v.RegistrationNumber = registrationNumber;
            v.OdometerReading = odometerReading;
            v.TankCapacity = tankCapacity;
            v.ModifiedDate = DateTime.Now;

            vehicleList.ToArray().SetValue(v, 0);

            JsonData.Save(vehicleList);
        }

        public static void DeleteVehicle(List<Vehicle> vehicleList, Vehicle v)
        {
            vehicleList.Remove(v);
            JsonData.Save(vehicleList);
        }

        public static List<Vehicle> LoadVehicles()
        {
            return JsonData.Load<Vehicle>();
        }

        /**
         * Prints details for {@link Vehicle}
         */
        public string printDetails()
        {
            return string.Format("Vehicle: {0} {1} {2} {3} {4} {5}", MakeYear, Manufacturer, Model, RegistrationNumber, OdometerReading, TankCapacity);
        }


        // TODO Create an addKilometers method which takes a parameter for distance travelled 
        // and adds it to the odometer reading. 
        public void addKilometers(double distance)
        {
            OdometerReading += distance;
        }

        // adds fuel to the car
        public void addFuel(double litres, double price)
        {
            fuelPurchase.purchaseFuel(litres, price);
        }

    }
}
