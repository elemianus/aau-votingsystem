using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class can generate a list of random citizens
    /// </summary>
    class CitizenGenerator
    {
        Random random;
        public CitizenGenerator() {
            random = new Random();
        }

        /// <summary>
        /// Can generate a list of random citizens
        /// </summary>
        /// <param name="amount">The amount if citizens to gernerate</param>
        /// <returns></returns>
        public List<Citizen> GetListOfCitizen(int amount) {
            List<Citizen> citizens = new List<Citizen>();
            for (int i = 0; i < amount; i++)
                citizens.Add(GenerateCitizen());
            return citizens;
        }

        /// <summary>
        /// Generate citizen with a random birthday
        /// </summary>
        /// <returns>A Citizen</returns>
        public Citizen GenerateCitizen() {
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            int year = random.Next(1920, 1992);
            int lastDigit = random.Next(0000, 9999);

            string cpr = day + "" + month + "" + year + "" + lastDigit;
            
            return new Citizen(cpr, 9000);
        }
    }
}
