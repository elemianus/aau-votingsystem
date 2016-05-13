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
    public interface ElectionAdminRefreshInterface
    {
        void ListZipCodes(int nominationDistrictId);
        void ListAllNominationDistricts();
    }

    /// <summary>
    /// Interaction logic for ElectionAdmin_Homepage.xaml
    /// </summary>
    public partial class ElectionAdmin_Homepage : Page ,ElectionAdminRefreshInterface
    {
        private Election election;
        private NominationDistrict currentNominationDistrict;
        private List<NominationDistrict> nominationDistricts;
        private ZipCode curentZipCode;
        public ElectionAdmin_Homepage()
        {
            InitializeComponent();
            ListAllNominationDistricts();

        }

        public void ListAllNominationDistricts()
        {
            var databaseConector = new DatabaseConnector();
            election = databaseConector.GetElection(3);
            nominationDistricts = databaseConector.GetNominationDistrictsForElection(election);

            nominationDistrictListView.ItemsSource = nominationDistricts;
        }

        private void ListAllCandidatesForNominationDistrict() {
            var databaseConector = new DatabaseConnector();
            CandidatesListview.ItemsSource = databaseConector.GetVotingOptionForNominationDistrict(currentNominationDistrict.NominationDistrictId, election.Election_ID);
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

        public void ListZipCodes(int nominationId)
        {
            var databaseConector = new DatabaseConnector();
            List<ZipCode> zipCodes = databaseConector.GetAllZipCodesForNominationDistrict(nominationId, election.Election_ID);
            ZipDistrictListView.ItemsSource = zipCodes;
        }

        void NominationDistrictSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as NominationDistrict;
            currentNominationDistrict = selectedItem;
            if (currentNominationDistrict != null)
            {
                ListZipCodes(currentNominationDistrict.NominationDistrictId);
                ListAllCandidatesForNominationDistrict();
            }
        }

        private void createNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            AddNominationDistrict addNominationDistrict = new AddNominationDistrict(election,this);
            addNominationDistrict.Show();
        }

        private void editNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null) //Check if nomination district is selected
            {
                AddNominationDistrict addNominationDistrict = new AddNominationDistrict(election,this, currentNominationDistrict.NominationDistrictId);
                addNominationDistrict.Show();
            }
        }

        private void removeNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null) //Check if nomination district is selected
            {
                var dbConector = new DatabaseConnector();

                if (currentNominationDistrict != null)
                {
                    dbConector.DeleteNominationDistrict(currentNominationDistrict);
                    ListAllNominationDistricts();
                }
                currentNominationDistrict = null;
            }
            
        }

        private void createZipCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null) { 
            var window = new AddZipCodeElectionAdmin(election, currentNominationDistrict, this);
            window.Show();
            }
        }

        private void editZipCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null && curentZipCode != null) {
                var window = new AddZipCodeElectionAdmin(election, currentNominationDistrict, this, curentZipCode);
                window.Show();
            }
        }

        private void ZipDistrictListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as ZipCode;
            curentZipCode = selectedItem;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (curentZipCode != null) {
                var dbConector = new DatabaseConnector();
                dbConector.DeleteZipCode(curentZipCode, currentNominationDistrict);
                ListZipCodes(currentNominationDistrict.NominationDistrictId);
            }
        }
    }
}

