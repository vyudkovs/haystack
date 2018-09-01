
namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// interface of haystack organizer
    /// </summary>
    public interface IHaystackOrganizer
    {
        ISortByColorResult SortByColor(IHaystack haystack, ISortByColorResult sortByColorResult);
    }
}
