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
    /// Interaction logic for AdministrateElectionEdit.xaml
    /// </summary>
    public partial class AdministrateElectionEdit : Window
    {
        private bool isBallotFinalized;
        private Election myElection;
        private int electionId;
        private DatabaseConnector myConnector = new DatabaseConnector();
        private ElectionAdmin_Homepage launchingWindow;
        public AdministrateElectionEdit(Election election, ElectionAdmin_Homepage launchingWindow)
        {
            this.launchingWindow = launchingWindow;
            this.electionId = election.Election_ID;
            this.myElection = election;
            InitializeComponent();
            type_Of_Election.Text = myElection.ElectionType;
            startdate.SelectedDate = myElection.StartDate;
            enddate.SelectedDate = myElection.EndDate;

            startTimeTextbox.Text = StringFromDateTime(myElection.StartDate);
            endTimeTextbox.Text = StringFromDateTime(myElection.EndDate);

            this.isBallotFinalized = myElection.IsBallotFinalized;

            if (isBallotFinalized) { 
                finalized.IsChecked = true;
                notFinalized.Visibility = Visibility.Hidden;
            }
            else { 
                notFinalized.IsChecked = true;
            }
        }

        private string StringFromDateTime(DateTime dateTime) {
            string time = "";

            if (dateTime.Hour < 10) { 
                time += "0";
            }
            time += dateTime.Hour+":";
            if (dateTime.Minute < 10)
            {
                time += "0";
            }
            time += dateTime.Minute;

            return time;
        }

        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (finalized.IsChecked == true)
            {
                isBallotFinalized = true;
            }
            else if (notFinalized.IsChecked == true)
            {
                isBallotFinalized = false;
            }

            DateTime startFieldDate = startdate.SelectedDate.Value;
            DateTime endFieldDate = enddate.SelectedDate.Value;
            string[] startFieldTime = startTimeTextbox.Text.Split(':');
            string[] endFieldTime = endTimeTextbox.Text.Split(':');

            DateTime startTime = new DateTime(startFieldDate.Year, startFieldDate.Month, startFieldDate.Day, int.Parse(startFieldTime[0]), int.Parse(startFieldTime[1]), 0);
            DateTime endTime = new DateTime(endFieldDate.Year, endFieldDate.Month, endFieldDate.Day, int.Parse(endFieldTime[0]), int.Parse(endFieldTime[1]), 0);

            if (myConnector.EditElection(electionId, type_Of_Election.Text, startTime, endTime, isBallotFinalized))
            {
                MessageBox.Show("Changes saved");
                launchingWindow.DisplayElection(myConnector.GetElection(electionId));
                this.Close();
            }
            else
            {
                MessageBox.Show("Couldn't reach database");
            }


        }
    }
}
//System.Windows.Controls.Button: Select election