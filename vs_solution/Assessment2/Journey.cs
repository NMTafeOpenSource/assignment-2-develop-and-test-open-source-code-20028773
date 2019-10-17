namespace Assessment2
{
    public class Journey
    {
        private double _kilometers;

        /**
         * Class constructor
         */
        public Journey()
        {
            _kilometers = 0;
        }

        /** 
         * Appends the distance parameter to {@link #kilometers}
         * @param kilometers the distance traveled 
         */
        public void addKilometers(double kilometers)
        {
            _kilometers += kilometers;
        }
               
        /**
         * Getter method for total Kilometers traveled in this journey.
         * @return {@link #kilometers}
         */
        public double getKilometers()
        {
            return _kilometers;
        }
    }
}
