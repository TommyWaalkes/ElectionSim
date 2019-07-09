using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Candidates
{
    class RandomCandidate : Candidate
    {
        private Random r;
        public RandomCandidate(string name, Random r) : base(name)
        {
            this.r = r;
            int countSpec = Enum.GetValues(typeof(SpeciesEnum)).Length;
            this.species = (SpeciesEnum) r.Next(countSpec);

            int countEater = Enum.GetValues(typeof(EaterEnum)).Length;
            eaterType = (EaterEnum) r.Next(countEater);
        }
    }
}
