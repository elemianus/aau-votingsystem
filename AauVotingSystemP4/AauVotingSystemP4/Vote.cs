using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Vote
    {
<<<<<<< HEAD
        public int VotingOptionId { get; set; }
        public string CandidateNominationDistrict { get; set; }

        public Vote(int VotingOptionId, string CandidateNominationDistrict)
        {
            this.VotingOptionId = VotingOptionId;
            this.CandidateNominationDistrict = CandidateNominationDistrict;
=======
        public int VotingOptionId { get; }
        bool IsNationalVotingOption { get; }
        /// <summary>
        /// The nomination district that the vote has been cast in
        /// </summary>
        public int NominationDistrictId { get; }

        /// <summary>
        /// Creates new vote
        /// </summary>
        /// <param name="VotingOptionId">The VotingId</param>
        /// <param name="NominationDistrictId">The nomination district that the vote has been cast in</param>
        /// /// <param name="IsNationalVotingOption">Weather or not this is a vote for a national voting option</param>
        public Vote(int VotingOptionId, bool IsNationalVotingOption, int NominationDistrictId )
        {
            this.VotingOptionId = VotingOptionId;
            this.NominationDistrictId = NominationDistrictId;
            this.IsNationalVotingOption = IsNationalVotingOption;
>>>>>>> master
        }
    }
}