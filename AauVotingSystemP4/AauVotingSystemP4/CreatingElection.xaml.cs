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
        public ElectionAdministrator myAdmin;
        
        public CreatingElection()
        {
            myAdmin = new ElectionAdministrator();
            InitializeComponent();
            
        }

      
        
        private void CreateElection_Click(object sender, RoutedEventArgs e)
        {      
                      
            myAdmin.CreateElection(3, Convert.ToString(election_Name.Text), start_DateTimePicker.SelectedDate.Value, end_DateTimePicker.SelectedDate.Value, Convert.ToString(election_Type.Text));
            MessageBox.Show(myAdmin.myElection.ElectionName);
            CreatingElectionTestWindow evb = new CreatingElectionTestWindow(myAdmin);
            evb.Show();
        }
    }
}
