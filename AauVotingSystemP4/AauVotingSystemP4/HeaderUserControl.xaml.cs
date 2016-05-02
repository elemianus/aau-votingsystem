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
    /// Interaction logic for HeaderUserControl.xaml
    /// </summary>
    public partial class HeaderUserControl : UserControl
    {
        public string LogoutText
        {
            get { return (string)GetValue(LogoutTextProperty); }
            set { SetValue(LogoutTextProperty, value); }
        }

        public static readonly DependencyProperty LogoutTextProperty =
            DependencyProperty.Register("LogoutText", typeof(string), typeof(HeaderUserControl), new UIPropertyMetadata(""));

        public HeaderUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        //This is the "Back to frontpage"-function, when the user clicks it, they come back to the frontpage, which is the window called "MainWindow"
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
