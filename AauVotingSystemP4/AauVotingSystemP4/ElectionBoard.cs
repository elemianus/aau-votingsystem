using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class is surposed to handle the voting ballot for a specific nomination district.
    /// </summary>
    class ElectionBoard 
    {
        public int AssociatedNominationDistrict { get; }
        public string NominationDistrictName { get { return nominationDistrictName; }}
        private string nominationDistrictName;


        /// <summary>
        /// When the electionboard is created it has no associated cip codes
        /// </summary>
        /// <param name="nominationDistrictName">The name of the discrict</param>
        /// <param name="AssociatedNominationDistrict">The nomination district id surplied - this MUST be the same as in the database</param>
        public ElectionBoard (string nominationDistrictName, int AssociatedNominationDistrict)
        {
            this.nominationDistrictName = nominationDistrictName;
            this.AssociatedNominationDistrict = AssociatedNominationDistrict;
        }
    }
}




