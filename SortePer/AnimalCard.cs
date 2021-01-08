using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class AnimalCard : Card
    {
        private AnimalTypes type;

        public AnimalTypes Type
        {
            get { return type; }
            private set { type = value; }
        }


        public AnimalCard(AnimalTypes type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
