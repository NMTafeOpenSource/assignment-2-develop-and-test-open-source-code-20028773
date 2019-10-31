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
            btnSave.Margin = new Thickness(70,0,0,0);
        }

        public Form_Rental(int vId, string vDescription, double odometer)
        {
            initialize();

            vehicleId = vId;
            txtVehicle.Text = vDescription;
            txtStartOdometer.Text = odometer.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Rental.type rentaltype = cbRentType.SelectedItem.ToString() == Rental.type.Day.ToString() ? Rental.type.Day : Rental.type.KM;

            if (((System.Windows.Controls.ContentControl)sender).Content.ToString() == "Save")
            {
                new Rental().AddRental(MainWindow.rentalList,
                                        vehicleId,
                                        txtCustomer.Text,
                                        rentaltype,
                                        double.Parse(txtStartOdometer.Text),
                                        double.Parse(!string.IsNullOrEmpty(txtEndOdometer.Text) ? txtEndOdometer.Text : "0"),
                                        DateTime.Parse(dpStartDate.Text),
                                        DateTime.Parse(dpEndDate.Text),
                                        txtNotes.Text,
                                        0);
            }
            else
            {
                new Rental().FinalizeRental(MainWindow.rentalList, rentalId, double.Parse(txtEndOdometer.Text), DateTime.Parse(dpEndDate.Text), txtNotes.Text);
            }

            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
