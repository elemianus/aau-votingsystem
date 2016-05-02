using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{

    public class Election
    {

        public string ElectionName { get; set; }
        public int ElectionID { get; set; } //we want this to auto increment
        public string ElectionType { get; set; }  //here we may be able to make something smarter depending on how many electiontypes there is eg. an enum.
        public DateTime StartDate { get; set; }     //i have made it datetime, but we need to check how to work it out with start and end dates.
        public DateTime EndDate { get; set; }

        public Election(string en, int EiD, string et, DateTime d)
        {
            ElectionName = en; ElectionID = EiD; ElectionType = et; StartDate = d; EndDate = d;
        }

        public int GetDates()
        {
            DateTime today = DateTime.Today;
            int date = today.Day - StartDate.Day;
            if (today)
        } 
    }
    
/*
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
     */   }
        public Election()
        {
            this.ElectionID = System.Threading.Interlocked.Increment(ref ElectionID);
        }
        public int Election_ID
        {
            get
            {
                return ElectionID;
            }
        }
        
        
    }
    public class datetimes : Election
    {
        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; set; }

        public new void StartDate()
        {
            StartAt = DateTime.Now;

            base.StartDate();

        }

        public new void EndDate()
        {
            EndAt = DateTime.Now;

            base.EndDate();

        }

        public new void Reset()
        {
            StartAt = null;
            EndAt = null;

            base.Reset();
        }

        public new void Restart()
        {
            StartAt = DateTime.Now;
            EndAt = null;

            base.Restart();
        }
    }
}
