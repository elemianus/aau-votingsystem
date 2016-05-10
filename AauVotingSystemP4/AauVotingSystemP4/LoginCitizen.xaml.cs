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
    /// Interaction logic for LoginCitizen.xaml
    /// </summary>
    public partial class LoginCitizen : Page
    {
        
        
        public LoginCitizen()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var databaseConector = new DatabaseConnector();
            databaseConector.AddVotionOPtion(TypeInUsername, 2);
            try
            {
                string Query "SQL" + this.TypeInUsername
            }
            catch (Exception wrongUsername)
            {

            }
        }
    }
}
