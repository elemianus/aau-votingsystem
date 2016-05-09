using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{

    public class Election
    {
        private int Election_ID { get; set; }
        public DateTime StartDate;
        public DateTime EndDate;
        public string ElectionType { get; set; }
        private VotingBallot nationalVotingBallot;
        private List<NominationDistrict> nominationDistrictsInElection;
        public bool IsBallotFinalized { get { return isBallotFinalized; } }
        private bool isBallotFinalized = false;

        public Election(int Election_ID, DateTime StartDate, DateTime EndDate, string ElectionType, VotingBallot nationalVotingBallot, List<NominationDistrict> nominationDistrictsInElection)
        {
            this.Election_ID = Election_ID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ElectionType = ElectionType;
            this.nationalVotingBallot = nationalVotingBallot;
            this.nominationDistrictsInElection = nominationDistrictsInElection;
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
        /// Here we start the election. We include the start- and end date for the election, and we includes the NominationDestrict_ID, so we know which NominationDestrict there will be in the election
        /// </summary>
        public class SetUpElection
        {
            public static DateTime StartOfElection = new DateTime(2016, 09, 01, 09, 00, 00);
            public static DateTime EndOfElection = new DateTime(2016, 09, 12, 20, 00, 00);
            public int NominationDestrict_ID { get; set;}
        }
    }
}