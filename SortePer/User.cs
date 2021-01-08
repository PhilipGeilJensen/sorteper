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
        public bool Player { get; set; }
        Random rand = new Random();

        public User(string name)
        {
            Name = name;
            Points = 0;
        }

        public User(string name, bool player) 
        {
            Name = name;
            Points = 0;
            Player = player;
        }

        public void SubmitPair(Card card)
        {
            deck.Remove(card);
            Points++;
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
