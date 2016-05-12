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
    //    /// <summary>
    //    /// Interaction logic for Electionboard_Homepage.xaml
    //    /// </summary>
    public partial class Electionboard_Homepage : Page
    {
        public Electionboard_Homepage()
        {
            InitializeComponent();

        }

        private void ParliamentElection_Click(object sender, RoutedEventArgs e)
        {
            ElectionboardVotingBallot evb = new ElectionboardVotingBallot();
            evb.Show();
        }

        private void AddRemove_Click(object sender, RoutedEventArgs e)
        {
            AddVotingOption avo = new AddVotingOption();
            avo.Show();
        }
    }
}

