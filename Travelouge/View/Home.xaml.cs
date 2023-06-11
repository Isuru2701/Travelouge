using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Travelouge.Model;

namespace Travelouge.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Graph locations = new Graph();
        public Home()
        {
            InitializeComponent();
        }

        private async void checkButton_Click(object sender, RoutedEventArgs e)
        {
            GraphHopper verifier = new GraphHopper();
            var location = await verifier.VerifyLocation(locationBox.Text);

            if (location != null)
            {
                if (!locations.Contains(location.Name))
                {
                    locations.AddLocation(location.Name);
                    MessageBox.Show("Successfully added");

                    //find the weights to each other locations
                    foreach (var otherLocation in locations.GetLocations())
                    {
                        if (otherLocation != location.Name)
                        {
                            var distance = await verifier.GetDistance(location.Name, otherLocation);
                            locations.AddEdge(location.Name, otherLocation, distance);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Location already added");
                }
            }
            else
            {
                MessageBox.Show("Empty or invalid location");
            }
        }

        private void kruskalButton_Click(object sender, RoutedEventArgs e)
        {
            Graph MST = locations.Kruskal();
            MessageBox.Show(MST.ToString());
        }
    }
}
