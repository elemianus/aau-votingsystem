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
    /// Interaction logic for HeaderElectionAdmin.xaml
    /// </summary>
    public partial class HeaderElectionAdmin : UserControl
    {
        public HeaderElectionAdmin()
        {
            InitializeComponent();

        }
        private void Homepage_Click(object sender, RoutedEventArgs e)
        {
            ElectionAdminMainWindow emw = new ElectionAdminMainWindow();
            emw.Show();
        }

        private void Homepage_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
