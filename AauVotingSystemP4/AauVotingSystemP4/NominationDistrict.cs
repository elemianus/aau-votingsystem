using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class NominationDistrict
    {
        private List<ZipCode> zipCodes = new List<ZipCode>(); 

        public NominationDistrict ()
        {

        }
        /// <summary>
        /// Private lists from containing the results from votes ensures that the contents of the lists cant be modified. That is what the private is for.
        /// </summary>
        private List<Vote> votesinNomD = new List<Vote>();

        public List<Vote> GetVotesForNomD()
        {
            return votesinNomD;
        }

        /// <summary>
        /// Get all zip codes in the district
        /// </summary>
        /// <returns>The zip codes in this district</returns>
        public List<ZipCode> GetZipCodes()
        {
            return zipCodes;
        }

        /// <summary>
        /// Add a zip code to the district
        /// </summary>
        /// <param name="ZipCode">The zipcode to add</param>
        public void AddZipCode(ZipCode ZipCode)
        {
            zipCodes.Add(ZipCode);
        }

    }
}
