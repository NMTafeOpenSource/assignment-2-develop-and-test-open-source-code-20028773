using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_VehicleList.xaml
    /// </summary>
    public partial class Form_VehicleList : Window
    {
        //private Vehicle vehicle = new Vehicle();
        public static List<Vehicle> vehicleList;

        public Form_VehicleList()
        {
            InitializeComponent();

            UpdateList();
        }

        public void UpdateList(int nIndex = 0)
        {
            vehicleList = Vehicle.LoadVehicles();
            lvVehicleList.ItemsSource = vehicleList;
            lvVehicleList.Items.Refresh();
        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Vehicle vehicleItem = button.DataContext as Vehicle;
            Vehicle.DeleteVehicle(vehicleList, vehicleItem);
            UpdateList();
        }

        private void EditVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Vehicle vehicleItem = button.DataContext as Vehicle;
            Form_Vehicle form_Vehicle = new Form_Vehicle(vehicleItem);
            form_Vehicle.ShowDialog();
            UpdateList();
        }

        private void BtnAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            Form_Vehicle form_Vehicle = new Form_Vehicle();
            form_Vehicle.ShowDialog();
            UpdateList();
        }

        private void LvVehicleList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lvVehicleList.SelectedItem != null)
            {
                Form_Vehicle form_Vehicle = new Form_Vehicle((Vehicle)lvVehicleList.SelectedItem);
                form_Vehicle.ShowDialog();
                UpdateList();
            }
        }
    }
}
