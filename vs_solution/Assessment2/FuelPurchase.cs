using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment2
{
    public class FuelPurchase
    {
        private double _fuelEconomy;
        private double _litres = 0;
        private double _cost = 0;

        public double odometerReading { get; set; }
        public int vehicleId { get; set; }
        public DateTime purchaseDate { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }


        private static List<FuelPurchase> _fuelList { get { return Load(); } }
        [JsonIgnore]
        public static List<FuelPurchase> fuelList { get { return _fuelList; } }

        public static double GetFuelEconomy(int vehicheId)
        {
            var list = _fuelList.Where(x => x.vehicleId == vehicheId).ToList();

            double totalFuel = 0.0;
            double totalKM = 0.0;

            if (list.Count > 0)
            {
                totalFuel = list.Sum(s => s.quantity);
                totalKM = list.Max(m => m.odometerReading) - list.Min(m => m.odometerReading);
            }

            return totalKM / totalFuel;
            //return this.cost / this.litres;
        }

        public double getFuel()
        {
            return _litres;
        }

        public void setFuelEconomy(double fuelEconomy)
        {
            _fuelEconomy = fuelEconomy;
        }

        public void purchaseFuel(double amount, double price)
        {
            _litres += amount;
            _cost += price;
        }


        public FuelPurchase(int vehicleId, double odometer, double quantity, double price)
        {
            this.vehicleId = vehicleId;
            this.odometerReading = odometer;
            this.quantity = quantity;
            this.price = price;
            this.purchaseDate = DateTime.Now;
        }

        public static string AddPurchaseFuel(Vehicle vehicle, double odometer, double quantity, double price)
        {
            if (vehicle.TankCapacity < quantity)
            {
                return "Quantity is higher than tank capacity";
            }

            string sMessage = Vehicle.UpdateOdometer(vehicle.Id, odometer);

            if (!string.IsNullOrEmpty(sMessage))
            {
                return sMessage;
            }

            List<FuelPurchase> fList = _fuelList;
            fList.Add(new FuelPurchase(vehicle.Id, odometer, quantity, price));

            JsonData.Save(fList);

            return "";
        }

        public static List<FuelPurchase> Load()
        {
            return JsonData.Load<FuelPurchase>();
        }
    }
}
