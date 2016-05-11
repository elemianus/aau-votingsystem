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
        public int NominationDistrictId { get; }
        public string Name { get; }
        private List<ZipCode> zipCodes = new List<ZipCode>();
        private VotingBallot nomDBallot;
        private Election associatedElection;

        public NominationDistrict(Election associatedElection, string name, int numberOfMandates, int nominationDistrictId = -1)
        {
            this.associatedElection = associatedElection;
            this.Name = name;
            this.numberOfMandates = numberOfMandates;
            if (nominationDistrictId != -1)
                this.NominationDistrictId = nominationDistrictId;
        }


        /// <summary>
        /// Adds a voting option to the nomdBallot.
        /// </summary>
        /// <param name="option"></param>
        /// <returns>returns true if added</returns>
        public bool AddPartyOptionToNomD(VotingOption option)
        {
            if (associatedElection.IsBallotFinalized)
                return false;
            nomDBallot.AddVotingOption(option);
            return true;
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

        public void AddRangeOfZipCodes(List<ZipCode> codes)
        {
            zipCodes.AddRange(codes);
        }


        /// <summary>
        /// Adds a zip code by first checking if it's already there, if not it adds the zip code to the list
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="ZipCodeId"></param>
        /// <returns>Returns true if the zip Code has been added</returns>
        public bool AddZipCode(ZipCode ZipCode, int ZipCodeId)
        {
            if (associatedElection.IsBallotFinalized)//what do we do with accessing this?
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
            if (associatedElection.IsBallotFinalized)//what do we do with accessing this?
                return false;
            for (int i = 0; i < zipCodes.Count(); i++)
            {
                if (zipCodes[i].ZipCodeId == ZipCode)
                    if (zipCodes.Remove(zipCodes[i]))
                        return true; //Zip Code exists in this list and has been removed
            }
            return false; //Zip Code Did not exists in this list
        }



        /// <summary>
        /// Checks if a citizen actually belongs to the given nominationdistrict
        /// </summary>
        /// <param name="zipcode"></param>
        /// <param name="citizen"></param>
        /// <param name="nominationdistrict"></param>
        /// <returns>true if the citizen belongs to the district / false if not </returns>
        public bool CitizenInNominationDistrict(Citizen citizen, NominationDistrict nominationDistrict)
        {
            int citizenZipCode = citizen.Zipcode;
            foreach (ZipCode number in nominationDistrict.zipCodes)
            {
                if (number.ZipCodeId == citizen.Zipcode)
                {
                    return true;
                }
            }
          return false;

        }

    }
}
