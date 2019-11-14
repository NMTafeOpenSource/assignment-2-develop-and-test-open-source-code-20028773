using System;
using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_Rental.xaml
    /// </summary>
    public partial class Form_Rental : Window
    {
        private int vehicleId;
        private int rentalId;
        private double dEndOdometer;
        private DateTime? dtEndDate = null;

        public void initialize()
        {
            InitializeComponent();
            cbRentType.Items.Add(Rental.type.Day);
            cbRentType.Items.Add(Rental.type.KM);
        }

        public Form_Rental()
        {
            initialize();
        }

        public Form_Rental(Rental rental)
        {
            initialize();

            rentalId = rental.Id;
            txtCustomer.Text = rental.customerName;
            txtVehicle.Text = rental.vehicleDescription;
            txtStartOdometer.Text = rental.startOdometer.ToString();
            dpStartDate.Text = rental.startDate.ToString();
            dpEndDate.Text = rental.endDate.ToString();
            txtNotes.Text = rental.notes;
            cbRentType.Text = rental.rentType.ToString();

            btnSave.Content = "Finalize Booking";
            btnSave.Width = 100;
            btnSave.Margin = new Thickness(70, 0, 0, 0);

            dpStartDate.IsEnabled = false;
            txtEndOdometer.IsEnabled = true;
            dpEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public Form_Rental(int vId, string vDescription, double odometer)
        {
            initialize();

            vehicleId = vId;
            txtVehicle.Text = vDescription;
            txtStartOdometer.Text = odometer.ToString();

            dpStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public string validate()
        {
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                return "Customer Required";
            }

            if (cbRentType.SelectedItem == null)
            {
                return "Rent Type Required";
            }

            if (!string.IsNullOrEmpty(dpEndDate.Text))
            {
                DateTime startDate = DateTime.Parse(dpStartDate.Text);
                dtEndDate = DateTime.Parse(dpEndDate.Text);

                if (startDate > dtEndDate)
                {
                    return "Start Date can't be after End Date";
                }
            }

            if (txtEndOdometer.IsEnabled)
            {
                try
                {
                    dEndOdometer = double.Parse(txtEndOdometer.Text.Replace("_", ""));
                }
                catch
                {
                    return "Invalid End Odometer";
                }
            }

            return "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            string sMessage = validate();

            if (!string.IsNullOrEmpty(sMessage))
            {
                MessageBox.Show(sMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Rental.type rentaltype = cbRentType.SelectedItem.ToString() == Rental.type.Day.ToString() ? Rental.type.Day : Rental.type.KM;

            if (((System.Windows.Controls.ContentControl)sender).Content.ToString() == "Save")
            {
                Rental.AddRental(vehicleId,
                                    txtCustomer.Text,
                                    rentaltype,
                                    double.Parse(txtStartOdometer.Text),
                                    DateTime.Parse(dpStartDate.Text),
                                    dtEndDate,
                                    txtNotes.Text);
            }
            else
            {
                sMessage = Rental.FinalizeRental(rentalId, dEndOdometer, dtEndDate.Value, txtNotes.Text);
            }

            if (!string.IsNullOrEmpty(sMessage))
            {
                MessageBox.Show(sMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
