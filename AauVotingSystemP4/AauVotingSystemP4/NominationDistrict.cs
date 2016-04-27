using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class NominationDistrict
    {

        /// <summary>
        /// Private lists co
        /// </summary>
        private List<Vote> votesinNomD = new List<Vote>();

        public List<Vote> GetVotesForNomD()
        {
            return votesinNomD;
        }
        
    }
}
