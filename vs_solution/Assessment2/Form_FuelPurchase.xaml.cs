using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_FuelPurchase.xaml
    /// </summary>
    public partial class Form_FuelPurchase : Window
    {
        Vehicle vehicle = new Vehicle();

        public Form_FuelPurchase(Vehicle v)
        {
            InitializeComponent();

            txtVehicle.Text = v.vehicleDescription;
            txtOdometer.Text = v.OdometerReading.ToString();
            vehicle = v;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            FuelPurchase.AddPurchaseFuel(vehicle.Id, double.Parse(txtOdometer.Text), double.Parse(txtQuantity.Text), double.Parse(txtPrice.Text));

            this.Close();
        }
    }
}
