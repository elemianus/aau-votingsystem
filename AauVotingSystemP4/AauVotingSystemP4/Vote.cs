using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Vote
    {
        public int VotingOptionId { get; set; }
        public string CandidateNominationDistrict { get; set; }

        public Vote(int VotingOptionId, string CandidateNominationDistrict)
        {
            this.VotingOptionId = VotingOptionId;
            this.CandidateNominationDistrict = CandidateNominationDistrict;
        }
    }
}
