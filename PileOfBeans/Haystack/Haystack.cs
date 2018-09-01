using System;
using System.Collections.Generic;
using System.Linq;

namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// Haystack of straw: represents the object we will sort
    /// </summary>
    public class Haystack: IHaystack
    {
        private const int PILE_SIZE_MIN = 2000000;
        private const int PILE_SIZE_MAX = 3000000;
        private const int COLOR_MIN = 0;
        private const int COLOR_MAX = 256;
        private const int LENGTH_MIN = 50;
        private const int LENGTH_MAX = 2000000;

        private readonly IList<Straw> _pile;

        public IList<Straw> GetPile()
        {
            return Pile;
        }
        private IList<Straw> Pile => _pile;

        /// <summary>
        /// Constructor for hackstack: it will set up milions of straw in the haystack
        /// </summary>
        public Haystack()
        {
            Color[] availableColors = ColorRules.GetColorsList(false);
            var generator = new Random(DateTime.Now.Millisecond);
            var size = generator.Next(PILE_SIZE_MIN, PILE_SIZE_MAX);

            _pile = new List<Straw>();

            // Build the pile...
            for (int i = 0; i < size; i++)
            {
                _pile.Add(
                    new Straw(
                        generator.Next(LENGTH_MIN, LENGTH_MAX) / (decimal)10,
                        availableColors.Select(color=> new KeyValuePair<Color, int>(color, generator.Next(COLOR_MIN, COLOR_MAX))).ToList()
                    ));
            }
        }
    }
}
