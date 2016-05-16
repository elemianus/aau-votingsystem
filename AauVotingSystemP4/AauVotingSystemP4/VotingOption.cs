using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class VotingOption
    {
        public bool IsNationalVotingOption = false;
        public int VotingOptionId { get; }
        public int NominationDistrictId { get; }
        public int PartyId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        /// <summary>
        /// Constructor for the voting option
        /// </summary>
        /// <param name="FirstName">Firstname of the candidate</param>
        /// <param name="LastName">Lastname of the candidate</param>
        /// <param name="NominationDistrictId">The id of the district</param>
        /// <param name="PartyId">(optional)The partyid</param>
        /// <param name="VotingOptionId">(optional) the id of the VotionOption if it is known</param>
        public VotingOption(string FirstName, string LastName, int NominationDistrictId, int PartyId = -1, int VotingOptionId = -1)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NominationDistrictId = NominationDistrictId;
            this.PartyId = PartyId;
            this.VotingOptionId = VotingOptionId;
        }
        public override string ToString()
        {
            string returnSting = "";
            if (IsNationalVotingOption)
                returnSting += "National option: ";
            returnSting += FirstName + " " + LastName + " ";
            return returnSting;
        }
    }
}

