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
    /// Interaction logic for ConfirmDeleteVotingOption.xaml
    /// </summary>
    public partial class ConfirmDeleteVotingOption : Window
    {
        public ConfirmDeleteVotingOption()
        {
            InitializeComponent();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDeleteVotingOption cdvo = new ConfirmDeleteVotingOption();
            cdvo.Show();
            this.Close();
        }
    }
}
