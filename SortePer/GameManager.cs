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
        List<User> participants = new List<User>() { };
        List<User> finishedUsers = new List<User>();
        ICardManager cm = new PlayingCardManager();
        IValidate v = new PlayingCardValidator();
        public void Start()
        {
            participants.Add(um.CreateUser("Philip"));
            participants.Add(um.CreateUser("Com1"));
            participants.Add(um.CreateUser("Com2"));
            cm.CreateDeck();
            int num = 0;
            while (cm.CardsInDeck() > 0)
            {
                Card c = cm.GiveCard();
                participants[num].GiveCard(c);
                if (num == participants.Count - 1)
                {
                    num = 0;
                }
                else
                {
                    num++;
                }
            }
            foreach (User user in participants)
            {
                user.SubmitPair();
            }

            while (finishedUsers.Count != participants.Count - 1)
            {
                Thread.Sleep(3000);
                TakeTurns();
                Console.WriteLine("You have {0} cards on your hand", participants[0].deck.Count);
                Console.WriteLine("You have {0} pairs so far", participants[0].Points);
            }
        }

        public void TakeTurns()
        {
            for (int i = 0; i < participants.Count; i++)
            {
                Card c;
                bool pair = false;
                if (i == participants.Count - 1)
                {
                    c = participants[0].TakeCard();
                    pair = v.CheckPair(participants[i].deck, c);
                    participants[i].GiveCard(c);
                }
                else
                {
                    c = participants[i + 1].TakeCard();
                    pair = v.CheckPair(participants[i].deck, c);
                    participants[i].GiveCard(c);
                }

                if (pair)
                {
                    Console.WriteLine(participants[i].Name + " Has a pair");
                    participants[i].SubmitPair();
                }

                for (int j = 0; j < participants.Count; j++)
                {
                    if (participants[j].deck.Count == 0)
                    {
                        finishedUsers.Add(participants[j]);
                        Console.WriteLine(participants[j].Name + " Is finished");
                        participants.Remove(participants[j]);
                    }
                }
            }
        }
    }
}
