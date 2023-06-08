using System;
using System.Collections.Generic;
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
        public Home()
        {
            InitializeComponent();
        }

        private async void checkButton_Click(object sender, RoutedEventArgs e)
        {
            GraphHopper verifier = new GraphHopper();
            bool flag = await verifier.VerifyLocation(locationBox.Text);

            if (flag)
            {
                MessageBox.Show("Location is valid");

            }
            else
            {
                MessageBox.Show("Location is invalid");
            }
        }
    }
}
