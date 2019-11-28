using Assessment2;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    public class TestClass
    {
        public static Vehicle v;

        public static void initializeFiles()
        {
            string sAux = JsonData.GetFileNamePath("Vehicle");

            if (File.Exists(sAux))
                File.Delete(sAux);

            sAux = JsonData.GetFileNamePath("Service");

            if (File.Exists(sAux))
                File.Delete(sAux);

            sAux = JsonData.GetFileNamePath("Rental");

            if (File.Exists(sAux))
                File.Delete(sAux);

            sAux = JsonData.GetFileNamePath("FuelPurchase");

            if (File.Exists(sAux))
                File.Delete(sAux);

            addTestVehicle();

            updateTestVehicle();
        }

        public static void addTestVehicle()
        {
            Vehicle.AddVehicle("TestMake", "testmodel", 2019, "1DAS123", 1000, 50);
        }
        public static void updateTestVehicle()
        {
            v = Vehicle.vehicleList.Where(x => x.Manufacturer.Contains("TestMake")).FirstOrDefault();
        }
        public static void deleteTestVehicle()
        {
            Vehicle.DeleteVehicle(v);
        }
    }
}
