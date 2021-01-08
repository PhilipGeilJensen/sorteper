using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class PlayingCardValidator : IValidate
    {
        public bool CheckPair(List<Card> deck, Card card)
        {
            PlayingCard pc = (PlayingCard)card;
            bool temp = false;
            switch (pc.Type)
            {
                case PlayingCardTypes.Hearts:
                case PlayingCardTypes.Diamonds:
                    foreach (PlayingCard plc in deck)
                    {
                        if ((plc.Type == PlayingCardTypes.Hearts || plc.Type == PlayingCardTypes.Diamonds) && plc.Value == pc.Value)
                        {
                            temp = true;
                        }
                    }
                    break;
                case PlayingCardTypes.Clubs:
                case PlayingCardTypes.Spades:
                    foreach (PlayingCard plc in deck)
                    {
                        if ((plc.Type == PlayingCardTypes.Spades || plc.Type == PlayingCardTypes.Clubs) && plc.Value == pc.Value)
                        {
                            temp = true;
                        }
                    }
                    break;
                default:
                    break;
            }

            return temp;
        }
    }
}
