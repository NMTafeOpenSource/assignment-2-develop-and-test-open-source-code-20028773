using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment2
{
    public class Service
    {
        const double SERVICE_KILOMETER_LIMIT = 10000;

        public double lastServiceOdometerKm { get; set; }
        public int serviceCount { get; set; }
        public DateTime lastServiceDate { get; set; }
        public int vehicleId { get; set; }

        private static List<Service> _serviceList { get { return Load(); } }
        [JsonIgnore]
        public static List<Service> serviceList { get { return _serviceList; } }

        public Service() { }

        public Service(int vehicleId)
        {
            double odometer = Vehicle.vehicleList.Where(x => x.Id == vehicleId).Select(f => f.OdometerReading).FirstOrDefault();

            this.vehicleId = vehicleId;
            lastServiceOdometerKm = odometer;
            serviceCount = GetServiceCount() + 1;
            lastServiceDate = DateTime.Now;
        }

        public static double GetKmSinceLastService(Vehicle v)
        {
            return (v.OdometerReading - serviceList.Where(x => x.vehicleId == v.Id).LastOrDefault().lastServiceOdometerKm);
        }

        // return the last service
        public double getLastServiceOdometerKm()
        {
            return lastServiceOdometerKm;
        }

        /**
         * The function recordService expects the total distance traveled by the car, 
         * saves it and increase serviceCount.
         * @param distance 
         */
        public static void recordService(int vehicleId)
        {
            List<Service> sList = serviceList;
            sList.Add(new Service(vehicleId));

            JsonData.Save(sList);
        }

        // return how many services the car has had
        public static int StaticGetServiceCount(int vId)
        {
            return new Service().GetServiceCount(vId);
        }

        public int GetServiceCount(int vId = 0)
        {
            var count = 0;

            var sList = serviceList.Where(x => x.vehicleId == ((vId == 0) ? vehicleId : vId)).ToList();

            if (sList.Count > 0)
            {
                count = sList.Max(m => m.serviceCount);
            }

            return count;
        }

        /**
         * Calculates the total services by dividing kilometers by
         * {@link #SERVICE_KILOMETER_LIMIT} and floors the value. 
         * 
         * @return the number of services needed per SERVICE_KILOMETER_LIMIT
         */
        public int getTotalScheduledServices()
        {
            return (int)Math.Floor(lastServiceOdometerKm / SERVICE_KILOMETER_LIMIT);
        }

        public static bool isVehicleDueToService(int vehicleId)
        {
            double nextOdoService = SERVICE_KILOMETER_LIMIT;

            double actualOdo = Vehicle.vehicleList.Where(x => x.Id == vehicleId).Select(x => x.OdometerReading).FirstOrDefault();

            List<Service> sList = serviceList.Where(x => x.vehicleId == vehicleId).ToList();

            if (sList.Count > 0)
            {
                nextOdoService += sList.Max(x => x.lastServiceOdometerKm);
            }

            return (actualOdo > nextOdoService);
        }

        public static List<Service> Load()
        {
            return JsonData.Load<Service>();
        }
    }
}
