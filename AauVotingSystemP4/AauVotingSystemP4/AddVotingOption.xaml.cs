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
    /// Interaction logic for AddVotingOption.xaml
    /// </summary>
    public partial class AddVotingOption : Window
    {
        public AddVotingOption()
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
            ConfirmAddVotingOption cavo = new ConfirmAddVotingOption();
            cavo.Show();
            this.Close();
        }
        /// <summary>
        /// This ensures that when you click on the textbox with "Type in candidate" that text will disappear and you can write from the beginning. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
