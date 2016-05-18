using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SeePreviouslyElections.xaml
    /// </summary>
    public partial class SeePreviouslyElections : Page
    {
         List<Election> listOfElections;
        public SeePreviouslyElections()
        {
            InitializeComponent();
            //    Placeholder code for the databaseconnector bits
            var databaseConnector = new DatabaseConnector();
            listOfElections = databaseConnector.GetAllElections();


            electionsListBox.ItemsSource = listOfElections;
            
            
        }

        private void electionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var databaseConnector = new DatabaseConnector();
            var partysDictionary = ConvertPartyListToDictionary(databaseConnector.GetListOfNationalVotionOptions(listOfElections[electionsListBox.SelectedIndex].Election_ID));
            var partyResults = new ResultCalculator(listOfElections[electionsListBox.SelectedIndex].Election_ID);
            var resultListParty = partyResults.CalculateResultForParties();
            var resultListCandidate = partyResults.CalculateResultsForCandidates();
            var resultListCandidateFinish = new List<ListOfCandidateResults>();

            for (int i = 0; i < resultListCandidate.Count; i++) //Add candidates without party
            {
                
                resultListCandidateFinish.Add(new ListOfCandidateResults() { Votes = resultListCandidate[i].AmountOfVotes, Name = resultListCandidate[i].FirstName, Party = partysDictionary[resultListCandidate[i].PartyId].FirstName });
                
            }

            resultListParty.Sort();
            resultListCandidateFinish.Sort();
            electionResult.ItemsSource = resultListParty;
            electionResultCandidate.ItemsSource = resultListCandidateFinish;
        }

        private Dictionary<int, VotingOption> ConvertPartyListToDictionary(List<VotingOption> votingoptions)
        {
            Dictionary<int, VotingOption> votingOptions = new Dictionary<int, VotingOption>();
            VotingOption noParty = new VotingOption("", "", -1, -1);
            noParty.IsNationalVotingOption = true;
            votingOptions.Add(noParty.PartyId, noParty);
            foreach (var item in votingoptions)
            {
                votingOptions.Add(item.PartyId, item);
            }
            return votingOptions;
        }
    }

    public class ListOfCandidateResults : IComparable<ListOfCandidateResults>
    {
        public int Votes { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }

        public int CompareTo(ListOfCandidateResults other)
        {
            if (this.Votes < other.Votes)
                return 1;
            else
                return -1;
        }
    }
   
}

