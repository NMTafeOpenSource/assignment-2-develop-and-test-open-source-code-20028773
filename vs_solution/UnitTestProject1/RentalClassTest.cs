using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class RentalClassTest
    {
        Rental r;

        [TestInitialize]
        public void Initialize()
        {
            TestClass.initializeFiles();
        }

        [TestMethod]
        public void addRental_Test()
        {
            var listCountBefore = Rental.rentalList.Count;

            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.Day, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            var listCountAfter = Rental.rentalList.Count;

            Assert.AreEqual(listCountBefore + 1, listCountAfter);
        }

        [TestMethod]
        public void finalizeRental_Test()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.Day, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Assert.AreEqual(r.endOdometer, 2000);
            Assert.AreEqual(r.endDate.Value.ToString(), DateTime.Now.AddDays(10).ToString());
        }

        [TestMethod]
        public void getTotalRevenue_PerDay_Test()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.Day, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            double result = Rental.GetTotalRevenue(TestClass.v.Id);

            Assert.AreEqual(result, 1000);
        }

        [TestMethod]
        public void getTotalRevenue_PerKM_Test()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            double result = Rental.GetTotalRevenue(TestClass.v.Id);

            Assert.AreEqual(result, 1000);
        }

        [TestMethod]
        public void getRentalList_Test()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            List<Rental> result = Rental.getRentalList();

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void getRentalList_Test2()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            List<Rental> result = Rental.getRentalList("", true);

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void getRentalList_Test3()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            List<Rental> result = Rental.getRentalList("Koji");

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void getRentalList_Test4()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            List<Rental> result = Rental.getRentalList("Koji", true);

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void GetAvailableVehicles_Test()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            List<Vehicle> result = Rental.GetAvailableVehicles();

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void GetAvailableVehicles_Test2()
        {
            Rental.AddRental(TestClass.v.Id, "Koji Furukawa Test", Rental.type.KM, TestClass.v.OdometerReading, DateTime.Now, null, string.Empty);

            r = Rental.rentalList.Where(x => x.customerName.Contains("Koji Furukawa Test")).FirstOrDefault();

            Rental.FinalizeRental(r.Id, 2000, DateTime.Now.AddDays(10), string.Empty);

            List<Vehicle> result = Rental.GetAvailableVehicles();

            Assert.AreEqual(result.Count, 1);
        }
    }
}
