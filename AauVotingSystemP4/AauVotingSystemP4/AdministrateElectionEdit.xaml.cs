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
        bool isBallotFinalized;
        Election myElection;
        public AdministrateElectionEdit(int electionId)
        {
            DatabaseConnector myConnector = new DatabaseConnector();
            this.myElection =  myConnector.GetElection(electionId);      
            InitializeComponent();
            type_Of_Election.Text = myElection.ElectionType;
            startdate.SelectedDate = myElection.StartDate;
            enddate.SelectedDate = myElection.EndDate;
            this.isBallotFinalized = myElection.IsBallotFinalized;
            
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

            MessageBox.Show(isBallotFinalized.ToString());
        }
    }
}
//System.Windows.Controls.Button: Select election