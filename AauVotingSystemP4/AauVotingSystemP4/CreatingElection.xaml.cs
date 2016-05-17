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
    /// Interaction logic for CreatingElection1.xaml
    /// </summary>
    public partial class CreatingElection : Window
    {
        ElectionAdminMainWindow launchingWindow;
        public CreatingElection(ElectionAdminMainWindow launchingWindow)
        {
            this.launchingWindow = launchingWindow;
            InitializeComponent();
            
        }

        private void CreateElection_Click(object sender, RoutedEventArgs e)
        {

            ElectionAdministrator myAdministrator = new ElectionAdministrator(); // administratoren skal creates når programmet startes og smides i databasen, så at man kan bruge det objekt når man logger ind som admin?
            var db = new DatabaseConnector();

            DateTime startFieldDate = start_DateTimePicker.SelectedDate.Value;
            DateTime endFieldDate = end_DateTimePicker.SelectedDate.Value;
            string[] startFieldTime = startTimeTextbox.Text.Split(':');
            string[] endFieldTime = endTimeTextbox.Text.Split(':');

            DateTime startTime = new DateTime(startFieldDate.Year, startFieldDate.Month, startFieldDate.Day, int.Parse(startFieldTime[0]), int.Parse(startFieldTime[1]), 0);
            DateTime endTime = new DateTime(endFieldDate.Year, endFieldDate.Month, endFieldDate.Day, int.Parse(endFieldTime[0]), int.Parse(endFieldTime[1]), 0);


            var myElection = new Election(-1,startTime , endTime, Convert.ToString(election_Type.Text), false);
            db.AddElection(myElection);
            launchingWindow.ListAllElections();
            Close();
        }
    }
}

