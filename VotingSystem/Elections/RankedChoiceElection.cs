using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VotingSystem.Candidates;

namespace VotingSystem
{
    class RankedChoiceElection : Election
    {

        public RankedChoiceElection(int herbivorePop, int omnivorePop, int carnivorePop, Random r, params Candidate[] cs) 
            : base(herbivorePop, omnivorePop, carnivorePop, r, cs)
        {

        }

        public override Candidate DetermineWinner()
        {
            List<List<Candidate>> rankedVotes = new List<List<Candidate>>();

            foreach (Voter v in Voters)
            {
                List<Candidate> copy = new List<Candidate>();
                copy = Candidates.GetRange(0, Candidates.Count);
                List<Candidate> votes = RankedVote(v, copy, new List<Candidate>());
                // Console.WriteLine($"Vote for {c.Name}");
                rankedVotes.Add(votes);
            }

            List<Candidate> copyWin = new List<Candidate>();
            copyWin = Candidates.GetRange(0, Candidates.Count);
            Candidate winner = EliminateWorst(rankedVotes, copyWin);

            return winner;


        }

        public Candidate EliminateWorst(List<List<Candidate>> rankedVotes, List<Candidate> candidatePool)
        {
            if (candidatePool.Count > 1)
            {
                List<int> totalVotes = new List<int>();
                foreach (Candidate c in candidatePool)
                {
                    int total = TallyRankedVotes(c, rankedVotes);
                    c.Votes = total;
                    totalVotes.Add(total);
                }

                int leastVotes = totalVotes.Min();
                Candidate weakest = candidatePool.Where(x => x.Votes == leastVotes).First();

                candidatePool.Remove(weakest);

                return EliminateWorst(rankedVotes, candidatePool);
            }
            else
            {
                return candidatePool[0];
            }
        }

        public List<Candidate> RankedVote(Voter v, List<Candidate> CandidatePool, List<Candidate> Ranking)
        {
            if (CandidatePool.Count > 0)
            {
                Candidate c = v.CastVote(CandidatePool);
                Ranking.Add(c);
                CandidatePool.RemoveAll(x => x.Name == c.Name);

                return RankedVote(v, CandidatePool, Ranking);
            }
            else
            {
                return Ranking;
            }
        }

        public int TallyRankedVotes(Candidate c, List<List<Candidate>> rankedVotes)
        {
            int total = 0;
            foreach (List<Candidate> v in rankedVotes)
            {
                if (v[0].Name == c.Name)
                {
                    total++;
                }
            }

            return total;
        }
    }
}
