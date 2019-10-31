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
        public DateTime endDate { get; set; }
        public string notes { get; set; }
        public double totalPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string startDateToString { get { return startDate.ToString("dd/MM/yyyy"); } }

        public string vehicleDescription
        {
            get
            {
                var sAux = "";

                if (MainWindow.vehicleList != null)
                {
                    sAux = MainWindow.vehicleList.Where(x => x.Id == vehicleId).Select(f => f.Manufacturer + " - " + f.Model).FirstOrDefault();
                }

                return sAux;
            }
        }

        public enum type
        {
            Day,
            KM
        }

        public Rental() { }

        public Rental(int id, int vehicleId, string customerName, type rentType, double startOdometer, double endOdometer, DateTime startDate, DateTime endDate, string notes, double totalPrice)
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

        public void AddRental(List<Rental> rentalList, int vehicleId, string customerName, type rentType, double startOdometer, double endOdometer, DateTime startDate, DateTime endDate, string notes, double totalPrice)
        {
            rentalList.Add(new Rental((rentalList.Count > 0 ? rentalList.Last().Id + 1 : 1), vehicleId, customerName, rentType, startOdometer, endOdometer, startDate, endDate, notes, totalPrice));
            JsonData.Save(rentalList);
        }

        public void FinalizeRental(List<Rental> rentalList, int id, double endOdometer, DateTime endDate, string notes)
        {
            Rental r = rentalList.Where(x => x.Id == id).FirstOrDefault();

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

            new Vehicle().UpdateOdometer(MainWindow.vehicleList, r.vehicleId, endOdometer);
        }

        public static List<Rental> LoadRental()
        {
            return JsonData.Load<Rental>();
        }
    }
}
