using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class Citizen
    {
        public string Cpr { get; }
        public bool Voteconducted { get; }
        private bool voteConducted = false;
        public int Zipcode { get; }

        /// <summary>
        /// Setup a citizen
        /// </summary>
        /// <param name="Cpr">CPR of the citizen</param>
        /// <param name="Zipcode">The zipcode the citizen they live in</param>
        /// <param name="voteConducted">(optional) Has the citizen voted</param>
        public Citizen(string Cpr, int Zipcode, bool voteConducted = false)
        {
            this.Zipcode = Zipcode;
            this.voteConducted = voteConducted;
            this.Cpr = Cpr;
        }
    }
}



