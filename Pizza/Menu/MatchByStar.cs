using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Menu
{
    class MatchByStar : IMatchStrategy
    {

        private int Star;

        public MatchByStar(int star)
        {
            this.Star = star;
        }

        public bool MatchProduct(Item item)
        {
            return (item.getStarRating() == this.Star);
        }
    }
}
