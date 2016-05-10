using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class ElectionAdministrator
    {

        
        public void CreateElection(int Election_ID, string ElectionName, DateTime StartDate, DateTime EndDate, string ElectionType)
        {
            Election myElection = new Election(Election_ID, ElectionName, StartDate, EndDate, ElectionType);
            //send til database

        }

       

    }
    /// <summary>
    /// Here we create the election and for the election we specifically need the election_id and the election type
    /// </summary>
    
}
