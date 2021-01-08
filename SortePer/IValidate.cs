using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    interface IValidate
    {
        /// <summary>
        /// Checks if their is a match in the given deck with the given card
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="card"></param>
        /// <returns>True if there is a match - false if not</returns>
        Card CheckPair(List<Card> deck, Card card);
    }
}
