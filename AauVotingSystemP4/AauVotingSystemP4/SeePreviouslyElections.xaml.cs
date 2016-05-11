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
    /// Interaction logic for SeePreviouslyElections.xaml
    /// </summary>
    public partial class PreviousElectionList : Page
    {
        ElectionListBox model = new ElectionListBox();

    }
    public class ElectionListBox
    {


    }

    public partial class SeePreviouslyElections : Page
    {
        public SeePreviouslyElections()
        {
            InitializeComponent();
            //    Placeholder code for the databaseconnector bits
            
            
            
            //List<Result> items = new List<Result>();
            //items.Add(new Result() { Name = "Venstre", Votes = 500000, Mandates = 12});
            //items.Add(new Result() { Name = "Dansk Folkeparti", Votes = 300000, Mandates = 7 });
            //items.Add(new Result() { Name = "Alternativet", Votes = 200000, Mandates = 4 });
            //electionResult.ItemsSource = items;
                

        }
        

        
    }
    public class Result
    {
        public string Name { get; set; }
        public int Votes { get; set; }
        public int Mandates { get; set; }
    }
}
