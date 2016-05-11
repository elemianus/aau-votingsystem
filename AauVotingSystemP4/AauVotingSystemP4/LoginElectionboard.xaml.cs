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
    /// Interaction logic for LoginElectionboard.xaml
    /// </summary>
    public partial class LoginElectionboard : Page
    {
        public static string LogInNominationdistrict;
        public LoginElectionboard()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            if (databaseConector.DoesElectionboardExist(TypeInNominationDistrict.Text))
            {

                //string LogInNominationdistrict = TypeInNominationDistrict.Text;
                //Nomination district exists

                ElectionboardMainWindow emw = new ElectionboardMainWindow();
                emw.Show();
                LogInNominationdistrict = TypeInNominationDistrict.Text;
                //LogInNominationdistrict = int.Parse(TypeInNominationDistrict.Text);
            }
            else
            {
                MessageBox.Show("The name of the electionboard do not exist. \n Try again.");
            }
        }
    }
}
