using System.Collections.Generic;

namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// Heystock definition.  this is useful for injection
    /// </summary>
    public interface IHaystack
    {
        IList<Straw> GetPile();
    }
}