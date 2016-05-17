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

namespace AauVotingSystemP4
{
    /// <summary>
    /// Interaction logic for CitizenVoteChooseElection.xaml
    /// </summary>
    public partial class CitizenVoteChooseElection : Page
    {
        Election currentElection;
        List<Election> myElections;
        public CitizenVoteChooseElection()
        {
            InitializeComponent();
            ListAllElections();
        }

        public void ListAllElections()
        {
            var databaseConector = new DatabaseConnector();
            myElections = databaseConector.GetAllElections();
            electionListView.ItemsSource = myElections;
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

        private void ChooseElection_Click(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            if (databaseConector.HasCitizenVotedForElection(LoginCitizen.myCitizen, myElections[electionListView.SelectedIndex].Election_ID))
            {
                MessageBox.Show("Error: You have already voted in this election");
            }
            else
            {

                CitizenVotingBallot nw = new CitizenVotingBallot(myElections[electionListView.SelectedIndex].Election_ID);
                nw.Show();
            }

        }
    }
}
