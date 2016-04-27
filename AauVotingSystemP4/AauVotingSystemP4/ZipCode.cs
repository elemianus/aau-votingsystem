using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// Represents a zipcode and the people in that zip code
    /// </summary>
    class ZipCode
    {
        public int ZipCodeId { get; set; }
        private List<Citizen> citizensInThisZipCode = new List<Citizen>();
        public ZipCode(int ZipCode)
        {
            ZipCodeId = ZipCode;
        }

        /// <summary>
        /// Gets all citizens in this cipcode
        /// </summary>
        /// <returns>Returns all citizens in this zipcode</returns>
        public List<Citizen> GetAllCitizens() {
            return citizensInThisZipCode;
        }

        /// <summary>
        /// Add list of Citizens to this zip code
        /// </summary>
        /// <param name="input">The citizens to add</param>
        public void AddListOfCitizensToZipCode(List<Citizen> input) {
            citizensInThisZipCode.AddRange(input);
        }

        /// <summary>
        /// Add a citizen to zipcode
        /// </summary>
        /// <param name="input">The citizen to add</param>
        public void AddCitizenToZipCode(Citizen input) {
            citizensInThisZipCode.Add(input);
        }
    }
}
