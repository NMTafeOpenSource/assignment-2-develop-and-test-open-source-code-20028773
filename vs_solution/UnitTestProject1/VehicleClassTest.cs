using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class VehicleCLassTest
    {
        [TestInitialize]
        public void Initialize()
        {
            TestClass.initializeFiles();
        }

        [TestMethod]
        public void addVehicle_Test()
        {
            var listCountBefore = Vehicle.vehicleList.Count;

            Vehicle.AddVehicle("TestMake", "testmodel", 2019, "1DAS123", 1000, 50);

            var listCountAfter = Vehicle.vehicleList.Count;

            Assert.AreEqual(listCountBefore + 1, listCountAfter);
        }

        [TestMethod]
        public void deleteVehicle_Test()
        {
            Vehicle.DeleteVehicle(TestClass.v);
        }

        [TestMethod]
        public void editVehicle_Test()
        {
            Vehicle.EditVehicle(TestClass.v.Id, "TestMake1", "testmodel1", 2011, "1DSA333", 1001, 45);

            TestClass.v = Vehicle.vehicleList.Where(x => x.Manufacturer.Contains("TestMake")).FirstOrDefault();

            Assert.AreEqual(TestClass.v.Manufacturer, "TestMake1");
            Assert.AreEqual(TestClass.v.Model, "testmodel1");
            Assert.AreEqual(TestClass.v.MakeYear, 2011);
            Assert.AreEqual(TestClass.v.RegistrationNumber, "1DSA333");
            Assert.AreEqual(TestClass.v.OdometerReading, 1001);
            Assert.AreEqual(TestClass.v.TankCapacity, 45);
        }

        [TestMethod]
        public void updateOdometer_Test()
        {
            string expectedResult = Vehicle.UpdateOdometer(TestClass.v.Id, 2000);

            Assert.AreEqual(expectedResult, "");
        }

        [TestMethod]
        public void updateOdometer_Test2()
        {
            string expectedResult = Vehicle.UpdateOdometer(TestClass.v.Id, 1);

            Assert.AreEqual(expectedResult, "New Odometer is lower than actual");
        }       
    }
}
