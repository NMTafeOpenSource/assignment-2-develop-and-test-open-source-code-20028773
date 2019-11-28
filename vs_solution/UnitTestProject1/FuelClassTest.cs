using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class FuelClassTest
    {
        [TestInitialize]
        public void Initialize()
        {
            TestClass.initializeFiles();
        }

        [TestMethod]
        public void addPurchaseFuel_Test()
        {
            var listCountBefore = FuelPurchase.fuelList.Count;

            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 200, 45, 1.3);

            var listCountAfter = FuelPurchase.fuelList.Count;

            Assert.AreEqual(listCountBefore + 1, listCountAfter);
        }

        [TestMethod]
        public void addPurchaseFuel_Test2()
        {
            string sAux = FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 200, 55, 1.3);

            Assert.AreEqual(sAux, "Quantity is higher than tank capacity");
        }

        [TestMethod]
        public void addPurchaseFuel_Test3()
        {
            string sAux = FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading - 200, 45, 1.3);

            Assert.AreEqual(sAux, "New Odometer is lower than actual");
        }

        [TestMethod]
        public void addPurchaseFuel_Test4()
        {
            string sAux = FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 200, 45, 1.3);

            Assert.AreEqual(sAux, "");
        }

        [TestMethod]
        public void getFuelEconomy_Test()
        {
            double result = FuelPurchase.GetFuelEconomy(TestClass.v.Id);

            Assert.AreEqual(result, double.NaN);
        }

        [TestMethod]
        public void getFuelEconomy_Test2()
        {
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 200, 50, 1.5);
            TestClass.updateTestVehicle();
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 400, 50, 1.5);
            TestClass.updateTestVehicle();
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 400, 50, 1.5);
            TestClass.updateTestVehicle();
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 400, 50, 1.5);
            TestClass.updateTestVehicle();
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 400, 50, 1.5);

            double result = FuelPurchase.GetFuelEconomy(TestClass.v.Id);

            Assert.AreEqual(result, 6.4);
        }

        [TestMethod]
        public void getFuelEconomy_Test3()
        {
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 200, 25, 1.5);
            TestClass.updateTestVehicle();
            FuelPurchase.AddPurchaseFuel(TestClass.v, TestClass.v.OdometerReading + 400, 25, 1.5);

            double result = FuelPurchase.GetFuelEconomy(TestClass.v.Id);

            Assert.AreEqual(result, 8);
        }
    }
}
