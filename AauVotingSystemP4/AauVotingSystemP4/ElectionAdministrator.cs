using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class ElectionAdministrator
    {

        
        public void CreateElection(int Election_ID, DateTime StartDate, DateTime EndDate, string ElectionType)
        {
            var databaseConector = new DatabaseConnector();
            Election myElection = new Election(Election_ID, StartDate, EndDate, ElectionType);
            databaseConector.AddElection(myElection);
            //send til databasen via metode i DatabaseCOnnector
            
        }

       

    }
    /// <summary>
    /// Here we create the election and for the election we specifically need the election_id and the election type
    /// </summary>
    
}
