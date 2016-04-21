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
    /// Interaction logic for AddConfirmation.xaml
    /// </summary>
    public partial class AddConfirmation : Window
    {
        public AddConfirmation()
        {
            InitializeComponent();
        }

        private void Homepage_Click(object sender, RoutedEventArgs e)
        {
            ElectionboardMainWindow emw = new ElectionboardMainWindow();
            emw.Show();
        }
    }
}
