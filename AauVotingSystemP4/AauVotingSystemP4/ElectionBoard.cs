using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class is allows the election board to add, remove and finalize a ballot for a specific nomination district.
    /// </summary>
    class ElectionBoard 
    {
        public int NominationDistrictId { get; }
        public string NominationDistrictName { get { return nominationDistrictName; }}
        private string nominationDistrictName;
        private VotingBallot ballot;


        /// <summary>
        /// When the electionboard is created it has no associated cip codes
        /// </summary>
        /// <param name="nominationDistrictName">The name of the discrict</param>
        /// <param name="AssociatedNominationDistrictId">The nomination district id surplied - this MUST be the same as in the database</param>
        /// <param name="ballot">The ballot the nominationDistrict should use</param>
        /// 
        public ElectionBoard (string nominationDistrictName, int AssociatedNominationDistrictId,VotingBallot ballot)
        {
            this.nominationDistrictName = nominationDistrictName;
            this.NominationDistrictId = AssociatedNominationDistrictId;
            this.ballot = ballot;
            
        }

        /// <summary>
        /// Finalizes the ballot so no more voting options can be added or removed
        /// </summary>
        public void FinalizeBallot() {
            this.ballot.FinalizeBallot();
        }

        /// <summary>
        /// Get all voting options for ballot.
        /// </summary>
        /// <returns>Returns all the voting option in the ballot</returns>
        public List<VotingOption> GetVotingOptions() {
            return ballot.GetVotingOptions();
        }

        /// <summary>
        /// Allows the electionboard to add voting option to their ballot
        /// </summary>
        /// <param name="firstName">First name of the candidate</param>
        /// <param name="lastName">Last name of the candidate</param>
        /// <param name="partyId">(optional) The party the candidate should be associated with</param>
        /// /// <returns>True if succesfully added, otherwise false</returns>
        public bool AddVotingOption(string firstName, string lastName, int partyId = -1) {
            VotingOption option = new VotingOption(firstName, lastName, NominationDistrictId, partyId);
            return ballot.AddVotingOption(option);
        }

        /// <summary>
        /// Removes a specific voting option
        /// </summary>
        /// <param name="votingOptionId">Id of the voting option</param>
        /// <param name="isNationalVotingOption">True if this is a nation vide option</param>
        /// <returns>True if succesfully removed, otherwise false</returns>
        public bool RemoveVotingOption(int votingOptionId,bool isNationalVotingOption = false) {
            return ballot.RemoveVotionOption(votingOptionId, isNationalVotingOption);
        }
    }
}




