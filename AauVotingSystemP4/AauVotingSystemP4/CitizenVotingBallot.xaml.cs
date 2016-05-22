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
    /// Interaction logic for CitizenVotingBallot.xaml
    /// </summary>
    public partial class CitizenVotingBallot : Window
    {
        List<VotingOption> myParties;
        List<VotingOption> myNomCandidates;
        List<VotingOption> myTempListNomD = new List<VotingOption>();
        List<VotingOption> myinalListForNomD = new List<VotingOption>();

        int myElectionId;
        private VotingBallot ballot;


        public CitizenVotingBallot(int ElectionID)
        {
            InitializeComponent();
            myElectionId = ElectionID;
            var databaseConector = new DatabaseConnector();

            ballot = new VotingBallot(myElectionId, databaseConector.GetNomDFromCPR(LoginCitizen.CitizenCPR, myElectionId));
            myListbox.ItemsSource = ballot.GetVotingOptions();
        }

        private void VoteButton_Click(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            if (databaseConector.RegisterVote(LoginCitizen.myCitizen, ballot.GetVotingOptions()[myListbox.SelectedIndex], myElectionId, databaseConector.GetNomDFromCPR(LoginCitizen.CitizenCPR, myElectionId)))
            {
                MessageBox.Show("You have voted for " + myListbox.SelectedItem.ToString());
                Close();
            }
            else
            {
                MessageBox.Show("Error: You have already voted in this election");
            }

        }
    }


}
