using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class ElectionBoard 
    {
        public int EbID;
        public string NomName;
        public int[] NomZipcodes;

        public ElectionBoard (string NomName, int[] NomZipcodes, int EbID)
        {
            this.NomName = NomName;
            this.NomZipcodes = NomZipcodes;
            this.EbID = EbID;

           
           
        }
    }
}




