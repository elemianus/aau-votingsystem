using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class ElectionAdministrator
    {


        public Election CreateElection(int Election_ID, DateTime StartDate, DateTime EndDate, string ElectionType, VotingBallot nationalVotingBallot, List<NominationDistrict> nominationDistrictsInElection)
        {
            Election myElection = new Election(Election_ID, StartDate, EndDate, ElectionType, nationalVotingBallot, nominationDistrictsInElection);
            return myElection;
        }

       

    }
    /// <summary>
    /// Here we create the election and for the election we specifically need the election_id and the election type
    /// </summary>
    
}
