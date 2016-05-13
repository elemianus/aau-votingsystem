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
    /// Interaction logic for Addpartyvotingoption.xaml
    /// </summary>
    public partial class Addpartyvotingoption : Window
    {
        DatabaseConnector databaseConnector = new DatabaseConnector();
        public Addpartyvotingoption()
        {
            InitializeComponent();
            var polParties = databaseConnector.GetListOfNationalVotionOptions(3);
            var partyList = new List<PartiesInElection>();
            foreach (var item in polParties)
            {
                partyList.Add(new PartiesInElection() { PartyName = item.FirstName });
            }
            ListOfParties.ItemsSource = partyList;

            var myVotingOption = new VotingOption("", "", -1);
            myVotingOption.IsNationalVotingOption = true;
            databaseConnector.AddVotionOPtion(myVotingOption, 3);
            PartyInput.Text = myVotingOption.FirstName;




        }

        private void partyAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class PartiesInElection
    {
        public string PartyName { get; set; }
    }

}
