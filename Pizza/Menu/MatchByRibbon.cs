using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Menu
{
    public class MatchByRibbon : IMatchStrategy
    {


        string ribbonText;

        public MatchByRibbon(string ribbonText)
        {
            this.ribbonText = ribbonText;
        }
        public bool MatchProduct(Item item)
        {
            return (item.getRibbonText().Equals(ribbonText));
        }
    }
}
