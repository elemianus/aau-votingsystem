using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class VoteResult : IComparable<VoteResult>
    {
        public string FirstName;
        public string LastName;
        public int CandidateId;
        public int PartyId;
        public int AmountOfVotes;
        public int NominationDistrictId;
        public bool IsNationalVotingOption;

        public VoteResult(string firstName, string lastName, int candidateId, int partyId, int amountOfVotes, int nominationDistrictId, bool isNationalVotingOption)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PartyId = partyId;
            this.CandidateId = candidateId;
            this.AmountOfVotes = amountOfVotes;
            this.NominationDistrictId = nominationDistrictId;
            this.IsNationalVotingOption = isNationalVotingOption;
        }

        public int CompareTo(VoteResult other)
        {
            if (this.AmountOfVotes > other.AmountOfVotes)
                return 1;
            else
                return -1;
        }
    }
}
