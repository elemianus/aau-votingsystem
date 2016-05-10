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
        //myElection der er blevet created og sendt til databasen, skal hives ned igen og dens info skrives ud så at man kan rette i den.
        public CreatingElectionTestWindow()
        {
            
            InitializeComponent();
        
            
        }

        private void label1_Loaded(object sender, RoutedEventArgs e)
        {
            //label1.Content = "Election Type: " + myElection.ElectionType;

        }

        private void label2_Loaded(object sender, RoutedEventArgs e)
        {
            //label2.Content = "Election Type: " + myElection.ElectionType;
        }

        private void label3_Loaded(object sender, RoutedEventArgs e)
        {
            //label3.Content = "Election start date: " + myElection.StartDate;
        }

        private void label4_Loaded(object sender, RoutedEventArgs e)
        {
            //label4.Content = "Election end date: " + myElection.EndDate;
        }
    }
}
