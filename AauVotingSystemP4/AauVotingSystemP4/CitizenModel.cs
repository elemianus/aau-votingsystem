using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class CitizenModel
    {

        private List<Citizen> seeUserVotes = new List<Citizen>();
        public bool HasUserVoted { get { return hasUserVoted; } }
        private bool hasUserVoted = false;


        public List<Citizen> CheckUserVotes()
        {
            return seeUserVotes;
        }

        /// <summary>
        /// Removes a specific voting option if the ballot is not finalized
        /// </summary>
        /// <param name="votionOptionId">Id of the option to remove</param>
        /// <param name="isNationalVotionOption">true if the option is a national level option</param>
        /// <returns>True if the VoteOption has been succesfully removed, otherwise false</returns>
        public bool CheckUserVotes(int CPR, bool VOTEconducted)
        {
            if (HasUserVoted)
                return false;
            for (int i = 0; i < seeUserVotes.Count(); i++)
            {
                if (seeUserVotes[i].Voteconducted == VOTEconducted && seeUserVotes[i].Cpr == CPR)
                    
                        return true; //The user has voted
            }
            return false; //The user has not voted
        }



        /// <summary>
        /// Finalizes the citizen vote 
        /// </summary>
        public void CitizenVoted()
        {
            hasUserVoted = true;
        }
    }

}

