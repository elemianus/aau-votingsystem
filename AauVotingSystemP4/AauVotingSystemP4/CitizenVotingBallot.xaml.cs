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
    /// Interaction logic for CitizenVotingBallot.xaml
    /// </summary>
    public partial class CitizenVotingBallot : Page
    {
        public List<VotingOption> myParties;
        public List<VotingOption> myNomCandidates;
        public List<VotingOption> myTempListNomD = new List<VotingOption>();
        public List<VotingOption> myFinalListForNomD = new List<VotingOption>();
        public CitizenVotingBallot()
        {
            InitializeComponent();
            var databaseConector = new DatabaseConnector();
            myNomCandidates = databaseConector.GetVotingOptionForNominationDistrict(databaseConector.GetNomDFromCPR(LoginCitizen.CitizenCPR), 3);
            this.myParties = databaseConector.GetListOfNationalVotionOptions(3);

            for (int i = 0; i < myParties.Count; i++)
            {
                myFinalListForNomD.Add(myParties[i]);
                foreach (var item in myNomCandidates)
                {
                    if (item.PartyId == myParties[i].PartyId)
                    {
                        myFinalListForNomD.Add(item);
                        myTempListNomD.Add(item);
                    }
                }
            }
         
            for (int i = 0; i < myNomCandidates.Count; i++)
            {
                myFinalListForNomD.Insert(0, myNomCandidates[i]);
            }



            myListbox.ItemsSource = myFinalListForNomD;
        }

    }
}
