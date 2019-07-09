using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Candidates
{
    public abstract class Candidate : Animal
    {
       public string Name {
            get
            {
                return name;
            }
        }
        protected string name;

        public int Votes { get; set; }

        protected double prRating = 1;
        public double PrRating { get { return prRating; } }
        public Candidate(string name)
        {
            Food = 0;
            this.name = name;
            species = SpeciesEnum.Lion;
        }

        public void BegForDonations(List<Voter> donors)
        {
            food = 0;
            foreach(Voter donor in donors)
            {
                food += donor.Donate(this);
            }

            prRating = (food/100);
        }
    }
}
