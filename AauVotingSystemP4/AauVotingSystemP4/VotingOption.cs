using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{ //we want this to vary depending on the nomination district. 
    public class VotingOption : NominationDistrict
    {
        //der skal så vidt jeg kan se ikke være en votingBallot, en Votingoption er nok. 
        //I have done it so that the voting ballot section here contains the voting options.
        public string votecandidate;
        public string voteparty;
        public int vote;
        
        public VotingOption(string candidate, string party, int vote)
        {
            this.votecandidate = candidate;
            this.voteparty = party;
            this.vote = vote;
        }
        public string Candidate //the following public strings, get and returns as access methods. This specific is a specific access method for candidate
        {
            get
            {
                return votecandidate;
            }
        }

        public string Party //this is an access method for the party you vote for
        {
            get
            {
                return voteparty;
            }
        }
        //change delete this
        public int Votes //access method for the number of votes being cast.
        {
            get
            {
                return vote;
            }
        }
    }
}

