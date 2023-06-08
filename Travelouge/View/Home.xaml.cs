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
        LinkedList<Location> locations = new LinkedList<Location>();
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
                if (!locations.Contains(location))
                {
                    locations.AddLast(location);
                }
                else
                {
                    MessageBox.Show("Location already added");
                }
            }
            else
            {
            }
        }
    }
}
