using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class PlayingCardValidator : IValidate
    {
        public Card CheckPair(List<Card> deck, Card card)
        {
            PlayingCard pc = (PlayingCard)card;
            foreach (PlayingCard plc in deck)
            {
                if (plc.Value == pc.Value && plc.Color == pc.Color)
                {
                    return plc;
                }
            }

            return null;
        }
    }
}
