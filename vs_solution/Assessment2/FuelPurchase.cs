using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        public double getFuelEconomy()
        {
            return _fuelEconomy;
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

        public void purchaseFuel(int vehicleId, double quantity, double price)
        {
            List<Service> serviceList = Service.serviceList;
            serviceList.Add(new Service(vehicleId));

            JsonData.Save(serviceList);
        }

        public static List<FuelPurchase> Load()
        {
            return JsonData.Load<FuelPurchase>();
        }
    }
}
