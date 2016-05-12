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
    /// Interaction logic for ElectionAdmin_Homepage.xaml
    /// </summary>
    public partial class ElectionAdmin_Homepage : Page
    {
        private Election election;
        private int currentNominationDistrictId;
        public ElectionAdmin_Homepage()
        {
            InitializeComponent();

            var databaseConector = new DatabaseConnector();
            election = databaseConector.GetElection(3);
            var nominationDistrict = databaseConector.GetNominationDistrictsForElection(election);
            var items = new List<NominationDistrictDisplayItem>();

            foreach (var item in nominationDistrict)
            {
                items.Add(new NominationDistrictDisplayItem() { Name = item.Name, Mandates = item.NumberOfMandates, NominationDistrictId = item.NominationDistrictId });
            }

            nominationDistrictListView.ItemsSource = items;
        }
        //Here is the create election for sending you on 
        private void createElection_Click(object sender, RoutedEventArgs e)
        {
            CreatingElection evb = new CreatingElection();
            evb.Show();
        }

        private void admin_election_Click(object sender, RoutedEventArgs e)
        {
            AdministrateElection evb = new AdministrateElection();
            evb.Show();
        }

        public class NominationDistrictDisplayItem
        {
            public string Name { get; set; }
            public int Mandates { get; set; }
            public int NominationDistrictId { get; set; }
        }

        public class ZipCodeDisplayItem
        {
            public int ZipCode { get; set; }
            public string Name { get; set; }
        }


        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var currentNominationDistrict = item.Content as NominationDistrictDisplayItem;
                currentNominationDistrictId = currentNominationDistrict.NominationDistrictId;
                ListZipCodes(currentNominationDistrictId);
            }
        }

        private void NominationDistrictClick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                
            }
        }

        private void ListZipCodes(int nominationId)
        {
            var databaseConector = new DatabaseConnector();
            List<ZipCode> zipCodes = databaseConector.GetAllZipCodesForNominationDistrict(nominationId, election.Election_ID);
            ZipDistrictListView.ItemsSource = zipCodes;
        }
    }
}

