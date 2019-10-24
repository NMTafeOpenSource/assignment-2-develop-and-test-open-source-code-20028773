using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Form_Vehicle : Window
    {
        Vehicle vehicle = new Vehicle();

        private int id = 0;

        public Form_Vehicle()
        {
            InitializeComponent();

            txtManufacturer.Focus();
        }

        public Form_Vehicle(Vehicle updateVehicle)
        {
            InitializeComponent();

            txtManufacturer.Focus();

            id = updateVehicle.Id;

            txtManufacturer.Text = updateVehicle.Manufacturer;
            txtModel.Text = updateVehicle.Model;
            txtYear.Text = updateVehicle.MakeYear.ToString();
            txtRegistration.Text = updateVehicle.RegistrationNumber;
            txtOdometer.Text = updateVehicle.OdometerReading.ToString();
            txtTank.Text = updateVehicle.TankCapacity.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (id != 0)
            {
                vehicle.EditVehicle(MainWindow.vehicleList, id, txtManufacturer.Text, txtModel.Text, int.Parse(txtYear.Text), txtRegistration.Text, double.Parse(txtOdometer.Text), double.Parse(txtTank.Text));
            }
            else
            {
                vehicle.AddVehicle(MainWindow.vehicleList, txtManufacturer.Text, txtModel.Text, int.Parse(txtYear.Text), txtRegistration.Text, double.Parse(txtOdometer.Text), double.Parse(txtTank.Text));
            }

            MessageBox.Show("Vehicle " + (id != 0 ? "Edited" : "Created") + " Successfully!", "Vehicle", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
