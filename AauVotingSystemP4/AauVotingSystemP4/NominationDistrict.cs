using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class NominationDistrict
    {
        public int NumberOfMandates { get { return numberOfMandates; } }
        private int numberOfMandates;

        private List<ZipCode> zipCodes = new List<ZipCode>();

        public NominationDistrict()
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
        /// Adds a zip code by first checking if it's already there, if not it adds the zip code to the list
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="ZipCodeId"></param>
        /// <returns>Returns true if the zip Code has been added</returns>
        public bool AddZipCode(ZipCode ZipCode, int ZipCodeId)
        {
            if (IsBallotFinalized)//what do we do with accessing this?
                return false;
            for (int i = 0; i < zipCodes.Count(); i++)
            {
                if (zipCodes[i].ZipCodeId == ZipCodeId)
                    return false; //Zip Code exists in this list already

            }
            zipCodes.Add(ZipCode);
            return true;
        }

        /// <summary>
        /// Removes a Zip Code from the list, if found.
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <returns>Returns true if the Zip code exists and has been removed</returns>
        public bool RemoveZipCode(int ZipCode)
        {
            if (IsBallotFinalized)//what do we do with accessing this?
                return false;
            for (int i = 0; i < zipCodes.Count(); i++)
            {
                if (zipCodes[i].ZipCodeId == ZipCode)
                    if (zipCodes.Remove(zipCodes[i]))
                        return true; //Zip Code exists in this list and has been removed
            }
            return false; //Zip Code Did not exists in this list
        }

    }
}
