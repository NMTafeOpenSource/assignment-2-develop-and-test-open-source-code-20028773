using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    public class Service
    {
        const double SERVICE_KILOMETER_LIMIT = 10000;

        private double _lastServiceOdometerKm = 0;
        private int _serviceCount = 0;
        // TODO add lastServiceDate

        // return the last service
        public double getLastServiceOdometerKm()
        {
            return _lastServiceOdometerKm;
        }

        /**
         * The function recordService expects the total distance traveled by the car, 
         * saves it and increase serviceCount.
         * @param distance 
         */
        public void recordService(int distance)
        {
            _lastServiceOdometerKm = distance;
            _serviceCount++;
        }

        // return how many services the car has had
        public int getServiceCount()
        {
            return _serviceCount;
        }

        /**
         * Calculates the total services by dividing kilometers by
         * {@link #SERVICE_KILOMETER_LIMIT} and floors the value. 
         * 
         * @return the number of services needed per SERVICE_KILOMETER_LIMIT
         */
        public int getTotalScheduledServices()
        {
            return (int)Math.Floor(_lastServiceOdometerKm / SERVICE_KILOMETER_LIMIT);
        }

    }
}
