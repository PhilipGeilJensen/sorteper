using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortePer
{
    class GameManager
    {
        UserManager um = new UserManager();
        Queue<User> participants = new Queue<User>() { };
        List<User> finishedUsers = new List<User>();
        ICardManager cm = new PlayingCardManager();
        IValidate v = new PlayingCardValidator();
        public User loser;

        /// <summary>
        /// Starts the game
        /// </summary>
        public void Start()
        {
                participants.Enqueue(um.CreateUser("Com1"));
                participants.Enqueue(um.CreateUser("Com2"));
                cm.CreateDeck();
                while (cm.CardsInDeck() > 0)
                {
                    Card c = cm.GiveCard();
                    User u = participants.Dequeue();
                    u.GiveCard(c);
                    participants.Enqueue(u);
                }
                foreach (User u in participants)
                {
                    for (int i = 0; i < u.deck.Count; i++)
                    {
                        Card c = u.deck[i];
                        //remove the card to check from the deck - in order to avoid it being checked with itself
                        u.deck.Remove(c);
                        Card pair = v.CheckPair(u.deck, c);
                        if (pair != null)
                        {
                            u.SubmitPair(pair);
                        }
                        else
                        {
                            u.deck.Add(c);
                        }
                    }
                }
        }
        /// <summary>
        /// Create's the player
        /// </summary>
        /// <param name="name"></param>
        public void CreatePlayer(string name)
        {
            participants.Enqueue(um.CreateUser(name, true));
        }

        /// <summary>
        /// Returns the next user in line
        /// </summary>
        /// <returns></returns>
        public User GetNextUser()
        {
            return participants.Dequeue();
        }
        /// <summary>
        /// Takes a card from the next user in line
        /// </summary>
        /// <returns></returns>
        public Card TakeCardFromNextPlayer()
        {
            return participants.Peek().TakeCard();
        }
        /// <summary>
        /// Checks if the withdrawen card matches any cards in the users deck
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public Card CheckPair(List<Card> deck, Card card)
        {
            return v.CheckPair(deck, card);
        }
        /// <summary>
        /// Checks if the next player has 0 cards and therefore is finished
        /// </summary>
        /// <returns></returns>
        public User CheckIfNextPlayerIsFinished()
        {
            if (participants.Peek().deck.Count == 0)
            {
                finishedUsers.Add(participants.Peek());
                User u = participants.Dequeue();
                return u;
            }
            return null;
        }
        /// <summary>
        /// Submits a user pair - removing the cards from the deck and adding a point
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool SubmitUserPair(User u, Card c)
        {
            Card pair = CheckPair(u.deck, c);

            if (pair != null)
            {
                u.SubmitPair(pair);
                return true;
            }
            else
            {
                u.GiveCard(c);
                return false;
            }
        }
        /// <summary>
        /// Checks if the user has 0 cards and therefore done, otherwise is put back in the queue
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool CheckIfUserIsDone(User u)
        {
            if (u.deck.Count == 0)
            {
                finishedUsers.Add(u);
                return true;
            }
            else
            {
                participants.Enqueue(u);
                return false;
            }
        }
        /// <summary>
        /// Checks if there is only 1 participant with cards left, and therefore the game is finished
        /// </summary>
        /// <returns></returns>
        public bool CheckIfGameIsOver()
        {
            if (participants.Count <= 1)
            {
                loser = participants.Dequeue();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns the next user in line
        /// </summary>
        /// <returns></returns>
        public User NextUserInLine()
        {
            return participants.Peek();
        }
    }
}
