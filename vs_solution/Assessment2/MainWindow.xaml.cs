using System;
using System.Collections.Generic;
using System.Windows;

namespace Assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainWindow()
        {
            InitializeComponent();

            //Vehicle v = new Vehicle("Ford", "T812", 2014, "1CES418", 153132.2, 45.5);

            // Vehicle sample distance
            //v.addFuel(new Random().NextDouble() * 10, 1.3);

            //v.printDetails();
            // System.out.println("\n\n");
            //new Vehicle().AddVehicle("Ford", "T812", 2014, "1CES418", 153132.2, 45.5);

            Form_VehicleList form_VehicleList = new Form_VehicleList();
            form_VehicleList.ShowDialog();
        }
    }
}
