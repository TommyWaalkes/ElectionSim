using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Candidates;

namespace VotingSystem
{
    class CarnivoreVoter : Voter
    {
        
        public CarnivoreVoter(Random r) :base(r)
        {
            species = SpeciesEnum.Lion;
            eaterType = EaterEnum.Carnivore;

            hatedSpecies.Add(SpeciesEnum.Hippo);
            hatedEaters.Add(EaterEnum.Herbivore);
        }
    }
}
