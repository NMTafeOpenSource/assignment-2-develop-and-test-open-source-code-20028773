using System.Windows;
using System.Windows.Input;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_RentalList.xaml
    /// </summary>
    public partial class Form_RentalList : Window
    {
        public Form_RentalList()
        {
            InitializeComponent();

            UpdateList();

        }

        private void LvRentalList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvRentalList.SelectedItem != null)
            {
                Form_Rental form_Rental = new Form_Rental((Rental)lvRentalList.SelectedItem);
                form_Rental.ShowDialog();

                UpdateList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateList()
        {
            //availableVehicles = vehicleList.Where(x => !rentalList.Where(r => r.totalPrice == 0).Select(p => p.vehicleId).Contains(x.Id)).ToList();

            lvRentalList.ItemsSource = MainWindow.rentalList;
            lvRentalList.Items.Refresh();
        }
    }
}
