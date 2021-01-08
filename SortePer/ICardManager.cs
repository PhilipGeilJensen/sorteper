using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    interface ICardManager
    {
        void CreateDeck();

        Card GiveCard();

        int CardsInDeck();
    }
}
