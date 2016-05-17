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
    /// Interaction logic for ElectionAdminMainWindow.xaml
    /// </summary>
    public partial class ElectionAdminMainWindow : Window
    {
        Election currentElection;
        public ElectionAdminMainWindow()
        {
            InitializeComponent();
            //Main.Content = new ElectionAdmin_Homepage();
            ListAllElections();

        }

        public void ListAllElections()
        {
            var databaseConector = new DatabaseConnector();
            var elections = databaseConector.GetAllElections();
            electionListView.ItemsSource = elections;
        }


        private void electionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as Election;
            currentElection = selectedItem;
            if (currentElection != null)
            {
                //DO stuff
            }
        }

        //Here is the create election for sending you on 
        private void createElection_Click(object sender, RoutedEventArgs e)
        {
            CreatingElection evb = new CreatingElection(this);
            evb.Show();
        }

        private void admin_election_Click(object sender, RoutedEventArgs e)
        {
            if (currentElection != null)
            {
                var evb = new ElectionAdmin_Homepage(currentElection);
                evb.Show();
            }
        }
    }
}
