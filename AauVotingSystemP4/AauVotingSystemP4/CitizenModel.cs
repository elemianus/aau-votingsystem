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