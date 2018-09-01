namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// Sorts straw into red/green... piles
    /// </summary>
    public class HaystackOrganizer : IHaystackOrganizer
    {
        /// <summary>
        /// Sorts the haystack pile into color groups.
        /// </summary>
        /// <param name="haystack">The haystack instance containing the pile to be sorted.</param>
        /// <returns>Result containing the sorted, ordered lists of unique straws from the haystack.</returns>
        public ISortByColorResult SortByColor(IHaystack haystack, ISortByColorResult sortByColorResult)
        {
            foreach(var straw in haystack.GetPile())
            {
                sortByColorResult.Add(straw);
            }
            return sortByColorResult;
        }
    }
}
