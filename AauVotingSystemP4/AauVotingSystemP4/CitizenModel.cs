﻿using System;
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
        /// These if and for statements checks if the user has voted by checking the votes from the Citizen class (here I mean voteconducted and Cpr).
        /// </summary>
        /// <param name="CPR">Cpr of the user who has voted</param>
        /// <param name="VOTEconducted">Here it checks the boolean value for the conducted voted. True if they have voted</param>
        /// <returns></returns>
        public bool CheckUserVotes(string CPR, bool VOTEconducted)
        {
            if (HasUserVoted)
                return false;
            for (int i = 0; i < seeUserVotes.Count(); i++)
            {
                if (seeUserVotes[i].Voteconducted == VOTEconducted && seeUserVotes[i].Cpr.Equals(CPR))

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