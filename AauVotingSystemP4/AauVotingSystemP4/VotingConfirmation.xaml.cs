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
    /// Interaction logic for VotingConfirmation.xaml
    /// </summary>
    public partial class VotingConfirmation : Window
    {
        
        public VotingConfirmation()
        {
            InitializeComponent();
            
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            CitizenHaveVoted chv = new CitizenHaveVoted();
            chv.Show();
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
