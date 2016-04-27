using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Citizen
    {
        public int Cpr { get; }
        public bool Voteconducted { get; }
        private bool voteConducted = false;
        public int Zipcode { get; }

        public Citizen(int Cpr, int Zipcode,bool voteConducted=false)
        {
            this.Zipcode = Zipcode;
            this.voteConducted = voteConducted;
            this.Cpr = Cpr;
        }
    }
}
