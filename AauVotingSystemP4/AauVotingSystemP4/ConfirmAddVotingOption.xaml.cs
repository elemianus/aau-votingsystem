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
    /// Interaction logic for ConfirmAddVotingOption.xaml
    /// </summary>
    public partial class ConfirmAddVotingOption : Window
    {
        public ConfirmAddVotingOption()
        {
            InitializeComponent();
        }
        //If the user select the "No"-button they will get back to the VotingBallot, and instead of open a new window, we close this window, becasue the VotingBallot lay underneath
        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            AddConfirmation ac = new AddConfirmation();
            ac.Show();
            this.Close();
        }
    }
}
