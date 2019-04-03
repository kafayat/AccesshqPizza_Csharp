using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Menu
{
    class MatchByVegan : IMatchStrategy
    {
        public bool MatchProduct(Item item)
        {
            return item.getVeganPizza();
        }
    }
}
