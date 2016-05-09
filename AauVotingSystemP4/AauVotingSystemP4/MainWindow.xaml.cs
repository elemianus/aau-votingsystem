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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Main.Content = new Citizen_Homepage();
            Citizen_Homepage c_h = new Citizen_Homepage();
            Main.NavigationService.Navigate(c_h);

            DatabaseConnector conector = new DatabaseConnector();
            VotingOption option = new VotingOption("Øl partiet", "", 2, 2);
            option.IsNationalVotingOption = true;
            Election election = new Election();
            election.Election_ID = 3;

            NominationDistrict districts = new NominationDistrict(election, "Aalbrog centrum", 2);
            conector.AddCitizen(new Citizen("1212901234", 3700));
            conector.GetAllCitizens();
        }
    }
}
