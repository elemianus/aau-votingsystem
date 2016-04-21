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
    /// Interaction logic for CitizenAboutToVote.xaml
    /// </summary>
    public partial class CitizenAboutToVote : Window
    {
        public CitizenAboutToVote()
        {
            InitializeComponent();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            CitizenVotingBallot cvb = new CitizenVotingBallot();
            cvb.Show();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            VotingConfirmation vc = new VotingConfirmation();
            vc.Show();
        }
    }
}
