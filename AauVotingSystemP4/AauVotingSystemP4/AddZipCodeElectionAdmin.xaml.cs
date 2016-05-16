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
    /// Interaction logic for AddZipCodeElectionAdmin.xaml
    /// </summary>
    public partial class AddZipCodeElectionAdmin : Window
    {
        Election election;
        NominationDistrict nomD;
        ZipCode currentZipCode;
        ElectionAdmin_Homepage launchingWindow;
        public AddZipCodeElectionAdmin(Election election, NominationDistrict district, ElectionAdmin_Homepage launchingWindow, ZipCode zipCode = null)
        {
            InitializeComponent();
            this.election = election;
            this.nomD = district;
            this.currentZipCode = zipCode;
            this.launchingWindow = launchingWindow;

            if (zipCode != null) {
                zipTextBox.Text = zipCode.ZipCodeId+"";
                nameTextBox.Text = zipCode.Name;
            }
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            ZipCode zip = new ZipCode(int.Parse(zipTextBox.Text), nameTextBox.Text);
            var dbConector = new DatabaseConnector();

            if (currentZipCode == null)
            {
                dbConector.AddZipCodeToNominationDistrict(election.Election_ID, nomD.NominationDistrictId, zip);
            }
            else
            {
                dbConector.UpdateZipcodeForNominationDistrict(zip, currentZipCode,nomD);
            }

            Close();
            launchingWindow.ListZipCodes(nomD.NominationDistrictId);
        }
    }
}
