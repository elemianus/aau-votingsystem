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
            var databaseConnector = new DatabaseConnector();
            var listOfElections = databaseConnector.GetAllElections();
            var listOfListOfElections = new List<ListOfElections>();
            foreach (var item in listOfElections) 
            {
                listOfListOfElections.Add(new ListOfElections() { TypeOfElection = item.ElectionType, StartDate = item.StartDate.Year.ToString() });
            }
            var databaseResults = new DatabaseConnector();
            var listOfResults = 

            //List<Result> items = new List<Result>();
            //items.Add(new Result() { Name = "Venstre", Votes = 500000, Mandates = 12 });
            //items.Add(new Result() { Name = "Dansk Folkeparti", Votes = 300000, Mandates = 7 });
            //items.Add(new Result() { Name = "Alternativet", Votes = 200000, Mandates = 4 });
            electionsListBox.ItemsSource = listOfListOfElections;
            electionResult.ItemsSource = items;


        }



    }
    public class Result
    {
        public string Name { get; set; }
        public int Votes { get; set; }
        public int Mandates { get; set; }
    }
    public class ListOfElections
    {
        public string TypeOfElection { get; set; }
        public string StartDate { get; set; }

    }
}
