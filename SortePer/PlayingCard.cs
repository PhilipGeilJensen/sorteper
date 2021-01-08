using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class PlayingCard : Card
    {
        public PlayingCardTypes Type { get; set; }
        public PlayingCardValues Value { get; set; }
        public string Color { get; set; }

        public PlayingCard(PlayingCardTypes type, PlayingCardValues value, string color)
        {
            Type = type;
            Value = value;
            Color = color;
        }

        public override string ToString()
        {
            return Value + " of " + Type;
        }
    }
}
