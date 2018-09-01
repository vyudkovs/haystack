using eBags.PileOfBeans.Haystack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eBags.PileOfBeans.Test
{
    public class EmptyHaystack : IHaystack
    {
        public IList<Straw> GetPile()
        {
            return Pile;
        }
        private IList<Straw> Pile => new List<Straw>();
    }
}