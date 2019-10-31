using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<Vehicle> vehicleList = new List<Vehicle>();

        public static List<Vehicle> vehicleList;
        public static List<Rental> rentalList;
        public static List<Vehicle> availableVehicles;

        public MainWindow()
        {
            InitializeComponent();

            //Vehicle v = new Vehicle("Ford", "T812", 2014, "1CES418", 153132.2, 45.5);

            // Vehicle sample distance
            //v.addFuel(new Random().NextDouble() * 10, 1.3);

            //v.printDetails();
            // System.out.println("\n\n");
            //new Vehicle().AddVehicle("Ford", "T812", 2014, "1CES418", 153132.2, 45.5);


            vehicleList = Vehicle.LoadVehicles();
            rentalList = Rental.LoadRental();

            UpdateList();
        }

        public void UpdateList()
        {
            availableVehicles = vehicleList.Where(x => !rentalList.Where(r => r.totalPrice == 0).Select(p => p.vehicleId).Contains(x.Id)).ToList();

            lvRentVehicleList.ItemsSource = availableVehicles;
            lvRentVehicleList.Items.Refresh();
        }

        private void MiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MiVehicles_Click(object sender, RoutedEventArgs e)
        {
            Form_VehicleList form_VehicleList = new Form_VehicleList();
            form_VehicleList.ShowDialog();
        }

        private void LvRentVehicleList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lvRentVehicleList.SelectedItem != null)
            {
                Vehicle v = (Vehicle)lvRentVehicleList.SelectedItem;
                Form_Rental form_Rental = new Form_Rental(v.Id, v.vehicleDescription, v.OdometerReading);
                form_Rental.ShowDialog();

                UpdateList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Vehicle vehicleItem = button.DataContext as Vehicle;

            new Rental().AddRental(rentalList, vehicleItem.Id, "Koji Furukawa", Rental.type.Day, 0, 0, DateTime.Now, DateTime.Now, null, 0);

            UpdateList();


            //Form_Vehicle form_Vehicle = new Form_Vehicle(vehicleItem);
            //form_Vehicle.ShowDialog();
            //UpdateList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MiRents_Click(object sender, RoutedEventArgs e)
        {
            Form_RentalList form_RentalList = new Form_RentalList();
            form_RentalList.ShowDialog();
        }
    }
}
