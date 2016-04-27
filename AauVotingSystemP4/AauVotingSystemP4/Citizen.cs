using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class Citizen : NominationDistrict
    {
        public int Cpr { get; set; }
        public int CitZipcode { get; set; }
        public bool Voteconducted { get; set; } 

        //behold this dope constructor. When making a Cititzen u can use 'Citizen cituser = new Election (Cpr, zipcode, voteconducted);' 
        public Citizen (int Cpr, int CitZipcode, bool Voteconducted)
        {
            this.Cpr = Cpr;
            this.CitZipcode = CitZipcode;
            this.Voteconducted = Voteconducted;
        }
    }
}
