using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    interface IValidate
    {
        bool CheckPair(List<Card> deck, Card card);
    }
}
