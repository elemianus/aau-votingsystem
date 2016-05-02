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
    /// Interaction logic for DeleteVotingOption.xaml
    /// </summary>
    public partial class DeleteVotingOption : Window
    {
        public DeleteVotingOption()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddVotingOption avo = new AddVotingOption();
            avo.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteVotingOption dvo = new DeleteVotingOption();
            dvo.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDeleteVotingOption cdvo = new ConfirmDeleteVotingOption();
            cdvo.Show();
            this.Close();
        }
    }
}
