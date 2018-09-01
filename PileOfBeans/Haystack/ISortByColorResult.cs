using System.Collections.Generic;
using System.Collections.Specialized;

namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// Interface to SortByColorResult.
    /// SortByColorResult.Add hold business rules that can be injected/overwritten if needed
    /// </summary>
    public interface ISortByColorResult
    {
        Dictionary<Color, OrderedDictionary> SortedHay { get; set; }
        void Add(Straw straw);
    }
}