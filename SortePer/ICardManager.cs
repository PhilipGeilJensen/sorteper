using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    interface ICardManager
    {
        /// <summary>
        /// Create's the deck with the proper amount of cards and the chosen type
        /// </summary>
        void CreateDeck();
        /// <summary>
        /// Give's a card from the deck
        /// </summary>
        /// <returns></returns>
        Card GiveCard();
        /// <summary>
        /// Return the number of cards left in the deck
        /// </summary>
        /// <returns></returns>
        int CardsInDeck();
    }
}
