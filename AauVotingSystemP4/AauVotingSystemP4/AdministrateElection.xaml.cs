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
    /// Interaction logic for AdministrateElection.xaml
    /// </summary>
    public partial class AdministrateElection : Window
    {
        
        public AdministrateElection()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            dataGrid1.ItemsSource = databaseConector.GetAllElections();
        }

        private void SelectedElection_Click(object sender, RoutedEventArgs e)
        {
            AdministrateElectionEdit evb = new AdministrateElectionEdit(int.Parse(TypedInElection.Text));
            evb.Show();

        }

       
    }
}
