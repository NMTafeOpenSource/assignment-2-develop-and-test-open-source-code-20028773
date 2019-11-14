using System.Windows;
using System.Windows.Controls;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_VehicleList.xaml
    /// </summary>
    public partial class Form_VehicleList : Window
    {
        public Form_VehicleList()
        {
            InitializeComponent();

            UpdateList();
        }

        public void UpdateList(int nIndex = 0)
        {
            lvVehicleList.ItemsSource = Vehicle.vehicleList;
            lvVehicleList.Items.Refresh();
        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("This will erase the vehicle from the database, do you still want to continue ?", "Vehicle", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                Vehicle vehicleItem = button.DataContext as Vehicle;
                Vehicle.DeleteVehicle(vehicleItem);
                UpdateList();
            }
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
                Form_VehicleInformation form_VehicleInformation = new Form_VehicleInformation((Vehicle)lvVehicleList.SelectedItem);
                form_VehicleInformation.ShowDialog();
                UpdateList();
            }
        }

        private void ServiceVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Have you serviced the vehicle ?", "Vehicle", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                Vehicle vehicleItem = button.DataContext as Vehicle;
                new Service().recordService(vehicleItem.Id);
                UpdateList();
            }
        }

        private void EditNutritionContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveNutritionContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPurchaseFuel_Click(object sender, RoutedEventArgs e)
        {
            if (lvVehicleList.SelectedItem != null)
            {
                Form_FuelPurchase form_FuelPurchase = new Form_FuelPurchase((Vehicle)lvVehicleList.SelectedItem);
                form_FuelPurchase.ShowDialog();
                UpdateList();
            }
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (lvVehicleList.SelectedItem != null)
            {
                Form_VehicleHistory form_VehicleHistory = new Form_VehicleHistory((Vehicle)lvVehicleList.SelectedItem);
                form_VehicleHistory.ShowDialog();
                UpdateList();
            }
        }
    }
}
