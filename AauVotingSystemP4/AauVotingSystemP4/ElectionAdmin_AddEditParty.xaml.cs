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
    /// Interaction logic for ElectionAdmin_AddEditParty.xaml
    /// </summary>
    public partial class ElectionAdmin_AddEditParty : Window
    {
        private NominationDistrict nominationDistrict;
        private VotingOption currentVotingOption;
        private int electionId;
        private ElectionAdmin_Homepage launchingWindow;
        public ElectionAdmin_AddEditParty(ElectionAdmin_Homepage launchingWindow, NominationDistrict nominationDistrict,int electionId, VotingOption currentVotingOption = null)
        {
            this.currentVotingOption = currentVotingOption;
            this.nominationDistrict = nominationDistrict;
            this.electionId = electionId;
            this.launchingWindow = launchingWindow;
            InitializeComponent();

            if (currentVotingOption != null) {
                partyTextBox.Text = currentVotingOption.FirstName;
            }
        }

        private void partyButton_Click(object sender, RoutedEventArgs e)
        {
            var dbConector = new DatabaseConnector();

            if (currentVotingOption == null) //Add new option
            {
                var vo = new VotingOption(partyTextBox.Text, "", -1);
                vo.IsNationalVotingOption = true;
                dbConector.AddVotionOPtion(vo, electionId);
            }
            else
            {
                var vo = new VotingOption(partyTextBox.Text, "", currentVotingOption.NominationDistrictId, currentVotingOption.PartyId, currentVotingOption.VotingOptionId);
                vo.IsNationalVotingOption = true;
                dbConector.UpdateVotingOption(vo);
            }

            launchingWindow.UpdateListOfNationalVotingOptions();
            Close();
        }
    }
}
