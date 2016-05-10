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
        public ElectionAdmin_Homepage()
        {
            InitializeComponent();
        }
        private void ParliamentElection_Click(object sender, RoutedEventArgs e)
        {
            ElectionboardVotingBallot evb = new ElectionboardVotingBallot();
            evb.Show();
        }

        private void createElection_Click(object sender, RoutedEventArgs e)
        {
            CreatingElection evb = new CreatingElection();
            evb.Show();
        }
    }
}

