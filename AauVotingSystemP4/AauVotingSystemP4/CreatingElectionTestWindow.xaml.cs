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
    /// Interaction logic for CreatingElectionTestWindow.xaml
    /// </summary>
    public partial class CreatingElectionTestWindow : Window
    {
        public CreatingElectionTestWindow(ElectionAdministrator administrator)
        {
            ElectionAdministrator myAdmin;
            InitializeComponent();
            myAdmin = administrator;
            myAdmin
        }

        private void label1_Loaded(object sender, RoutedEventArgs e)
        {
            
             
        }

        private void label2_Loaded(object sender, RoutedEventArgs e)
        {
            label2.Content = "Election Type: " + myAdmin.myElection.ElectionType;
        }

        private void label3_Loaded(object sender, RoutedEventArgs e)
        {
            label3.Content = "Election start date: " + myAdmin.myElection.StartDate;
        }

        private void label4_Loaded(object sender, RoutedEventArgs e)
        {
            label4.Content = "Election end date: " + myAdmin.myElection.EndDate;
        }
    }
}
