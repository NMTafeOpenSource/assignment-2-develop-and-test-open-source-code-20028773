using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using static Assessment2.Vehicle;

namespace Assessment2
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MakeYear { get; set; }
        public string RegistrationNumber { get; set; }
        public double OdometerReading { get; set; }
        public double TankCapacity { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public string vehicleDescription
        {
            get
            {
                return Manufacturer + " - " + Model;
            }
        }

        [JsonIgnore]
        public statusType Status
        {
            get
            {
                statusType status = statusType.Available;

                if (Service.isVehicleDueToService(Id))
                {
                    status = statusType.NeedService;
                    btnServiceVisibility = Visibility.Visible;
                }
                else
                {
                    var nAux = Rental.rentalList.Where(x => x.vehicleId == Id && x.totalPrice == 0).ToList().Count;

                    if (nAux > 0)
                    {
                        status = statusType.Rented;
                    }
                }

                return status;
            }
        }

        [JsonIgnore]
        public string StatusText
        {
            get
            {
                return Status.EnumText();
            }
        }

        public enum statusType
        {
            Available,
            Rented,
            NeedService
        }

        private Visibility _btnServiceVisibility = Visibility.Hidden;

        [JsonIgnore]
        public Visibility btnServiceVisibility
        {
            get
            {
                return _btnServiceVisibility;
            }
            set
            {
                _btnServiceVisibility = value;
            }
        }

        private static List<Vehicle> _vehicleList { get { return Load(); } }

        [JsonIgnore]
        public static List<Vehicle> vehicleList { get { return _vehicleList; } }

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
        }
        
        public static void AddVehicle(string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            List<Vehicle> vehicleList = _vehicleList;

            var vId = (vehicleList.Count > 0 ? vehicleList.Last().Id + 1 : 1);

            vehicleList.Add(new Vehicle(vId, manufacturer, model, makeYear, registrationNumber, odometerReading, tankCapacity));

            JsonData.Save(vehicleList);

            new Service().recordService(vId);
        }

        public static void EditVehicle(int id, string manufacturer, string model, int makeYear, string registrationNumber, double odometerReading, double tankCapacity)
        {
            List<Vehicle> vehicleList = _vehicleList;

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

        public static string UpdateOdometer(int vehicleId, double newOdometerReading)
        {
            List<Vehicle> vehicleList = _vehicleList;

            Vehicle v = vehicleList.Where(x => x.Id == vehicleId).FirstOrDefault();

            if (newOdometerReading < v.OdometerReading)
            {
                return "New Odometer is lower than actual";
            }

            v.OdometerReading = newOdometerReading;
            v.ModifiedDate = DateTime.Now;

            vehicleList.ToArray().SetValue(v, 0);

            JsonData.Save(vehicleList);

            return "";
        }

        public static void DeleteVehicle(Vehicle v)
        {
            List<Vehicle> vehicleList = _vehicleList;
            vehicleList.Remove(vehicleList.Where(x => x.Id == v.Id).FirstOrDefault());
            JsonData.Save(vehicleList);
        }

        public static List<Vehicle> Load()
        {
            return JsonData.Load<Vehicle>();
        }

        /**
         * Prints details for {@link Vehicle}
         */
        public static string printDetails(Vehicle v)
        {
            StringBuilder sAux2 = new StringBuilder();
            sAux2.AppendFormat("Vehicle: {0} {1} {2}", v.Manufacturer, v.Model, v.MakeYear);
            sAux2.AppendLine();
            sAux2.AppendFormat("Registration No: {0}", v.RegistrationNumber);
            sAux2.AppendLine();
            sAux2.AppendFormat("Total services: {0}", Service.StaticGetServiceCount(v.Id));
            sAux2.AppendLine();
            sAux2.AppendFormat("Revenue recorded: {0:C}", Rental.GetTotalRevenue(v.Id));
            sAux2.AppendLine();
            sAux2.AppendFormat("Kilometres since last service: {0:#,###0} km", Service.GetKmSinceLastService(v));
            sAux2.AppendLine();
            sAux2.AppendFormat("Fuel economy: {0:C}", FuelPurchase.GetFuelEconomy(v.Id));
            sAux2.AppendLine();
            sAux2.AppendFormat("Requires a service: {0}", v.Status == statusType.NeedService ? "Yes" : "No");
            sAux2.AppendLine();

            return sAux2.ToString();
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
            //fuelPurchase.purchaseFuel(litres, price);
        }

    }

    public static class ExtensionMethods
    {
        public static string EnumText(this statusType e)
        {
            switch (e)
            {
                case statusType.NeedService:
                    return "Needs Service";
            }
            return e.ToString();
        }
    }

    ///TODO
    ///DONT LET PURCHASE FUEL IF THE QUANTITY > TANK
    ///CREATE FORM VALIDATIONS FOR ALL FORMS
    ///CREATE HISTORY PAGE FOR VEHICLE WITH SERVICES, FUEL AND RENT
    ///TIDE THE FORMS
    ///CORRECT THE FUEL ECONOMY DISPLAY

}
