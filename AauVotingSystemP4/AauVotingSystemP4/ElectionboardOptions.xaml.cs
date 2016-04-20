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
    /// Interaction logic for ElectionboardOptions.xaml
    /// </summary>
    public partial class ElectionboardOptions : UserControl
    {
        public ElectionboardOptions()
        {
            InitializeComponent();
        }
        private void ParliamentElection_Click(object sender, RoutedEventArgs e)
        {
            //Her fører kanppen hen til ElectionsVotingBallot
            ElectionboardVotingBallot evb = new ElectionboardVotingBallot();
            evb.Show();
        }
    }
}
