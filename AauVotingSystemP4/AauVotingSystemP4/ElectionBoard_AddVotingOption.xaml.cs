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
    /// Interaction logic for ElectionBoard_AddVotingOption.xaml
    /// </summary>
    public partial class ElectionBoard_AddVotingOption : Window
    {
        private ElectionBoard electionBoard;
        private VotingOption currentVotingOption;
        private VotingOption currentParty;
        private List<VotingOption> partys;
        Electionboard_Homepage launchWindow;

        public ElectionBoard_AddVotingOption(Electionboard_Homepage launchWindow, ElectionBoard electionBoard, List<VotingOption> partys, VotingOption currentVotingOption = null)
        {
            this.electionBoard = electionBoard;
            this.currentVotingOption = currentVotingOption;
            this.partys = partys;
            this.launchWindow = launchWindow;

            InitializeComponent();

            if (currentVotingOption != null)
            {
                for (int i = 0; i < partys.Count; i++)
                {
                    if (partys[i].PartyId == currentVotingOption.PartyId) { 
                        PartiesListView.SelectedIndex = i;
                        currentParty = partys[i];
                        break;
                    }
                }
                
                firstNameTextBox.Text = currentVotingOption.FirstName;
                lastNameTextBox.Text = currentVotingOption.LastName;
            }

            PartiesListView.ItemsSource = partys;
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            var dbConector = new DatabaseConnector();
            if (currentVotingOption == null) //Add new VO
            {
                int partyId = -1;
                if (currentParty != null)
                    partyId = currentParty.PartyId;
                VotingOption vo = new VotingOption(firstNameTextBox.Text, lastNameTextBox.Text, electionBoard.NominationDistrictId, partyId);
                dbConector.AddVotionOPtion(vo, electionBoard.ElectionId);

                launchWindow.UpdateListOfCandidates();
                Close();
            }
            else //Existing voting option
            {
                int partyId = -1;
                if(currentParty!=null)
                    partyId = currentParty.PartyId;
                var vo = new VotingOption(firstNameTextBox.Text, lastNameTextBox.Text, currentVotingOption.NominationDistrictId, partyId, currentVotingOption.VotingOptionId);
                dbConector.UpdateVotingOption(vo);
                launchWindow.UpdateListOfCandidates();
                Close();
            }
        }

        private void PartiesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as VotingOption;
            currentParty = selectedItem;
        }
    }
}
