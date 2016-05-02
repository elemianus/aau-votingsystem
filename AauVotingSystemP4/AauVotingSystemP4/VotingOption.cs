using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{ 
    public class VotingOption
    {
        public bool IsNationalVotionOption = false;
        public int VotingOptionId { get { return votingOptionId; } }
        private int votingOptionId;
        public string CandidateNominationDistrict { get; set; }
        public string NameOfVotingOption { get; set; }

        public VotingOption ( bool IsNationalVotionOption, int votingOptionId, string CandidateNominationDistrict, string NameOfVotingOption)
        {          
            this.IsNationalVotionOption = IsNationalVotionOption;
            this.votingOptionId = votingOptionId;
            this.CandidateNominationDistrict = CandidateNominationDistrict;
            this.NameOfVotingOption = NameOfVotingOption;
        }
       
    }
}

