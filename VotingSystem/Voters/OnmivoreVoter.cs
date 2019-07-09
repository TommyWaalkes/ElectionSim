using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Candidates;

namespace VotingSystem
{
    class OmnivoreVoter : Voter
    {
      
        public OmnivoreVoter(Random r):base(r)
        {
            species = SpeciesEnum.Hyena;
            eaterType = EaterEnum.Omnivore;
        }
        //public override CandidateAbstract CastVote(List<CandidateAbstract> candidates)
        //{
        //    int pick = r.Next(candidates.Count);
        //    return candidates[pick];
        //}
    }
}
