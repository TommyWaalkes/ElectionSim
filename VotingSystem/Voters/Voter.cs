using System;
using System.Collections.Generic;
using VotingSystem;
using VotingSystem.Candidates;

public abstract class Voter : Animal
{
    protected double VoteValue { get; set; }
    protected List<double> VoteChances { get; set; }

    protected Random r;

    public Voter(Random r)
    {
        this.r = r;
    }

    public void ShuffleMe<T>(IList<T> list, Random random)
    {
        int n = list.Count;

        for (int i = list.Count - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);

            T value = list[rnd];
            list[rnd] = list[i];
            list[i] = value;
        }
    }

    public virtual Candidate CastVote(List<Candidate> candidates)
    {
        ShuffleMe(candidates, r);

        List<double> chances = new List<double>();
        foreach (Candidate c in candidates)
        {
            double chance = GetVoteChance(c);
            chances.Add(chance);
            //Console.WriteLine(chance);
        }

        List<double> percents = PercentageCalculator.NormalizePercentages(chances.ToArray());

        //Console.WriteLine($"Candidates {candidates.Count}");
        //Console.WriteLine($"Chances {chances.Count}");
        //Console.WriteLine($"Total {total}");

        int pick = r.Next(0, 101);
        int index = -1;
        double minval = 0;
        for (int i = 0; i < percents.Count; i++)
        {
            double d = percents[i];
            if(i > 0)
            {
                minval += percents[i - 1];
            }

            if (pick >= minval && pick< minval + d)
            {
                index = i;
            }
        //Console.WriteLine();
        }
        if(index == -1)
        {
            int p = r.Next(candidates.Count);
            return candidates[p];
        }
        return candidates[index];
    }

    public double GetVoteChance(Candidate c)
    {
        double chance = 50 * c.PrRating;

        
        if (c.Species == this.Species)
        {
            chance *= r.NextDouble() +1;
        }
        else if(hatedSpecies.Contains(c.Species))
        {
            chance *= r.NextDouble() *.5;
        }

        if (c.EaterType == this.EaterType && c.EaterType != EaterEnum.Omnivore)
        {
            chance *= 1.2;
        }
        else if (hatedEaters.Contains(c.EaterType))
        {
            chance *= .5;
        }

        return chance;
    }

    public double GetApproval(Candidate c)
    {
        double voteChance = GetVoteChance(c);
        voteChance *= c.PrRating;
        voteChance *= r.NextDouble();

        return voteChance;
    }

    public double GetDonateChance(Candidate c)
    {
        double chance = 10;
        if (c.HatedSpecies.Contains(Species))
        {
            chance *= .5;
        }
        if (c.Species == this.Species)
        {
            chance *= 1.1;
        }
        else if (hatedSpecies.Contains(c.Species))
        {
            chance *= .5;
        }

    

        if (c.EaterType == this.EaterType && c.EaterType != EaterEnum.Omnivore)
        {
            chance *= 1.1;
        }
        else if (hatedEaters.Contains(c.EaterType)|| c.HatedEaters.Contains(EaterType))
        {
            chance *= .5;
        }

        return chance;
    }

    public double Donate(Candidate c)
    {
        int donateRoll = r.Next(101);
        double donateChance = GetDonateChance(c);

        if (donateRoll <= donateChance)
        {
            return r.Next(0, int.Parse(food.ToString()));
        }
        else
        {
            return 0;
        }
    }

}
