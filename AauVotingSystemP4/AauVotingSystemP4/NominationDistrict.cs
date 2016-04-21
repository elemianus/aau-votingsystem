using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class NominationDistrict
    {
        public string NomName
        public int nomID, nomZipcodes;  //we want this to auto increment
        public string Make { get; set; }

        public int NomID {  //when adding zipcodes navnet.add (zipcode)
            get { return nomID; }
            set { if (value > 0) nomID = value; }
    }
        public int NomZipcodes{
            get { return nomZipcodes; }
            set { if (value > 0) nomZipcodes = value; }
        }
        public int zipcodesforall
}


        
        
        //This is where I tried to use the Icomparable method as a way to compare zipcodes with the NomID but it did not work

        /*public NominationsDistrict(string NomName, int NomID, int NomZipcodes)
        {
            NomName = nomname; NomID = nomid; NomZipcodes = nomzipcodes;
        }
        public override string ToString()
        {
            return String.Format("{} {}", NomName, NomID, NomZipcodes);
        }
        public int CompareTo(object other)
        {
            NominationDistrict c = (NominationDistrict)other;
            return (int)(this.NomZipcodes - c.NomZipcodes);
        }
        //we want something like a dictionary to compare zipcodes with nomID to decide which ballot the user should be able to vote from
    }
   
}
*/