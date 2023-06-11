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
                            var route = await verifier.FindDistance(location.Name, otherLocation);
                            locations.AddEdge(location.Name, otherLocation, route.distance, route.time);
                            MessageBox.Show("location.Name: " + location.Name + " otherLocation: " + otherLocation + " distance: " + route.distance + " time: " + route.time);
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
            double distance;
            string reply = "";
            
            foreach(string s in locations.FindShortestRoute(out distance))
            {
                reply += s + "\n";
            }

            MessageBox.Show(reply);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            locations.Reset();
        }
    }
}
