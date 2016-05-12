using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class VoteResult
    {
        public string FirstName;
        public string LastName;
        public int CandidateId;
        public int PartyId;
        public int AmountOfVotes;
        public int NominationDistrictId;
        public bool IsNationalVotingOption;

        public VoteResult(string firstName, string lastName, int candidateIdOrPartyId, int amountOfVotes, int nominationDistrictId,bool isNationalVotingOption) {
            this.FirstName = firstName;
            this.LastName = lastName;
            if (isNationalVotingOption)
                this.PartyId = candidateIdOrPartyId;
            else
                this.CandidateId = candidateIdOrPartyId;
            this.AmountOfVotes = amountOfVotes;
            this.NominationDistrictId = nominationDistrictId;
            this.IsNationalVotingOption = isNationalVotingOption;
        }
        
    }
}
