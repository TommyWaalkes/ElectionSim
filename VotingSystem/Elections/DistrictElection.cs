using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Candidates;

namespace VotingSystem.Elections
{
    class DistrictElection : Election
    {
        private List<District> districts = new List<District>();
        public List<District> Districts { get { return districts; } }

        private int districtSize = 10;
        private int districtNumber;
        public DistrictElection(int herbivorePop, int omnivorePop, int carnivorePop, Random r, string distributtionMethod, params Candidate[] cs) 
            : base(herbivorePop, omnivorePop, carnivorePop, r, cs)
        {
            districtNumber = Voters.Count / districtSize;
            switch (distributtionMethod)
            {
                case "random":
                MakeRandomDistricts();
                break;

                case "even":

                    break;
            }
           
        }

        public void MakeRandomDistricts()
        {
            for(int i = 0; i < districtNumber; i++)
            {
                Districts.Add(new District());
            }
            for(int i = 0; i< Voters.Count; i++)
            {
                int disIndex = r.Next(0,Districts.Count);
                Districts[disIndex].AddVoter(Voters[i]);
            }
        }

        public void MakeEvenDistricts()
        {

        }

        public override Candidate DetermineWinner()
        {
           List<Candidate> winners = new List<Candidate>();
           foreach(District d in districts)
            {
                Candidate c = d.GetWinner(Candidates);
                winners.Add(c);
            }

            return winners[0];
        }





    }
}
