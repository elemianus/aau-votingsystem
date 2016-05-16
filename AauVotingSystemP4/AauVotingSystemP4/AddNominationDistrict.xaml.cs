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
    /// Interaction logic for AddNominationDistrict.xaml
    /// </summary>
    public partial class AddNominationDistrict : Window
    {
        private Election election;
        private int nominationDistrictId;
        private NominationDistrict nomD;
        private ElectionAdmin_Homepage launchingWindow;

        public AddNominationDistrict(Election election, ElectionAdmin_Homepage launchingWindow, int nominationDistrictId = -1)
        {
            InitializeComponent();
            this.election = election;
            this.launchingWindow = launchingWindow;
            this.nominationDistrictId = nominationDistrictId;

            if (nominationDistrictId != -1) {
                var dbConector = new DatabaseConnector();
                nomD = dbConector.GetNominationDistrictForElection(election, nominationDistrictId);
                nominationDistrictAmountOfVotes.Text = nomD.NumberOfMandates+"";
                nominationDistrictNameTextBox.Text = nomD.Name;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var dbConector = new DatabaseConnector();
            var nomD = new NominationDistrict(election, nominationDistrictNameTextBox.Text,int.Parse( nominationDistrictAmountOfVotes.Text));

            if (nominationDistrictId == -1)
            {
                dbConector.AddNominationDistrictForElection(nomD, election.Election_ID);
            }
            else
            {
                dbConector.UpdateNominationDistrictForElection(nomD);
            }

            this.Close();
            launchingWindow.ListAllNominationDistricts();
        }
    }
}
