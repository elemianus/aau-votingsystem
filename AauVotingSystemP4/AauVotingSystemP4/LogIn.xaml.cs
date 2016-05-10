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
using System.Windows.Shapes;

namespace AauVotingSystemP4
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInCitizen_Click(object sender, RoutedEventArgs e)
        {
            LoginCitizen lic = new LoginCitizen();
            Main.NavigationService.Navigate(lic);
        }

        private void LogInElectionboard_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
