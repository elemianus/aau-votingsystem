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
    /// Interaction logic for ElectionboardVotingBallot.xaml
    /// </summary>
    public partial class ElectionboardVotingBallot : Window
    {
        public ElectionboardVotingBallot()
        {
            InitializeComponent();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddVotingOption avo = new AddVotingOption();
            avo.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteVotingOption dvo = new DeleteVotingOption();
            dvo.Show();
            this.Close();
        }

        private void HeaderElectionboard_Loaded(object sender, RoutedEventArgs e)
        {

        }


        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var databaseConector = new DatabaseConnector();
        //    List<VotingOption> votingOption = databaseConector.GetAllVotingOptionsForElection(1);
        //}


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            var elections = databaseConector.GetAllElections();
            var displayList = new List<ElectionDisplayItem>();
            foreach (var item in elections)
            {
                displayList.Add(new ElectionDisplayItem() { ElectionId = item.Election_ID, Name = item.ElectionType, IsBallotFinalized = item.IsBallotFinalized, StartDate = item.StartDate.Day + "-" + item.StartDate.Month + "-" + item.StartDate.Year });
            }
            electionListView.ItemsSource = displayList;
        }

        private void SelectElection_Click(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            //databaseConector.GetListOfNationalVotionOptions

            //dataGrid1.ItemsSource = databaseConector.GetVotingOptionForNominationDistrict(3,(int.Parse(TypedInElection.Text)));
        }

        public class ElectionDisplayItem
        {
            public string Name { get; set; }
            public bool IsBallotFinalized { get; set; }
            public string StartDate { get; set; }
            public int ElectionId { get; set; }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var currentElectoin = item.Content as ElectionDisplayItem;
                MessageBox.Show(currentElectoin.ElectionId+"");
            }
        }
    }
}