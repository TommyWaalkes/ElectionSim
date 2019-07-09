using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Candidates;

namespace VotingSystem
{
    class HerbivoreVoter : Voter
    {
        
        public HerbivoreVoter(Random r) :base(r)
        {
            species = SpeciesEnum.Hippo;
            eaterType = EaterEnum.Herbivore;

            hatedSpecies.Add(SpeciesEnum.Lion);
            hatedEaters.Add(EaterEnum.Carnivore);
        }
    }
}
