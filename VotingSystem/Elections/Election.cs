using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Candidates;

namespace VotingSystem
{
    class Election
    {
        public List<Candidate> Candidates = new List<Candidate>();
        public List<Voter> Voters = new List<Voter>();
        public Random r;
        public Election(int herbivorePop, int omnivorePop, int carnivorePop, Random r, params Candidate[] cs)
        {
            this.r = r;
            Candidates = cs.ToList();
            for (int i = 0; i < herbivorePop; i++)
            {
                Voters.Add(new HerbivoreVoter(r));
            }
            for (int i = 0; i < omnivorePop; i++)
            {
                Voters.Add(new OmnivoreVoter(r));
            }

            for (int i = 0; i < carnivorePop; i++)
            {
                Voters.Add(new CarnivoreVoter(r));
            }

            Campaigin(Voters);

            // Candidates.Add(new HerbivoreCandidate("Herb"));

            //Candidates.Add(new CarnivoreCandidate("Carnie"));
            //Candidates.Add(new CarnivoreCandidate("CCC"));
            //Candidates.Add(new CarnivoreCandidate("Cecil"));

            //Candidates.Add(new RandomCandidate("Randal",r));
            //Candidates.Add(new RandomCandidate("Randa", r));
            //Candidates.Add(new RandomCandidate("Renee", r));
            //Candidates.Add(new RandomCandidate("Roger", r));
            //Candidates.Add(new RandomCandidate("Reginald", r));


        }

        public void PrintStats()
        {
            foreach (Candidate c in Candidates)
            {
                List<double> ratings = Poll(c);

                Console.WriteLine("Candidate Approval Rating");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Species: {c.Species}");
                Console.WriteLine($"Species: {c.EaterType}");
                Console.WriteLine($"Average Rating: {ratings.Average()}");
                Console.WriteLine($"High Rating: {ratings.Max()}");
                Console.WriteLine($"Low Rating: {ratings.Min()}");
                Console.WriteLine($"Food: {c.Food}");
                Console.WriteLine($"PR Rating: {c.PrRating}");
                Console.WriteLine();
                Console.ReadLine();

            }
        }

        public List<double> Poll(Candidate c)
        {
            List<double> ratings = new List<double>();
            foreach (Voter v in Voters)
            {
                double approval = v.GetApproval(c);
                ratings.Add(approval);
            }

            return ratings;
        }

        public void Campaigin(List<Voter> donors)
        {
            foreach(Candidate c in Candidates)
            {
                c.BegForDonations(donors);
            }
        }
        

        public int TallyVotes(Candidate c, List<Candidate> votes)
        {
            int total = 0;
            foreach(Candidate v in votes)
            {
                if(v.Name == c.Name)
                {
                    total++;
                }
            }

            return total;
        }
      

        public virtual Candidate DetermineWinner()
        {
            List<Candidate> votes = new List<Candidate>();

            foreach(Voter v in Voters)
            {
                Candidate c = v.CastVote(Candidates);
               // Console.WriteLine($"Vote for {c.Name}");
                votes.Add(c);
            }

            List<int> totalVotes = new List<int>();
            foreach(Candidate c in Candidates)
            {
                int total = TallyVotes(c, votes);
                totalVotes.Add(total);
            }
            int mostVotes = totalVotes.Max();
            //Console.WriteLine("Most votes: "+mostVotes);
            int index = -1;
            for(int i = 0; i < totalVotes.Count; i++)
            {
                //Console.WriteLine($"Total Votes: {totalVotes[i]}");
                if(mostVotes == totalVotes[i])
                {
                    if (index == -1)
                    {
                        index = i;
                    }
                    else
                    {
                        return new DrawCandidate("Draw");
                    }
                }
                 
            }

            return Candidates[index];
            
        }
    }
}
