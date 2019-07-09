using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Candidates
{
    class HerbivoreCandidate : Candidate
    {
        public HerbivoreCandidate(string name) : base(name)
        {
            species = SpeciesEnum.Hippo;
            eaterType = EaterEnum.Herbivore;

            hatedSpecies.Add(SpeciesEnum.Lion);
            hatedEaters.Add(EaterEnum.Carnivore);

        }
    }
}
