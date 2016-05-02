using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Citizen
    {

        public int Cpr { get { return cpr; } }
        private int cpr;
        public bool Voteconducted = false;

        public Citizen (int cpr, bool Voteconducted)
        {
           
            this.Voteconducted = Voteconducted;
            this.cpr = cpr;
        }
    }
}
