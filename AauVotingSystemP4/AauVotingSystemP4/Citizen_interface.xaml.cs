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
    /// Interaction logic for Citizen_interface.xaml
    /// </summary>
    public partial class Citizen_interface : UserControl
    {
        public Citizen_interface()
        {
            InitializeComponent();
        }

        private void SeePreviouslyElections_Click(object sender, RoutedEventArgs e)
        {
            //Når man trykker på "See Previously Elections" skal man herinde definere hvad der skal ske.
            //Dette her er en test på om det virker:
            TestPreviouslyElection.Text = "Ja, det virker!";
        }
    }
}
