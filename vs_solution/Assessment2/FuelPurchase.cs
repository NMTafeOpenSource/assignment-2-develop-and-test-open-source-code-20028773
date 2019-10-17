namespace Assessment2
{
    public class FuelPurchase
    {
        private double _fuelEconomy;
        private double _litres = 0;
        private double _cost = 0;

        public double getFuelEconomy()
        {
            return _fuelEconomy;

            //return this.cost / this.litres;
        }

        public double getFuel()
        {
            return _litres;
        }

        public void setFuelEconomy(double fuelEconomy)
        {
            _fuelEconomy = fuelEconomy;
        }
        public void purchaseFuel(double amount, double price)
        {
            _litres += amount;
            _cost += price;
        }
    }
}
