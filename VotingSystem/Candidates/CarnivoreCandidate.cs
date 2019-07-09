using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Candidates
{
    class CarnivoreCandidate : Candidate
    {
        public CarnivoreCandidate(string name) : base(name)
        {
            species = SpeciesEnum.Lion;
            eaterType = EaterEnum.Carnivore;

            hatedSpecies.Add(SpeciesEnum.Hippo);
            hatedEaters.Add(EaterEnum.Herbivore);
        }
    }
}
