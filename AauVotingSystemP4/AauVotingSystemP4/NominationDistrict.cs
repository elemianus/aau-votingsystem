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
        /// Private lists from containing the results from votes ensures that the contents of the lists cant be modified. That is what the private is for.
        /// </summary>
        private List<Vote> votesinNomD = new List<Vote>();

        public List<Vote> GetVotesForNomD()
        {
            return votesinNomD;
        }
        
    }
}
