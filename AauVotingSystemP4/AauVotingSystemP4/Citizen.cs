using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
<<<<<<< HEAD

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

        /// <summary>
        /// Here we start the election. We include the start- and end date for the election, and we includes the NominationDestrict_ID, so we know which NominationDestrict there will be in the election
        /// </summary>
        public class SetUpElection
        {
            public static DateTime StartOfElection = new DateTime(2016, 09, 01, 09, 00, 00);
            public static DateTime EndOfElection = new DateTime(2016, 09, 12, 20, 00, 00);
            public int NominationDestrict_ID { get; set; }
        }
    }
}
=======
    public class Citizen
    {
        public string Cpr { get; }
        public bool Voteconducted { get; }
        private bool voteConducted = false;
        public int Zipcode { get; }

        /// <summary>
        /// Setup a citizen
        /// </summary>
        /// <param name="Cpr">CPR of the citizen</param>
        /// <param name="Zipcode">The zipcode the citizen they live in</param>
        /// <param name="voteConducted">(optional) Has the citizen voted</param>
        public Citizen(string Cpr, int Zipcode, bool voteConducted = false)
        {
            this.Zipcode = Zipcode;
            this.voteConducted = voteConducted;
            this.Cpr = Cpr;
        }
    }
}



>>>>>>> master
