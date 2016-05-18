using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class VoteResult : IComparable<VoteResult>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int CandidateId { get; }
        public int PartyId { get; }
        public int AmountOfVotes { get; }
        public int NominationDistrictId { get; }
        public bool IsNationalVotingOption { get; }

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
            if (this.AmountOfVotes < other.AmountOfVotes)
                return 1;
            else
                return -1;
        }
    }
}
