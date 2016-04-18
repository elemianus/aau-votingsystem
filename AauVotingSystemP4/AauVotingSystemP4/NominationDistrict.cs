using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class NominationDistrict
    {
        public string NomName;
        public int NomID; //we want this to auto increment
        public int[] NomZipcodes; //when adding zipcodes navnet.add (zipcode)
        
        //we want something like a dictionary to compare zipcodes with nomID to decide which ballot the user should be able to vote from
    }
}
