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

namespace Minerunner
{
    /// <summary>
    /// Interaction logic for ParentalControl.xaml
    /// </summary>
    public partial class ParentalControl : Page
    {
        int[] pincode = new int[4];
        int Maxpin = 0;

        public ParentalControl()
        {
            InitializeComponent();
            
        }

        private void Backspace_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gereed_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        // Nummer voor pincode
        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            string num1 = "1";
            if (Maxpin > 4)
            {
                Pincode.Text = num1;
            }
            
        }
        private void Num2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num4_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num5_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num6_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num7_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num8_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Num9_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
