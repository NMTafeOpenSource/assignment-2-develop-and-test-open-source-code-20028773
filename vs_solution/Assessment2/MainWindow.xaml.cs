using System.Windows;
using System.Windows.Controls;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            lvRentVehicleList.ItemsSource = Rental.GetAvailableVehicles();
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
            UpdateList();
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

            UpdateList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MiRents_Click(object sender, RoutedEventArgs e)
        {
            Form_RentalList form_RentalList = new Form_RentalList();
            form_RentalList.ShowDialog();
            UpdateList();
        }
    }
}
