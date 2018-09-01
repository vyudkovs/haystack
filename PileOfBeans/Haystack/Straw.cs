
using System.Collections.Generic;

namespace eBags.PileOfBeans.Haystack
{
    public class Straw
    {
        public decimal LengthInCm { get; private set; }
        public List<KeyValuePair<Color, int>> ColorsWithValues { get; private set; }

        public Straw(
            decimal lengthInCm,
            List<KeyValuePair<Color, int>> colors)
        {
            LengthInCm = lengthInCm;
            ColorsWithValues = colors;
        }
    }
}
