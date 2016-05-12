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
        public SeePreviouslyElections()
        {
            InitializeComponent();
            //    Placeholder code for the databaseconnector bits
            var databaseConnector = new DatabaseConnector();
            var listOfElections = databaseConnector.GetAllElections();
            var listOfListOfElections = new List<ListOfElections>();
            foreach (var item in listOfElections)
            {
                listOfListOfElections.Add(new ListOfElections() { TypeOfElection = item.ElectionType, StartDate = item.StartDate.Year.ToString() });
            }

            var partyResults = new ResultCalculator(2);
            var resultListParty = partyResults.CalculateResultForParties();
            var listOfPartyResults = new List<ListOfPartyResults>();
            foreach (var item in resultListParty)
            {
                listOfPartyResults.Add(new ListOfPartyResults() { PartyVoteCount = item.AmountOfVotes });
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
            electionResult.ItemsSource = listOfPartyResults;


        }



    }

    public class ListOfElections
    {
        public string TypeOfElection { get; set; }
        public string StartDate { get; set; }

    }
    public class ListOfPartyResults
    {
        public int PartyVoteCount { get; set; }
    }
    //public class ListOfCandidateResults
    //{
    //    public int CandidateVoteCount { get; set; }
}

