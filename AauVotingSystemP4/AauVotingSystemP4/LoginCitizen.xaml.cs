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
            if (databaseConector.DoesCitizenExist(TypeInUsername.Text)) {
                //Citizen exists

                MainWindow mw = new MainWindow();
                mw.Show();
            }
            else
            {
                MessageBox.Show("The CPR-number do not exist. \n Try again.");
            }
            //if (databaseConector.DoesCitizenExist(userInput))
            //{
            //MainWindow mw = new MainWindow();
            //mw.Show();
            //}
            //else
            //{
            //    Console.WriteLine("CPR-number do not exits. Try again");
            //}
        }
    }
}
