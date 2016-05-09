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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void CreateElection_Click(object sender, RoutedEventArgs e)
        {
            ElectionAdministrator myAdministrator = new ElectionAdministrator();
            myAdministrator.CreateElection(3, Convert.ToString(election_Name), Convert.ToDateTime(start_Date), Convert.ToDateTime(end_Date), Convert.ToString(election_Type));
        }
    }
}
