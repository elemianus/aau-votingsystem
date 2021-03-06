﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// Represents a zipcode and the people in that zip code
    /// </summary>
    public class ZipCode
    {
        public int ZipCodeId { get; }
        public string Name { get; }
        private List<Citizen> citizensInThisZipCode = new List<Citizen>();
        public ZipCode(int ZipCode,string name)
        {
            ZipCodeId = ZipCode;
            this.Name = name;
        }

        /// <summary>
        /// Gets all citizens in this cipcode
        /// </summary>
        /// <returns>Returns all citizens in this zipcode</returns>
        public List<Citizen> GetAllCitizens() {
            return citizensInThisZipCode;
        }

        /// <summary>
        /// Add list of Citizens to this zip code ONLY if the zip codes are the same
        /// </summary>
        /// <param name="input">The citizens to add</param>
        public void AddListOfCitizensToZipCode(List<Citizen> input) {
            foreach(Citizen item in input) { 
                if(item.Zipcode == ZipCodeId)
                    citizensInThisZipCode.Add(item);
            }
        }

        /// <summary>
        /// Add a citizen to zipcode ONLY IF the zip codes are the same 
        /// </summary>
        /// <param name="input">The citizen to add</param>
        public void AddCitizenToZipCode(Citizen input) {
            if(ZipCodeId == input.Zipcode)
            citizensInThisZipCode.Add(input);
        }
    }
}
