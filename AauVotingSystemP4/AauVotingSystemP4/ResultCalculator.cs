using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AauVotingSystemP4
{
    class ResultCalculator
    {
        Dictionary<int, VotingOption> votingOptions = new Dictionary<int, VotingOption>();
        public int electionId;

        public ResultCalculator(int electionId)
        {
            this.electionId = electionId;
        }

        /// <summary>
        /// Calculates the result for parties, this includes the votes for a candidates who are members of that party
        /// </summary>
        /// <returns>A list of VoteResult</returns>
        public List<VoteResult> CalculateResultForParties()
        {
            var conector = new DatabaseConnector();
            List<VoteResult> resultsForAllDistricts = conector.GetVotesForParties(electionId);
            resultsForAllDistricts.Sort();
            return TablulateResultsForParties(resultsForAllDistricts);
        }

        /// <summary>
        /// Calculates the votes for candidates. All candidates are included.
        /// </summary>
        /// <returns>List of VoteResult</returns>
        public List<VoteResult> CalculateResultsForCandidates()
        {
            var cononector = new DatabaseConnector();
            List<VoteResult> candidateResults = cononector.GetVotesForCandidates(electionId);
            candidateResults.Sort();
            return candidateResults;
        }


        /// <summary>
        /// Calculates the result for the parties based on the input.
        /// </summary>
        /// <param name="resultsForAllDistricts"></param>
        /// <returns></returns>
        public List<VoteResult> TablulateResultsForParties(List<VoteResult> resultsForAllDistricts)
        {
            var conector = new DatabaseConnector();

            List<VotingOption> parties = conector.GetListOfNationalVotionOptions(electionId);
            Dictionary<VotingOption, int> votes = new Dictionary<VotingOption, int>();
            foreach (var party in parties)
            {
                foreach (var voteresult in resultsForAllDistricts)
                {
                    if (voteresult.PartyId == party.PartyId)
                    {
                        if (votes.ContainsKey(party))
                        {
                            votes[party] += voteresult.AmountOfVotes;
                        }
                        else
                        {
                            votes.Add(party, voteresult.AmountOfVotes);
                        }
                    }
                }
            }

            List<VoteResult> voteResults = new List<VoteResult>();
            foreach (var item in votes)
            {
                voteResults.Add(new VoteResult(item.Key.FirstName, item.Key.LastName, item.Key.PartyId, item.Value, item.Key.NominationDistrictId, item.Key.IsNationalVotingOption));
            }

            return voteResults;
        }
    }
}
