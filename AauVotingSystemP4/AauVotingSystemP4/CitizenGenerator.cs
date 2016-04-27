using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class will generate a list of random citizens
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

        public Citizen GenerateCitizen() {
            int day = random.Next(1, 30);
            int month = random.Next(1, 12);
            int year = random.Next(1920, 2016);
            int lastDigit = random.Next(0000, 9999);

            string name = day + "" + month + "" + year + "" + lastDigit;

            Citizen item = new Citizen(Int32.Parse(name), 9000);
            return item;
        }
    }
}
