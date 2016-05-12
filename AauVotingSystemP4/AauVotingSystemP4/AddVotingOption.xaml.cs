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

        private void HeaderElectionboard_Loaded(object sender, RoutedEventArgs e)
        {

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            var partycandidateelections = databaseConector.GetAllElections();
            var displayList = new List<AddVotingOptionDisplay>();
            foreach (var item in partycandidateelections)
            {
                displayList.Add(new AddVotingOptionDisplay() { ElectionId = item.Election_ID, FirstName = item.ElectionType, IsBallotFinalized = item.IsBallotFinalized, });
            }
            AddorRemoveListView.ItemsSource = displayList;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                
            }
        }

        public class AddVotingOptionDisplay
        {
            public string FirstName { get; set; }
            public int Party { get; set; }

            public int ElectionId { get; set; }

            public bool IsBallotFinalized { get; set; }

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
