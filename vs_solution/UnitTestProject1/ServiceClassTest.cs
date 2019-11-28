using Assessment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ServiceClassTest
    {
        [TestInitialize]
        public void Initialize()
        {
            TestClass.initializeFiles();
        }

        [TestMethod]
        public void recordService_Test()
        {
            var listCountBefore = Service.serviceList.Count;

            Service.recordService(TestClass.v.Id);

            var listCountAfter = Service.serviceList.Count;

            Assert.AreEqual(listCountBefore + 1, listCountAfter);
        }

        [TestMethod]
        public void getKmSinceLastService_Test()
        {
            var result = Service.GetKmSinceLastService(TestClass.v);

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void getKmSinceLastService_Test2()
        {
            Vehicle.UpdateOdometer(TestClass.v.Id, TestClass.v.OdometerReading + 1000);

            TestClass.updateTestVehicle();

            var result = Service.GetKmSinceLastService(TestClass.v);

            Assert.AreEqual(result, 1000);
        }

        [TestMethod]
        public void getServiceCount_Test()
        {
            var result = new Service().GetServiceCount(TestClass.v.Id);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void getServiceCount_Test2()
        {
            Service.recordService(TestClass.v.Id);

            var result = new Service().GetServiceCount(TestClass.v.Id);

            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void isVehicleDueToService_Test()
        {
            Service.recordService(TestClass.v.Id);

            var result = Service.isVehicleDueToService(TestClass.v.Id);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void isVehicleDueToService_Test2()
        {
            Vehicle.UpdateOdometer(TestClass.v.Id, TestClass.v.OdometerReading + 11000);

            var result = Service.isVehicleDueToService(TestClass.v.Id);

            Assert.AreEqual(result, true);
        }
    }
}
