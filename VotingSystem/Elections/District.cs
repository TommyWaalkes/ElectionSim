using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VotingSystem.Candidates;

namespace VotingSystem.Elections
{
    class District
    {
        private List<Voter> voters = new List<Voter>();
        public List<Voter> Voters { get { return voters; } }

        public int Value { get { return value; } }
        private int value = 1;

        public District(List<Voter> voters)
        {
            this.voters = voters;
        }

        public District()
        {

        }

        public void AddVoter(Voter v)
        {
            voters.Add(v);
        }

        public Candidate GetWinner(List<Candidate> candidates)
        {
            List<Candidate> votes = new List<Candidate>();
            foreach(Voter v in voters)
            {
                Candidate c = v.CastVote(candidates);
                votes.Add(c);
            }

            foreach(Candidate can in candidates)
            {
                can.Votes = TallyVotes(can, votes);
            }
            int winningVotes = candidates.Max(x => x.Votes);
            List<Candidate> winners = candidates.Where(x => x.Votes == winningVotes).ToList();

            if(winners.Count > 1)
            {
                return new DrawCandidate("Tie");
            }
            else if(winners.Count == 1)
            {
                return winners[0];
            }
            else
            {
                return new DrawCandidate("Draw");
            }

        }

        public int TallyVotes(Candidate c, List<Candidate> votes)
        {
            int total = 0;
            foreach (Candidate v in votes)
            {
                if (v.Name == c.Name)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
