using System;
using System.Collections.Generic;
using System.Linq;
using VotingSystem.Candidates;
using VotingSystem.Elections;

namespace VotingSystem
{
    class Program
    {
        public static void RunRankedChoice(int electionsToRun, List<Candidate> Candidates, Random r)
        {
            List<Candidate> winners = new List<Candidate>();
            for (int i = 0; i < electionsToRun; i++)
            {
                RankedChoiceElection e = new RankedChoiceElection(300, 300, 300, r, Candidates.ToArray());
                Candidate winner = e.DetermineWinner();
                winners.Add(winner);
            }
            var carniWins = winners.Count(x => x.EaterType == EaterEnum.Carnivore);
            var herbWins = winners.Count(x => x.EaterType == EaterEnum.Herbivore);
            var omniWins = winners.Count(x => x.EaterType == EaterEnum.Omnivore);
            Console.WriteLine();
            Console.WriteLine("Ranked Choice Elections");
            Console.WriteLine($"Carnivore wins: {carniWins}");
            Console.WriteLine($"Omnivore wins: {omniWins}");
            Console.WriteLine($"Herbivore wins: {herbWins}");
            List<string> names = winners.Select(x => x.Name).Distinct().ToList();
            foreach (string s in names)
            {
                var wins = winners.Count(x => x.Name == s);
                Console.WriteLine($"{s}: {wins} wins");
            }
        }


        public static void RunWinnerTakesAllElection(int electionsToRun, List<Candidate> Candidates, Random r)
        {
            List<Candidate> winners = new List<Candidate>();
            for (int i = 0; i < electionsToRun; i++)
            {
                Election e = new Election(300, 300, 300, r, Candidates.ToArray());
                Candidate winner = e.DetermineWinner();
                winners.Add(winner);
            }
            Console.WriteLine();
            Console.WriteLine("Winner Take all elections");
            var carniWins = winners.Count(x => x.EaterType == EaterEnum.Carnivore);
            var herbWins = winners.Count(x => x.EaterType == EaterEnum.Herbivore);
            var omniWins = winners.Count(x => x.EaterType == EaterEnum.Omnivore);

            Console.WriteLine($"Carnivore wins: {carniWins}");
            Console.WriteLine($"Omnivore wins: {omniWins}");
            Console.WriteLine($"Herbivore wins: {herbWins}");
            List<string> names = winners.Select(x => x.Name).Distinct().ToList();
            foreach (string s in names)
            {
                var wins = winners.Count(x => x.Name == s);
                Console.WriteLine($"{s}: {wins} wins");
            }
        }

        public static void RunDistrictElection(int electionsToRun, List<Candidate> Candidates, Random r)
        {
            List<Candidate> winners = new List<Candidate>();
            for (int i = 0; i < electionsToRun; i++)
            {
                DistrictElection e = new DistrictElection(300, 300, 300, r, "random", Candidates.ToArray());
                Candidate winner = e.DetermineWinner();
                winners.Add(winner);
            }
            var carniWins = winners.Count(x => x.EaterType == EaterEnum.Carnivore);
            var herbWins = winners.Count(x => x.EaterType == EaterEnum.Herbivore);
            var omniWins = winners.Count(x => x.EaterType == EaterEnum.Omnivore);
            Console.WriteLine();
            Console.WriteLine("District based Elections");
            Console.WriteLine($"Carnivore wins: {carniWins}");
            Console.WriteLine($"Omnivore wins: {omniWins}");
            Console.WriteLine($"Herbivore wins: {herbWins}");
            List<string> names = winners.Select(x => x.Name).Distinct().ToList();
            foreach (string s in names)
            {
                var wins = winners.Count(x => x.Name == s);
                Console.WriteLine($"{s}: {wins} wins");
            }
        }

        static void Main(string[] args)
        {
            int electionsToRun = 5000;
            Random r = new Random();
            List<Candidate> Candidates = new List<Candidate>();
            Candidates.Add(new CarnivoreCandidate("Connie"));
            Candidates.Add(new OmnivoreCandidate("Ollie"));
            Candidates.Add(new HerbivoreCandidate("Herb"));
            Candidates.Add(new RandomCandidate("Randy", r));
            Candidates.Add(new RandomCandidate("Ronda", r));
            Candidates.Add(new RandomCandidate("Ralph", r));

            Election e = new Election(300, 300, 300, r, Candidates.ToArray());
            e.PrintStats();

            RunWinnerTakesAllElection(electionsToRun, Candidates, r);
            RunRankedChoice(electionsToRun, Candidates, r);
            RunDistrictElection(electionsToRun, Candidates, r);


        }
    }
}
