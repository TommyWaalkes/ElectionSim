using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Candidates
{
    class DrawCandidate : Candidate
    {
        public DrawCandidate(string name) : base(name)
        {
            name = "draw";
           

        }
    }
}
