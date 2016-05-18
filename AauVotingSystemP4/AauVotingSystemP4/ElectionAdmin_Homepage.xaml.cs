﻿using System;
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
    /// Interaction logic for ElectionAdmin_Homepage.xaml
    /// </summary>
    public partial class ElectionAdmin_Homepage : Window
    {
        private Election currentElection;
        private NominationDistrict currentNominationDistrict;
        private List<NominationDistrict> nominationDistricts;
        private ZipCode curentZipCode;
        private VotingOption currentParty;
        public ElectionAdmin_Homepage(Election currentElection)
        {
            InitializeComponent();
            this.currentElection = currentElection;
            DisplayElection(currentElection);
            ListAllNominationDistricts();
            UpdateListOfNationalVotingOptions();
        }

        public void DisplayElection(Election election) {
            currentElection = election;
            electionNameLabel.Content = currentElection.ElectionType + " " + currentElection.StartDate;
        }

        public void ListAllNominationDistricts()
        {
            if (currentElection != null)
            {
                var databaseConector = new DatabaseConnector();
                nominationDistricts = databaseConector.GetNominationDistrictsForElection(currentElection);

                nominationDistrictListView.ItemsSource = nominationDistricts;
            }
        }

        public void UpdateListOfNationalVotingOptions()
        {
            var databaseConector = new DatabaseConnector();
            PartiesListView.ItemsSource = databaseConector.GetListOfNationalVotionOptions(currentElection.Election_ID);

        }

        private void ListAllCandidatesForNominationDistrict()
        {
            var databaseConector = new DatabaseConnector();
            CandidatesListview.ItemsSource = databaseConector.GetVotingOptionForNominationDistrict(currentNominationDistrict.NominationDistrictId, currentElection.Election_ID);
        }



        public void ListZipCodes(int nominationId)
        {
            var databaseConector = new DatabaseConnector();
            List<ZipCode> zipCodes = databaseConector.GetAllZipCodesForNominationDistrict(nominationId);
            ZipDistrictListView.ItemsSource = zipCodes;
        }

        void NominationDistrictSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as NominationDistrict;
            currentNominationDistrict = selectedItem;
            if (currentNominationDistrict != null)
            {
                ListZipCodes(currentNominationDistrict.NominationDistrictId);
                ListAllCandidatesForNominationDistrict();
            }
        }

        private void createNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            AddNominationDistrict addNominationDistrict = new AddNominationDistrict(currentElection, this);
            addNominationDistrict.Show();
        }

        private void editNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null) //Check if nomination district is selected
            {
                AddNominationDistrict addNominationDistrict = new AddNominationDistrict(currentElection, this, currentNominationDistrict.NominationDistrictId);
                addNominationDistrict.Show();
            }
        }

        private void removeNominationDistrictButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null) //Check if nomination district is selected
            {

                var dbConector = new DatabaseConnector();
                //We must check if there is any remaning voteoptions in the nomination district. If there is the election administrator does not have the rights to delete it
                if (dbConector.GetVotingOptionForNominationDistrict(currentNominationDistrict.NominationDistrictId, currentElection.Election_ID).Count == 0)
                {
                    if (currentNominationDistrict != null)
                    {
                        dbConector.DeleteNominationDistrict(currentNominationDistrict);
                        ListAllNominationDistricts();
                    }
                    currentNominationDistrict = null;
                }
                else {
                    MessageBox.Show("You cannont delete the nomination district, before it is out of voting options");
                }
            }
        }

        private void createZipCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null)
            {
                var window = new AddZipCodeElectionAdmin(currentElection, currentNominationDistrict, this);
                window.Show();
            }
        }

        private void editZipCodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNominationDistrict != null && curentZipCode != null)
            {
                var window = new AddZipCodeElectionAdmin(currentElection, currentNominationDistrict, this, curentZipCode);
                window.Show();
            }
        }

        private void ZipDistrictListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as ZipCode;
            curentZipCode = selectedItem;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (curentZipCode != null && currentNominationDistrict != null)
            {
                var dbConector = new DatabaseConnector();
                dbConector.DeleteZipCode(curentZipCode, currentNominationDistrict);
                ListZipCodes(currentNominationDistrict.NominationDistrictId);
            }
        }


        private void PartiesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as VotingOption;
            currentParty = selectedItem;
        }

        private void createNationalVotingOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentElection != null)
            {
                var window = new ElectionAdmin_AddEditParty(this, currentNominationDistrict, currentElection.Election_ID);
                window.Show();
            }
        }

        private void editNationalVotingOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentElection != null && currentParty != null)
            {
                var window = new ElectionAdmin_AddEditParty(this, currentNominationDistrict, currentElection.Election_ID, currentParty);
                window.Show();
            }
        }

        private void removeNationalVotingOptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentParty != null)
            {
                var db = new DatabaseConnector();
                if (db.DeleteVotionOption(currentParty,currentElection.Election_ID))
                {
                    UpdateListOfNationalVotingOptions();
                }
                else {
                    MessageBox.Show("This party stil has members, you cannot delete it");
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (currentElection != null)
            {
                AdministrateElectionEdit evb = new AdministrateElectionEdit(currentElection, this);
                evb.Show();
            }
        }
    }
}

