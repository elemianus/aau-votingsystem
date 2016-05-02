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
    /// Interaction logic for ElectionboardMainWindow.xaml
    /// </summary>
    public partial class ElectionboardMainWindow : Window
    {
        //This decides what shold be in the frame which we have in the xaml. In this case it is the Electionboard_Homepage that is showed in the frame
        public ElectionboardMainWindow()
        {
            InitializeComponent();
            Main.Content = new Electionboard_Homepage();
        }
    }
}
