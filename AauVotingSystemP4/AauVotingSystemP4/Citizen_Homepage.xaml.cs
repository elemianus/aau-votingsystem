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
    /// Interaction logic for Citizen_Homepage.xaml
    /// </summary>
    public partial class Citizen_Homepage : Page
    {
        public Citizen_Homepage()
        {
            InitializeComponent();
        }

        private void SeePreviouslyElections_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SeePreviouslyElections();
        }

        private void VoteButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CitizenVoteChooseElection();
        }
    }
}
