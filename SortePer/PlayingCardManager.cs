using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class PlayingCardManager : ICardManager
    {
        Random rand = new Random();
        public List<Card> deck = new List<Card>();

        public void CreateDeck()
        {
            Array types = Enum.GetValues(typeof(PlayingCardTypes));
            Array values = Enum.GetValues(typeof(PlayingCardValues));
            foreach (PlayingCardTypes type in types)
            {
                foreach (PlayingCardValues value in values)
                {
                    //Remove jack of spades from the deck.
                    if (type != PlayingCardTypes.Spades || value != PlayingCardValues.Jack)
                    {
                        if (type == PlayingCardTypes.Diamonds || type == PlayingCardTypes.Hearts)
                        {
                            deck.Add(new PlayingCard(type, value, "Red")); 
                        } else
                        {
                            deck.Add(new PlayingCard(type, value, "Black"));
                        }
                    }
                }
            }
        }

        public Card GiveCard()
        {
            Card card = deck[rand.Next(0, deck.Count)];
            deck.Remove(card);
            return card;
        }

        public int CardsInDeck()
        {
            return deck.Count;
        }
    }
}
