﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{

    public class Election
    {
        public int Election_ID { get; set; }       
        public DateTime StartDate;
        public DateTime EndDate;
        public string ElectionStartDateAsString {get { return ElectionStartDateToString(); } }
        public string ElectionEndDateAsString { get { return ElectionEndDateToString(); } }

        public string ElectionType { get; set; }
        private VotingBallot nationalVotingBallot;
        private List<NominationDistrict> nominationDistrictsInElection;
        public bool IsBallotFinalized { get { return isBallotFinalized; } }
        private bool isBallotFinalized = false;

        public Election(int Election_ID, DateTime StartDate, DateTime EndDate, string ElectionType,bool isBallotFinalized)
        {
            this.Election_ID = Election_ID;           
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ElectionType = ElectionType;
            this.isBallotFinalized = isBallotFinalized;
        }

        private string ElectionStartDateToString() {
            return StartDate.ToString();
        }
        private string ElectionEndDateToString()
        {
            return EndDate.ToString();
        }

        public void FinalizeBallot()
        {
            isBallotFinalized = true;
        }

        /// <summary>
        /// Here we see if the VotingBallot is fanalized (it gets finalized i VotingBallot), and if the ballot is not finalized we add the "option" to the "AddParty"-list  
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool AddPartyOption(VotingOption option)
        {
            if (IsBallotFinalized)
                return false;
            nationalVotingBallot.AddVotingOption(option);
            return true;
        }

        /// <summary>
        /// We can use this method to change the information of the election.
        /// </summary>
        public void SetUpElection(int Election_ID, DateTime StartDate, DateTime EndDate, string ElectionType, VotingBallot nationalVotingBallot, List<NominationDistrict> nominationDistrictsInElection)
        {
            this.Election_ID = Election_ID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ElectionType = ElectionType;
            this.nationalVotingBallot = nationalVotingBallot;
            this.nominationDistrictsInElection = nominationDistrictsInElection;
        }

        public void UpdateVotingBallot(VotingBallot newVotingBallot)
        {
            nationalVotingBallot = newVotingBallot;
        }
    }
}