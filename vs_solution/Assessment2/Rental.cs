using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment2
{
    public class Rental
    {
        public int Id { get; set; }
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public type rentType { get; set; }
        public double startOdometer { get; set; }
        public double endOdometer { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string notes { get; set; }
        public double totalPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

        public enum type
        {
            day,
            km
        }

        public Rental() { }

        public Rental(int id,int vehicleId, int customerId, type rentType, double startOdometer, double endOdometer, DateTime startDate, DateTime endDate, string notes, double totalPrice)
        {
            this.Id = id;
            this.vehicleId = vehicleId;
            this.customerId = customerId;
            this.rentType = rentType;
            this.startOdometer = startOdometer;
            this.endOdometer = endOdometer;
            this.startDate = startDate;
            this.endDate = endDate;
            this.notes = notes;
            this.totalPrice = totalPrice;
            this.ModifiedDate = DateTime.Now;
        }

        public void AddRental(List<Rental> rentalList, int vehicleId, int customerId, type rentType, double startOdometer, double endOdometer, DateTime startDate, DateTime endDate, string notes, double totalPrice)
        {
            rentalList.Add(new Rental((rentalList.Count > 0 ? rentalList.Last().Id + 1 : 1), vehicleId, customerId, rentType, startOdometer, endOdometer, startDate, endDate, notes, totalPrice));
            JsonData.Save(rentalList);
        }

        public static List<Rental> LoadRental()
        {
            return JsonData.Load<Rental>();
        }
    }
}
