using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class will generate a series of nomination districts for an election, it is here purely for testing
    /// </summary>
    class NominationDistrictGenerator
    {
        private Election electionId;
        /// <summary>
        /// Will generate a series of nomination districts for this election
        /// </summary>
        /// <param name="electionId">The election to add for</param>
        public NominationDistrictGenerator(Election electionId)
        {
            this.electionId = electionId;

            int mandatesPrNominationDistrict = 60;
            var databaseConector = new DatabaseConnector();

            var jutland = new NominationDistrict(electionId, "Jutland", mandatesPrNominationDistrict);
            var fyn = new NominationDistrict(electionId, "Fyn", mandatesPrNominationDistrict);
            var sj = new NominationDistrict(electionId, "Sj", mandatesPrNominationDistrict);

            List<ZipCode> jutlandZip = new List<ZipCode>();
            List<ZipCode> fynZip = new List<ZipCode>();
            List<ZipCode> sjZip = new List<ZipCode>();

            jutlandZip.Add(new ZipCode(9000, "Aalborg C"));
            jutlandZip.Add(new ZipCode(8000, "Århus C"));

            fynZip.Add(new ZipCode(5000, "Odence C"));
            fynZip.Add(new ZipCode(5500, "Middelfart"));

            sjZip.Add(new ZipCode(1000, "Copenhagen K"));
            sjZip.Add(new ZipCode(2720, "Vandløse"));
            databaseConector.AddNominationDistrictWithZipCodes(electionId, jutland, jutlandZip);
            databaseConector.AddNominationDistrictWithZipCodes(electionId, fyn, fynZip);
            databaseConector.AddNominationDistrictWithZipCodes(electionId, sj, sjZip);
        }
    }
}
