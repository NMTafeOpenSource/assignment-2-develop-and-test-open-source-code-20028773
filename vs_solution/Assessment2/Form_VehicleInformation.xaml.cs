using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for Form_VehicleInformation.xaml
    /// </summary>
    public partial class Form_VehicleInformation : Window
    {
        public Form_VehicleInformation(Vehicle v)
        {
            InitializeComponent();

            lblInformation.Content = Vehicle.printDetails(v);
        }
    }
}
