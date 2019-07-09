using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem
{
    public abstract class Animal
    {
        public SpeciesEnum Species
        {
            get
            {
                return species;
            }
        }
        protected SpeciesEnum species;
        public EaterEnum EaterType
        {
            get
            {
                return eaterType;
            }
        }

        protected EaterEnum eaterType;

        protected double food = 10;

        public double Food { get { return food; } set { food = value; } }

        public List<SpeciesEnum> HatedSpecies
        {
            get
            {
                return hatedSpecies;
            }
                
        }

        protected List<SpeciesEnum> hatedSpecies = new List<SpeciesEnum>();

        public List<EaterEnum> HatedEaters
        {
            get
            {
                return hatedEaters;
            }

        }
        protected List<EaterEnum> hatedEaters = new List<EaterEnum>();
    }
}
