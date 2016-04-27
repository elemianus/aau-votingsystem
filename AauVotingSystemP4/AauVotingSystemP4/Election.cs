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
        public static DateTime StartDate = new DateTime(2016, 9, 12, 09, 00, 00);
        public static DateTime EndDate = new DateTime(2016, 9, 12, 20, 00, 00);
        public string ElectionType { get; set; }
        private List<AddParty> partyOption = new List<AddParty>();
        public bool IsBallotFinalized { get { return isBallotFinalized; } }
        private bool isBallotFinalized = false;

        /// <summary>
        /// Here we can add the parties
        /// </summary>
        public class AddParty
        {
            int PartyId;
            string PartyName;

            public AddParty(string PartyName, int PartyId)
            {
            }

        }
        /// <summary>
        /// Here we see if the VotingBallot is fanalized (it gets finalized i VotingBallot), and if the ballot is not finalized we add the "option" to the "AddParty"-list  
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool AddPartyOption(AddParty option)
        {
            if (IsBallotFinalized)
                return false;
            partyOption.Add(option);
                return true;
        }

        public class SetUpElection
        {
            
        }
    }
}
