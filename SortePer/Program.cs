using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortePer
{
    class Program
    {
        static void Main(string[] args)
        {

            GameManager gm = new GameManager();

            Console.WriteLine("Enter you'r name");
            gm.CreatePlayer(Console.ReadLine());

            gm.Start();


            while (!gm.CheckIfGameIsOver())
            {
                Console.Clear();
                User user = gm.GetNextUser();
                TakeTurn(user, gm);
                Thread.Sleep(1000);
            }

            Console.WriteLine("{0} lost the game", gm.loser.Name);

            Console.ReadLine();
        }

        public static void TakeTurn(User u, GameManager gm)
        {

            Card c = gm.TakeCardFromNextPlayer();
            User nextPlayer = gm.NextUserInLine();
            Console.WriteLine("{0} Takes a card from {1}", u.Name, nextPlayer.Name);

            //Check if the player who just had a card taken is finished
            User finishedPlayer = gm.CheckIfNextPlayerIsFinished();
            if (finishedPlayer != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(finishedPlayer.Name + " Is finished because {0} took the last card", u.Name);
                Console.ResetColor();
            }

            if (gm.SubmitUserPair(u, c))
            {
                Console.WriteLine("{0} has a pair", u.Name);
            }

            if (gm.CheckIfUserIsDone(u))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(u.Name + " Is finished because of a last pair");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Name - {0}", u.Name);
            Console.WriteLine("Pairs - {0}", u.Points);
            Console.WriteLine("Cards left - {0}", u.deck.Count);
            Console.WriteLine();
        }
    }
}
