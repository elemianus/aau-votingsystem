using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class VoteResult
    {
        public int partyId;
        public int amountOfVotes;
        public int nominationDistrictId;

        public VoteResult(int partyId, int amountOfVotes, int nominationDistrictId)
        {
            this.partyId = partyId;
            this.amountOfVotes = amountOfVotes;
            this.nominationDistrictId = nominationDistrictId;
        }
        
    }
}
