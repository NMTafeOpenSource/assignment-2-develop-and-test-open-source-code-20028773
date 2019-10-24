using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_VehicleList.xaml
    /// </summary>
    public partial class Form_VehicleList : Window
    {
        private Vehicle vehicle = new Vehicle();

        public Form_VehicleList()
        {
            InitializeComponent();

            UpdateList();
        }

        public void UpdateList(int nIndex = 0)
        {
            vehicle.LoadVehicles();
            lvVehicleList.ItemsSource = vehicle.VehiclesList;
            lvVehicleList.Items.Refresh();

            //txtRecordNumberLabel.Text = string.Format("Record {0} of {1}", nIndex + 1, companyList.Count);
        }

        private void DeleteVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
