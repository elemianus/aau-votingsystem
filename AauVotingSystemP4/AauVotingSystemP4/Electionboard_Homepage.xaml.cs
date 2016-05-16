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
    //    /// <summary>
    //    /// Interaction logic for Electionboard_Homepage.xaml
    //    /// </summary>
    public partial class Electionboard_Homepage : Page
    {
        private ElectionBoard electionBoard;
        private List<VotingOption> nationalVotingOptions;
        private List<VotingOption> candidates;
        private VotingOption currentVotingOption;
        public Electionboard_Homepage(int electionBoardId)
        {
            InitializeComponent();
            var databaseConector = new DatabaseConnector();
            electionBoard = databaseConector.GetElectionBoardForId(electionBoardId);
            electionboardName.Content += electionBoard.NominationDistrictName;

            
            UpdateListOfCandidates();
        }

        public void UpdateListOfCandidates()
        {
            currentVotingOption = null;
            var databaseConector = new DatabaseConnector();

            nationalVotingOptions = databaseConector.GetListOfNationalVotionOptions(electionBoard.ElectionId);
            var partysDictionary = ConvertPartyListToDictionary(nationalVotingOptions);
            candidates = databaseConector.GetVotingOptionForNominationDistrict(electionBoard.NominationDistrictId, electionBoard.ElectionId);
            var listOfCandidates = new List<CandidateWithParty>();

            foreach (var item in candidates)
            {
                var candidateWithParty = new CandidateWithParty() { FirstName = item.FirstName, LastName = item.LastName, CandidateId = item.VotingOptionId, PartyName = partysDictionary[item.PartyId].FirstName, PartyId = item.PartyId };
                listOfCandidates.Add(candidateWithParty);
            }

            CandidatesListview.ItemsSource = listOfCandidates;
        }


        public class CandidateWithParty
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int CandidateId { get; set; }
            public string PartyName { get; set; }
            public int PartyId { get; set; }
        }

        private Dictionary<int, VotingOption> ConvertPartyListToDictionary(List<VotingOption> nationalVotingOptions)
        {
            Dictionary<int, VotingOption> votingOptions = new Dictionary<int, VotingOption>();
            VotingOption noParty = new VotingOption("", "", -1, -1);
            noParty.IsNationalVotingOption = true;
            votingOptions.Add(noParty.PartyId, noParty);
            foreach (var item in nationalVotingOptions)
            {
                votingOptions.Add(item.PartyId, item);
            }
            return votingOptions;
        }

        private void ParliamentElection_Click(object sender, RoutedEventArgs e)
        {
            ElectionboardVotingBallot evb = new ElectionboardVotingBallot();
            evb.Show();
        }


        private void addCandidateButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ElectionBoard_AddVotingOption(this, electionBoard, nationalVotingOptions);
            window.Show();
        }

        private void editCandidateButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentVotingOption != null)
            {
                var window = new ElectionBoard_AddVotingOption(this, electionBoard, nationalVotingOptions, currentVotingOption);
                window.Show();
            }
        }

        private void CandidatesListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as CandidateWithParty;
            foreach (var item in candidates)
            {
                if (selectedItem != null)
                {
                    if (item.VotingOptionId == selectedItem.CandidateId)
                    {
                        currentVotingOption = item;
                    }
                }
            }
        }
    }
}

