using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class User
    {
        public string Name { get; set; }
        public List<Card> deck = new List<Card>();
        public int Points { get; set; }
        Random rand = new Random();

        public User(string name)
        {
            Name = name;
            Points = 0;
        }

        public void SubmitPair()
        {
            List<PlayingCard> cardsToRemove = new List<PlayingCard>();
            foreach (PlayingCard card in deck)
            {
                foreach (PlayingCard c in deck)
                {
                    if (card == c)
                    {
                        // Do nothing
                    }
                    else if (card.Color == c.Color && card.Value == c.Value && !cardsToRemove.Contains(card) && !cardsToRemove.Contains(c))
                    {
                        cardsToRemove.Add(card);
                        cardsToRemove.Add(c);
                        Points++;
                    }
                }
            }

            foreach (PlayingCard p in cardsToRemove)
            {
                deck.Remove(p);
            }
        }

        public void GiveCard(Card card)
        {
            deck.Add(card);
        }

        public Card TakeCard()
        {
            if (deck.Count > 0)
            {
                Card c = deck[rand.Next(0, deck.Count)];
                deck.Remove(c);
                return c;
            }
            return null;
        }
    }
}
