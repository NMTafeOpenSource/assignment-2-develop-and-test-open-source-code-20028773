using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment2
{
    public class Rental
    {
        public int Id { get; set; }
        public int vehicleId { get; set; }
        public string customerName { get; set; }
        public type rentType { get; set; }
        public double startOdometer { get; set; }
        public double endOdometer { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string notes { get; set; }
        public double totalPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public string vehicleDescription
        {
            get
            {
                var sAux = "";

                if (Vehicle.vehicleList != null)
                {
                    sAux = Vehicle.vehicleList.Where(x => x.Id == vehicleId).Select(f => f.Manufacturer + " - " + f.Model).FirstOrDefault();
                }

                return sAux;
            }
        }

        [JsonIgnore]
        public double travelledDistance
        {
            get
            {
                return (endOdometer - startOdometer);
            }
        }

        private static List<Rental> _rentalList { get { return Load(); } }

        [JsonIgnore]
        public static List<Rental> rentalList { get { return _rentalList; } }

        public enum type
        {
            Day,
            KM
        }

        public Rental() { }

        public Rental(int id, int vehicleId, string customerName, type rentType, double startOdometer, double endOdometer, DateTime startDate, DateTime? endDate, string notes, double totalPrice)
        {
            this.Id = id;
            this.vehicleId = vehicleId;
            this.customerName = customerName;
            this.rentType = rentType;
            this.startOdometer = startOdometer;
            this.endOdometer = endOdometer;
            this.startDate = startDate;
            this.endDate = endDate;
            this.notes = notes;
            this.totalPrice = totalPrice;
            this.ModifiedDate = DateTime.Now;
        }

        public static void AddRental(int vehicleId, string customerName, type rentType, double startOdometer, DateTime startDate, DateTime? endDate, string notes)
        {
            List<Rental> rentalList = _rentalList;
            rentalList.Add(new Rental((rentalList.Count > 0 ? rentalList.Last().Id + 1 : 1), vehicleId, customerName, rentType, startOdometer, 0, startDate, endDate, notes, 0));
            JsonData.Save(rentalList);
        }

        public static string FinalizeRental(int rentalId, double endOdometer, DateTime endDate, string notes)
        {
            List<Rental> rentalList = _rentalList;

            Rental r = rentalList.Where(x => x.Id == rentalId).FirstOrDefault();

            string sMessage = Vehicle.UpdateOdometer(r.vehicleId, endOdometer);

            if (!string.IsNullOrEmpty(sMessage))
            {
                return sMessage;
            }

            var totalPrice = r.rentType == type.KM
                            ? endOdometer - r.startOdometer
                            : ((endDate - r.startDate).Days > 0 ? (endDate - r.startDate).Days : 1) * 100;

            r.endOdometer = endOdometer;
            r.endDate = endDate;
            r.notes = notes;
            r.totalPrice = totalPrice;
            r.ModifiedDate = DateTime.Now;

            rentalList.ToArray().SetValue(r, 0);

            JsonData.Save(rentalList);

            return "";
        }

        public static double GetTotalRevenue(int vehicheId)
        {
            return rentalList.Where(x => x.vehicleId == vehicheId).Sum(t => t.totalPrice);
        }

        public static List<Vehicle> GetAvailableVehicles()
        {
            return Vehicle.vehicleList.Where(x => x.Status == Vehicle.statusType.Available).ToList();
        }

        public static List<Rental> Load()
        {
            return JsonData.Load<Rental>();
        }
    }
}
