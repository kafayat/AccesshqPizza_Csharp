using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Menu
{
    public class MatchByTitle : IMatchStrategy
    {
        private string itemTitle;

        public MatchByTitle(string itemTitle)
        {
            this.itemTitle = itemTitle;

        }
        public bool MatchProduct(Item item)
        {
            return (item.GetItemName().Equals(itemTitle));
        }
    }
}
