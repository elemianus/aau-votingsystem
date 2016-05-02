using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    public class ElectionAdministrator
    {

    }
    /// <summary>
    /// Here we create the election and for the election we specifically need the election_id and the election type
    /// </summary>
    public class CreateElection
    {
        private int Election_ID { get; set; }
        public string ElectionType { get; set; }
    }
}
