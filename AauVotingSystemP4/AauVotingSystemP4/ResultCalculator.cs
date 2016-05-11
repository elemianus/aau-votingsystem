﻿using System;
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

        public void CalculateResult()
        {
            var conector = new DatabaseConnector();
            
            
            
            List<VoteResult> voteResult = conector.GetAllVotes(electionId);
            string derp ="";

            TablulateResultsForParties(voteResult);
        }

        private void SetUpCandidates()
        {
            List<VotingOption> options = new List<VotingOption>();
            foreach (var item in options)
            {
                votingOptions.Add(item.NominationDistrictId, item);
            }
        }

        public Dictionary<VotingOption, int> TablulateResultsForParties(List<VoteResult> resultsForAllDistricts)
        {
            var conector = new DatabaseConnector();
            List<VotingOption> parties = conector.GetListOfNationalVotionOptions(electionId);
            Dictionary<VotingOption, int> votes = new Dictionary<VotingOption, int>();
            foreach (var party in parties)
            {
                foreach (var voteresult in resultsForAllDistricts)
                {
                    if (voteresult.partyId == party.PartyId)
                    {
                        if (votes.ContainsKey(party))
                        {
                            votes[party] += voteresult.amountOfVotes;
                        }
                        else
                        {
                            votes.Add(party, voteresult.amountOfVotes);
                        }
                    }
                }
            }

            return votes;
        }
    }
}
