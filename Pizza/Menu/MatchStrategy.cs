using System;

namespace Pizza.Menu
{
    public interface IMatchStrategy
    {
         bool MatchProduct(Item item);
      
    }
}
