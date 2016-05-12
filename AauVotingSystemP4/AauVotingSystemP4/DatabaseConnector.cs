using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AauVotingSystemP4
{
    /*
        Create result table from voting options
        Remove voting option
        */

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

        /// <summary>
        /// Register a vote for a citizen, can be both a national voting option or a candidate. Then it registers that the user has voted.
        /// </summary>
        /// <param name="citizen">The citizen that is voting</param>
        /// <param name="voteOption">The voteoption selected</param>
        /// <param name="electionId">Id of the election</param>
        /// <param name="nominationDistrictId">Id of the nominatin district</param>
        /// <returns>False if the user allready has voted, true otherwise.</returns>
        public bool RegisterVote(Citizen citizen, VotingOption voteOption, int electionId, int nominationDistrictId)
        {
            if (HasCitizenVotedForElection(citizen, electionId))
            {
                citizen.SetCitizenHasVoted();
            }
            if (citizen.Voteconducted)
            {//Citizen has allready voted
                return false;
            }
            string sqlString = "";

            if (voteOption.IsNationalVotingOption) //Parti
            {
                sqlString = String.Format("UPDATE result SET amount = amount + 1 WHERE Election_ID = {0} AND NominationDistrict_ID = {1} AND Party_ID = {2}", electionId, nominationDistrictId, voteOption.PartyId);
            }
            else
            {
                sqlString = String.Format("UPDATE result SET amount = amount + 1 WHERE Election_ID = {0} AND NominationDistrict_ID = {1} AND Candidate_ID = {2}", electionId, nominationDistrictId, voteOption.VotingOptionId);
            }

            Console.WriteLine(sqlString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            RegisterThatCitizenHasVoted(citizen, electionId);

            cmd.CommandText = sqlString;
            cmd.ExecuteReader();
            cmd.Connection.Close();

            return true;
        }

        /// <summary>
        /// Checks if the citizen allready has voted in an election
        /// </summary>
        /// <param name="citizen">Citizen to check</param>
        /// <param name="electionId">Election</param>
        /// <returns>True if allready has voted, otherwise false</returns>
        public bool HasCitizenVotedForElection(Citizen citizen, int electionId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM voteconducted WHERE Election_ID = " + electionId + " AND CPR = " + citizen.Cpr + ";";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            Int64 amountOfVotesForElection = 0;
            while (reader.Read())
            {
                amountOfVotesForElection = (Int64)reader[0];
            }

            cmd.Connection.Close();
            if (amountOfVotesForElection > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Register that the citizen has voted in an election
        /// </summary>
        /// <param name="citizen">Citizen that has voted</param>
        /// <param name="electionId">id of the election</param>
        public void RegisterThatCitizenHasVoted(Citizen citizen, int electionId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            string sqlString = String.Format("INSERT INTO voteconducted(CPR, Election_ID) VALUES('{0}', {1}); ", citizen.Cpr, electionId);

            cmd.CommandText = sqlString;
            cmd.ExecuteReader();
            cmd.Connection.Close();
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
                ZipCode zipCode = new ZipCode(int.Parse((string)reader[0]), (string)reader[1]);
                list.Add(zipCode);
            }

            cmd.Connection.Close();
            return list;

        }


        /// <summary>
        /// Returns all zip codes registerd for one election 
        /// </summary>
        /// <param name="electionId">The election in question</param>
        /// <returns>A list of ZipCodes</returns>
        public List<ZipCode> GetAllZipCodesInElection(int electionId)
        {
            List<ZipCode> list = new List<ZipCode>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM zipcode WHERE Election_ID = " + electionId + ";";

            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ZipCode zipCode = new ZipCode(int.Parse((string)reader[0]), (string)reader[1]);
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

            string sqlString = String.Format("INSERT INTO nominationdistrict(Name, NumberOfMandates, Election_ID) VALUES('{0}', {1}, {2}); ", nominationDitrict.Name, nominationDitrict.NumberOfMandates, electionId);

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
        public List<VotingOption> GetVotingOptionForNominationDistrict(int nominationDistrictId, int electionId)
        {
            List<VotingOption> options = new List<VotingOption>();

            //Gets candidates
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM candidates WHERE Election_ID = " + electionId + " AND NominationDistrict_ID=" + nominationDistrictId + ";";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                options.Add(VotingOptionFromReader(reader));
            }

            cmd.Connection.Close();

            return options;
        }

        private VotingOption VotingOptionFromReader(MySqlDataReader reader)
        {
            int partyId = -1;
            if (!reader.IsDBNull(4))
                partyId = (int)reader[4];
            return new VotingOption((string)reader[1], (string)reader[2], (int)reader[3], partyId, (int)reader[0]);
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
                listOfOptions.Add(VotingOptionFromReader(reader));
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

        /// <summary>
        /// Checkes if a citizens exists
        /// </summary>
        /// <param name="cpr">CPR to check for</param>
        /// <returns>True if found, otherwise false</returns>
        public bool DoesCitizenExist(string cpr)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM citizen WHERE CPR = '{0}';", cpr);
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            Int64 amountOfVotesForElection = 0;
            while (reader.Read())
            {
                amountOfVotesForElection = (Int64)reader[0];
            }

            cmd.Connection.Close();
            if (amountOfVotesForElection > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Here we check if the ballot is finalized
        /// </summary>
        /// <param name="ballotfinalized"></param>
        /// <returns>True if the votingballot is finalized and if it is not it returns false</returns>
        public bool IsBallotFinalized(string ballotfinalized)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Format("SELECT COUNT (*) FROM election WHERE Ballotfinalized = '{0}';", ballotfinalized);
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            Int64 numberofFinalizedballots = 0;
            while (reader.Read())
            {
                numberofFinalizedballots = (Int64)reader[0];
            }

            cmd.Connection.Close();
            if (numberofFinalizedballots > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Checks if electionboard exists.
        /// </summary>
        /// <param name="nominationD"></param>
        /// <returns>True if it founds the nominations destrict, otherwise it returns false</returns>
        public bool DoesElectionboardExist(string nominationD)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM nominationdistrict WHERE Name = '{0}';", nominationD);
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            Int64 amountOfVotesForElection = 0;
            while (reader.Read())
            {
                amountOfVotesForElection = (Int64)reader[0];
            }

            cmd.Connection.Close();
            if (amountOfVotesForElection > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Removes the specified option from the database. It can be both a party and a candidate.
        /// </summary>
        /// <param name="option">Th option to delete</param>
        public void DeleteVotionOption(VotingOption option)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();


            if (option.IsNationalVotingOption)
            {
                cmd.CommandText = String.Format("DELETE FROM party WHERE Party_ID = {0} ;", option.PartyId);
            }
            else
            {
                cmd.CommandText = String.Format("DELETE FROM candidates WHERE Candidate_id = {0} ;", option.VotingOptionId);
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader);
            }

            cmd.Connection.Close();

        }

        /// <summary>
        /// Removes a specific nomination district from the database.
        /// </summary>
        /// <param name="district">The district to remove</param>
        public void DeleteNominationDistrict(NominationDistrict district)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();
            cmd.CommandText = String.Format("DELETE FROM nominationdistrict WHERE NominationDistrict_ID = {0} ;", district.NominationDistrictId);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader);
            }

            cmd.Connection.Close();

        }

        /// <summary>
        /// Returns a list of all elections
        /// </summary>
        /// <returns>A list of elections</returns>
        public List<Election> GetAllElections()
        {
            List<Election> listOfElection = new List<Election>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from election;";
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int electionId = (int)reader[0];
                DateTime startDate = (DateTime)reader[1];
                DateTime endDate = (DateTime)reader[2];
                string typeOfElection = (string)reader[3];
                bool isBallotFinalized = false;
                if (!reader.IsDBNull(4))
                    isBallotFinalized = (bool)reader[4];

                Election election = new Election(electionId, startDate, endDate, typeOfElection);
                listOfElection.Add(election);
            }

            cmd.Connection.Close();

            return listOfElection;
        }

        /// <summary>
        /// Populates the result table with all candidates and national voting options. A result entry is created for every voting option in every nomination district. 
        /// This command takes a long time to run!
        /// </summary>
        /// <param name="election">The election to generate result table</param>
        public void GenerateResultTable(Election election)
        {
            List<NominationDistrict> nominationDistrictsForElection = GetNominationDistrictsForElection(election);
            List<VotingOption> nationalVotingOptions = GetListOfNationalVotionOptions(election.Election_ID);

            string sqlString = "";
            foreach (var item in nominationDistrictsForElection)
            {
                var listOfVotingOptions = GetVotingOptionForNominationDistrict(item.NominationDistrictId, election.Election_ID);
                foreach (var votingOption in listOfVotingOptions)
                {
                    sqlString += String.Format("INSERT INTO result VALUES({0},{1},{3},{2},0);", election.Election_ID, item.NominationDistrictId, votingOption.VotingOptionId, votingOption.PartyId);
                }
                foreach (var nationalVotingOption in nationalVotingOptions)
                {
                    sqlString += String.Format("INSERT INTO result VALUES({0},{1},{2},NULL,0);", election.Election_ID, item.NominationDistrictId, nationalVotingOption.PartyId);
                }
                int count = sqlString.Split(';').Length;
                sqlString = sqlString.Replace("-1", "NULL");
                Console.WriteLine(count);
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();
            cmd.CommandText = sqlString;

            cmd.ExecuteReader();
            cmd.Connection.Close();

        }

        public void AddElection(Election election)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetDefaultConnection();

            string sqlString = String.Format("INSERT INTO election(Startdate, Enddate, Type_Of_Election) VALUES('{0}', '{1}', '{2}'); ", election.StartDate.ToString("yyyy-MM-dd hh:mm:ss"), election.EndDate.ToString("yyyy-MM-dd hh:mm:ss"), election.ElectionType); 

            cmd.CommandText = sqlString;
            cmd.ExecuteReader();
            cmd.Connection.Close();
        }

        public List<VoteResult> GetAllVotes(int electionId)
        {
            List<VoteResult> votes = new List<VoteResult>();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT Name,NominationDistrict_ID,result.Party_ID,Candidate_ID,Amount,Name  FROM result join party ON result.Party_ID = party.Party_ID WHERE result.Election_ID =" + electionId + " ORDER BY amount desc; ";
            Console.WriteLine(cmd.CommandText);
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int partyId = (int)reader[2];
                int amount = (int)reader[4];
                int nominationDistrictId = (int)reader[1];
                var voteResult = new VoteResult(partyId, amount, nominationDistrictId);
                votes.Add(voteResult);
            }

            cmd.Connection.Close();

            return votes;
        }


        public Election GetElection(int election_Id)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Format("SELECT * FROM election WHERE Election_ID = {0} ;", election_Id);
            
            cmd.Connection = GetDefaultConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int electionId = (int)reader[0];
                DateTime startDate = (DateTime)reader[1];
                DateTime endDate = (DateTime)reader[2];
                string typeOfElection = (string)reader[3];
                bool isBallotFinalized = (bool)reader[4];


                Election election = new Election(electionId, startDate, endDate, typeOfElection);
                return election;
            }
            cmd.Connection.Close();
            return null;
        }



    }
}
