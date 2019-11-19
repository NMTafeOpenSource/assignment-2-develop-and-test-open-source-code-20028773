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
        private string sManufacturer;
        private string sModel;
        private int nYear;
        private string sRegistration;
        private double dOdometer;
        private double dTank;


        public Form_Vehicle()
        {
            InitializeComponent();

            txtManufacturer.Focus();
            this.Title = "Add Vehicle";
        }

        public Form_Vehicle(Vehicle updateVehicle)
        {
            InitializeComponent();

            this.Title = "Edit Vehicle";

            txtManufacturer.Focus();

            id = updateVehicle.Id;

            txtManufacturer.Text = updateVehicle.Manufacturer;
            txtModel.Text = updateVehicle.Model;
            txtYear.Text = updateVehicle.MakeYear.ToString();
            txtRegistration.Text = updateVehicle.RegistrationNumber;
            txtOdometer.Text = updateVehicle.OdometerReading.ToString();
            txtTank.Text = updateVehicle.TankCapacity.ToString();
        }

        public string validate()
        {
            sManufacturer = txtManufacturer.Text.Replace("_", "");

            if (string.IsNullOrEmpty(sManufacturer))
            {
                return "Manufacturer Required";
            }

            sModel = txtModel.Text.Replace("_", "");

            if (string.IsNullOrEmpty(sModel))
            {
                return "Model Required";
            }

            try
            {
                nYear = int.Parse(txtYear.Text.Replace("_", ""));

                if (nYear < 1900 || nYear > 2030)
                {
                    return "Invalid Year";
                }
            }
            catch
            {
                return "Invalid Year";
            }

            sRegistration = txtRegistration.Text.Replace("_", "");

            if (string.IsNullOrEmpty(sRegistration))
            {
                return "Registration Required";
            }

            try
            {
                dOdometer = double.Parse(txtOdometer.Text.Replace("_", ""));

                if (dOdometer < 0)
                {
                    return "Invalid Odometer";
                }
            }
            catch
            {
                return "Invalid Odometer";
            }

            try
            {
                dTank = double.Parse(txtTank.Text.Replace("_", ""));

                if (dTank < 0)
                {
                    return "Invalid Tank Capacity";
                }
            }
            catch
            {
                return "Invalid Tank Capacity";
            }

            return "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string sMessage = validate();

            if (string.IsNullOrEmpty(sMessage))
            {
                if (id != 0)
                {
                    Vehicle.EditVehicle(id, sManufacturer, sModel, nYear, sRegistration, dOdometer, dTank);
                }
                else
                {
                    Vehicle.AddVehicle(sManufacturer, sModel, nYear, sRegistration, dOdometer, dTank);
                }

                MessageBox.Show("Vehicle " + (id != 0 ? "Edited" : "Created") + " Successfully!", "Vehicle", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(sMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
