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
        string pincode = "";
        string[] testing = new string[4];
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
            if (Maxpin == 4)
            {
                this.NavigationService.Navigate(new ParentalTime());
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
                string Input = PWB_1.Password.ToString();
                pincode = Input;
                Maxpin++;
                 
        }
    }
}
