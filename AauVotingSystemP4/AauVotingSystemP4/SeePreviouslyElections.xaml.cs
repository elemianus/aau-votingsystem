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
            var listOfListOfElections = new List<ListOfElections>();
            foreach (var item in listOfElections)
            {
                listOfListOfElections.Add(new ListOfElections() { TypeOfElection = item.ElectionType, StartDate = item.StartDate.Year.ToString() });
            }

           
            //var candidateResults = new ResultCalculator(38);
            //var resultListCandidate = candidateResults.CalculateResultsForCandidates();
            //var listOfCandidateResults = new List<ListOfCandidateResults>();
            //foreach (var item in resultListCandidate)
            //{
            //    listOfCandidateResults.Add(new ListOfCandidateResults() { CandidateVoteCount = item.AmountOfVotes });
            //}

            //List<Result> items = new List<Result>();
            //items.Add(new Result() { Name = "Venstre", Votes = 500000, Mandates = 12 });
            //items.Add(new Result() { Name = "Dansk Folkeparti", Votes = 300000, Mandates = 7 });
            //items.Add(new Result() { Name = "Alternativet", Votes = 200000, Mandates = 4 });
            electionsListBox.ItemsSource = listOfListOfElections;
            


        }

        private void electionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var databaseConnector = new DatabaseConnector();
            var partysDictionary = ConvertPartyListToDictionary(databaseConnector.GetListOfNationalVotionOptions(listOfElections[electionsListBox.SelectedIndex].Election_ID));
            var partyResults = new ResultCalculator(listOfElections[electionsListBox.SelectedIndex].Election_ID);
            var resultListParty = partyResults.CalculateResultForParties();
            var listOfPartyResults = new List<ListOfPartyResults>();
            var resultListCandidate = partyResults.CalculateResultsForCandidates();
            List<ListOfCandidateResults> resultListCandidateFinish = new List<ListOfCandidateResults>();
            var listOfCandidateResults = new List<ListOfPartyResults>();
            foreach (var item in resultListParty)
            {
                listOfPartyResults.Add(new ListOfPartyResults() { PartyVoteCount = item.AmountOfVotes, Name = item.FirstName, Mandates = 10 });
                /*
                for (int i = 0; i < resultListCandidate.Count; i++)
                {
                    if (item.PartyId == resultListCandidate[i].PartyId)
                    {
                        listOfPartyResults.Add(new ListOfPartyResults() { PartyVoteCount = resultListCandidate[i].AmountOfVotes, Name = resultListCandidate[i].FirstName, Mandates = 10 });
                    }
                }
                */
            }
            for (int i = 0; i < resultListCandidate.Count; i++) //Add candidates without party
            {

                resultListCandidateFinish.Add(new ListOfCandidateResults() { Votes = resultListCandidate[i].AmountOfVotes, Name = resultListCandidate[i].FirstName, Party = partysDictionary[resultListCandidate[i].PartyId].FirstName });
                
            }

            /*foreach (var item in resultListCandidate)
            {
                listOfPartyResults.Add(new ListOfPartyResults() { PartyVoteCount = item.AmountOfVotes, Name = item.FirstName, Mandates = 10 });
            }
            */
            electionResult.ItemsSource = listOfPartyResults;
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

    public class ListOfElections
    {
        public string TypeOfElection { get; set; }
        public string StartDate { get; set; }

    }
    public class ListOfPartyResults
    {
        public string Name { get; set; }
        public int PartyVoteCount { get; set; }
        public int Mandates { get; set; }
    }

    public class ListOfCandidateResults
    {
        public int Votes { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        
    }
   
}

