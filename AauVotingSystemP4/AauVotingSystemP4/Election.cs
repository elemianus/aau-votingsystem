using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4 { 

    public class Election
    {

        public string ElectionName;
        public int ElectionID; //we want this to auto increment
        public string ElectionType;  //here we may be able to make something smarter depending on how many electiontypes there is eg. an enum.
        public DateTime StartDate;     //i have made it datetime, but we need to check how to work it out with start and end dates.
        public DateTime EndDate;
        public string Results;

        //behold this dope constructor. When making an election u can use 'Election parliaelection = new Election (name, type, startdate, enddate);' 
        //(Daniel) Jeg har tilføjet results som en interger (ved at kigge på use cases kan jeg se vi også skal være i stand til at se results)       
        public Election (string ElectionName, int ElectionID, string ElectionType, DateTime StartDate, DateTime EndDate, string Results)
        {
            this.ElectionName = ElectionName;
            this.ElectionID = ElectionID;
            this.ElectionType = ElectionType;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Results = Results;

            
        }

    }
}
