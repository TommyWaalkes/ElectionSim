using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Candidates
{
    class OmnivoreCandidate : Candidate
    {
        public OmnivoreCandidate(string name): base(name)
        {
            species = SpeciesEnum.Hyena;
            eaterType = EaterEnum.Omnivore;
        }
    }
}
