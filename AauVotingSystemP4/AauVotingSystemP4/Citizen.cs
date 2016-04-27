using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Citizen
    {
        public int Cpr { get; set; }
        public bool Voteconducted { get; set; } 

        public Citizen (int Cpr, bool Voteconducted)
        {
            this.Cpr = Cpr;
            this.Voteconducted = Voteconducted;
        }
    }
}
