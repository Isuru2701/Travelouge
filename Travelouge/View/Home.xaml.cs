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

                    //add to label
                    locationsLabel.Content += location.Name + "\n";


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
            double distance, time;
            string reply = "";

            try
            {

                var locationDictionary = locations.FindShortestRoute(out distance, out time);


            foreach (string s in locationDictionary.Keys)
            {
                reply += s + $" ({Math.Round(locationDictionary[s].Item1 / 1000, 2)} km) -> \n";
            }
            reply += "END\n";
            reply += "Total distance: " + Math.Round(distance/1000, 2) + "km" + "\n" + "Total time: " + TimeSpan.FromMilliseconds(time).ToString(@"hh\:mm\:ss") + "\n";

            MessageBox.Show(reply);
            pathLabel.Text = reply;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            locations.Reset();
            pathLabel.Text = "";
            locationsLabel.Content = "";
        }
    }
}
