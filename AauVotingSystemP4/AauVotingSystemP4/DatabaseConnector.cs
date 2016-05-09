using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AauVotingSystemP4
{
    /// <summary>
    /// This class provides all access to the database
    /// </summary>
    class DatabaseConnector
    {
        /// <summary>
        /// Returns a connection to run queries on based on the parameters.
        /// </summary>
        /// <param name="host">Ip of the host</param>
        /// <param name="user">User to login</param>
        /// <param name="pwd">Password</param>
        /// <param name="db">Database to connect too</param>
        /// <returns></returns>
        public static MySqlConnection GetConnection(string host, string user, string pwd, string db)
        {
            string conStr =
            String.Format("server={0};uid={1};pwd={2};database={3}",
            host, user, pwd, db);
            var con = new MySqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            return con;
        }
        /// <summary>
        /// Gets a functioning connecting with the default paramerters. 
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetDefaultConnection()
        {
            return GetConnection("62.107.80.31", "connect", "some_pass", "votingsystem");
        }

        //This function is only here to provide an example of how to run a query.
        private static void RunQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader[i]);
                Console.WriteLine();
            }
        }

        public void RegisterVote(string cpr, int electionId)
        {

        }

        /// <summary>
        /// Adds a citizen to the list
        /// </summary>
        /// <param name="citizenToAdd">The citizen to add</param>
        public void AddCitizen(Citizen citizenToAdd)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            string sqlString = String.Format("INSERT INTO citizen(CPR, ZipCode) VALUES('{0}', {1}); ", citizenToAdd.Cpr, citizenToAdd.Zipcode);

            cmd.CommandText = sqlString;
            cmd.ExecuteReader();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Gets all the citizens
        /// </summary>
        /// <returns>A list with all the citizens</returns>
        public List<Citizen> GetAllCitizens()
        {
            List<Citizen> citizens = new List<Citizen>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM citizen";

            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Citizen citizen = new Citizen((string)reader[1], int.Parse((string)reader[0]));
                citizens.Add(citizen);
            }

            cmd.Connection.Close();
            return citizens;
        }

        /// <summary>
        /// Get all zip codes for a specific nomination district
        /// </summary>
        /// <param name="nominationDistrictId">The nomination distric id</param>
        /// <param name="electionId">The election id</param>
        /// <returns>A list of zipcodes associated with </returns>
        public List<ZipCode> GetAllZipCodesForNominationDistrict(int nominationDistrictId, int electionId)
        {
            List<ZipCode> list = new List<ZipCode>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM zipcode WHERE Election_ID = " + electionId + " AND NominationDistrict_ID = " + nominationDistrictId + ";";

            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ZipCode zipCode = new ZipCode(int.Parse((string)reader[0]),(string)reader[1]);
                list.Add(zipCode);
            }

            cmd.Connection.Close();
            return list;

        }

        /// <summary>
        /// Adds a nomination district to the database
        /// </summary>
        /// <param name="nominationDitrict">The nomination district to add</param>
        /// <param name="electionId">Id of the election</param>
        public void AddNominationDistrictForElection(NominationDistrict nominationDitrict, int electionId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            string sqlString = String.Format("INSERT INTO nominationdistrict(Name, NumberOfMandates, Election_ID) VALUES('{0}', {1}, {2}); ", nominationDitrict.Name, nominationDitrict.NumberOfMandates,electionId);

            cmd.CommandText = sqlString;
            cmd.ExecuteReader();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Gets all the nomination district for a specific election 
        /// </summary>
        /// <param name="election">The associated election</param>
        /// <returns>A list of nomination districts</returns>
        public List<NominationDistrict> GetNominationDistrictsForElection(Election election)
        {
            List<NominationDistrict> nominationDistricts = new List<NominationDistrict>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM nominationdistrict WHERE Election_ID = " + election.Election_ID + ";";

            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                NominationDistrict district = new NominationDistrict(election, (string)reader[1], (int)reader[2], (int)reader[0]);
                nominationDistricts.Add(district);
            }

            cmd.Connection.Close();
            return nominationDistricts;
        }

        /// <summary>
        /// Adds a voting option for a specific election. The methods can add both parties and candidates
        /// </summary>
        /// <param name="option">Voting option to be added</param>
        /// <param name="electionId">The election to add it to</param>
        public void AddVotionOPtion(VotingOption option, int electionId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            if (option.IsNationalVotingOption)
            {
                string sqlString = String.Format("INSERT INTO party (Name, Election_ID)VALUES('{0}', '{1}');", option.FirstName, electionId);

                cmd.CommandText = sqlString;
            }
            else
            {
                string sqlString = String.Format("INSERT INTO candidates(FirstName, LastName, Party_ID, NominationDistrict_ID, Election_ID) VALUES('{0}', '{1}', {2}, {3}, {4});",
            option.FirstName, option.LastName, option.PartyId, option.NominationDistrictId, electionId);

                cmd.CommandText = sqlString;
            }

            cmd.ExecuteReader();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Gets the candidates for a specific nomination district NOT including the national options
        /// </summary>
        /// <param name="nominationDistrictId">Id of the nomination district</param>
        /// <param name="electionId">The election id</param>
        /// <returns>List of voting options</returns>
        public List<VotingOption> GetVotingOptionForNominationDistrict(int nominationDistrictId,int electionId)
        {
            List<VotingOption> options = new List<VotingOption>();

            //Gets candidates
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM candidates WHERE Election_ID = " + electionId + " AND NominationDistrict_ID="+nominationDistrictId+";";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                options.Add(new VotingOption((string)reader[1], (string)reader[2], (int)reader[3], (int)reader[4], (int)reader[0]));
            }
            
            cmd.Connection.Close();

            return options;
        }

        /// <summary>
        /// Returns all voting options for parties and all nomination districts in a specific election
        /// </summary>
        /// <param name="electionId">The election id</param>
        /// <returns>A list of voting options</returns>
        public List<VotingOption> GetAllVotingOptionsForElection(int electionId)
        {
            List<VotingOption> listOfOptions = new List<VotingOption>();

            //Gets candidates
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM candidates WHERE Election_ID = " + electionId + ";";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listOfOptions.Add(new VotingOption((string)reader[1], (string)reader[2], (int)reader[3], (int)reader[4], (int)reader[0]));
            }

            listOfOptions.AddRange(GetListOfNationalVotionOptions(electionId));

            cmd.Connection.Close();

            return listOfOptions;
        }

        /// <summary>
        /// Gets national voting options for a specific election
        /// </summary>
        /// <param name="electionId">The id of the election</param>
        /// <returns>List of national voting options</returns>
        public List<VotingOption> GetListOfNationalVotionOptions(int electionId)
        {
            List<VotingOption> listOfOptions = new List<VotingOption>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from party WHERE Election_ID = " + electionId + ";";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                VotingOption vo = new VotingOption((string)reader[1], "", -1, (int)reader[0]);
                vo.IsNationalVotingOption = true;
                listOfOptions.Add(vo);
            }

            cmd.Connection.Close();

            return listOfOptions;
        }

    }
}
