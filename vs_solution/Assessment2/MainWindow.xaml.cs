using System;
using System.Windows;

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

            Vehicle v = new Vehicle("Ford", "T812", 2014);

            // Vehicle sample distance
            v.addFuel(new Random().NextDouble() * 10, 1.3);

            v.printDetails();
            // System.out.println("\n\n");
        }
    }
}
