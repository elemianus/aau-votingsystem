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


        public CitizenModel(Citizen voted)
        {
            AddCitizen(voted);
        }
        public List<Citizen> SeeUserVotes()
        {
            return seeUserVotes;
        }

        public bool CheckUserVotes(int Cpr, bool Voteconducted)
    }
}
