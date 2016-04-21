using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{ //we want this to vary depending on the nomination district. 
    class VotingOption : VotingBallot
    {
        private string votepartyoption;
        private string votepartymemberoption;

        public VotingOption(string votepartyoption, string votepartymemberoption)
        {
            //this. is a constructor that will allow us to call one constructor with a different signature from another within the same class
            this.votepartyoption = votepartyoption;
            this.votepartymemberoption = votepartymemberoption;
        }

        public string Votepartyoption
        {
            get
            {
                return votepartyoption;
            }
        }

        public string Votepartymemberoption
        {
            get
            {
                return votepartymemberoption;
            }
        }
    }
}