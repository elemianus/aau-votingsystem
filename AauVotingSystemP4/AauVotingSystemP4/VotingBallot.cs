using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class VotingBallot {

        private List<VotingOption> votingOptions = new List<VotingOption>();


        /// <summary>
        /// A ballot can only be inizialised with a voting option. A ballot cannot exist without a voting option
        /// </summary>
        /// <param name="option">Voting option to be added</param>
        public VotingBallot(VotingOption option) {
            AddVotingOption(option);
        }

        public List<VotingOption> GetVotingOptions() {
            return votingOptions;
        }

        /// <summary>
        /// Removes a specific voting option
        /// </summary>
        /// <param name="votionOptionId">Id of the option to remove</param>
        /// <param name="isNationalVotionOption">true if the option is a national level option</param>
        /// <returns>True if the VoteOption has been succesfully removed, otherwise false</returns>
        public bool RemoveVotionOption(int votionOptionId, bool isNationalVotionOption) {
            for (int i = 0; i < votingOptions.Count(); i++) {
                if (votingOptions[i].IsNationalVotingOption == isNationalVotionOption && votingOptions[i].VotingOptionId == votionOptionId)
                    if (votingOptions.Remove(votingOptions[i]))
                        return true; //Vote option exists in this list and has been removed
            }
            return false; //VoteOption Did not exists in this list
        }


        /// <summary>
        /// Adds a voting option to the ballot
        /// </summary>
        /// <param name="option">VoteOption to be added</param>
        /// <returns>True if succesfully added</returns>
        public bool AddVotingOption(VotingOption option) {
            votingOptions.Add(option);
            return true;
        }
    }
    
}
