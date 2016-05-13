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
    /// Interaction logic for AdministrateElection.xaml
    /// </summary>
    public partial class AdministrateElection : Window
    {
       
        public AdministrateElection()
        {
            InitializeComponent();
            
        }
      
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
                AdministrateElectionEdit evb = new AdministrateElectionEdit(currentElectoin.ElectionId);
                evb.Show();
                this.Close();
            }
        }

        private void HeaderElectionAdmin_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
