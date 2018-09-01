using eBags.PileOfBeans.Haystack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eBags.PileOfBeans.Test
{
    public class Haystack: IHaystack
    {
        public IList<Straw> GetPile()
        {
            return Pile;
        }
        private IList<Straw> Pile => new List<Straw>
        {
            new Straw(1, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 1),
                new KeyValuePair<Color, int>(Color.Blue, 2),
                new KeyValuePair<Color, int>(Color.Green, 3),
            }),
            new Straw(1, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 1),
                new KeyValuePair<Color, int>(Color.Blue, 2),
                new KeyValuePair<Color, int>(Color.Green, 3),
            }),
            new Straw(2, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 1),
                new KeyValuePair<Color, int>(Color.Blue, 2),
                new KeyValuePair<Color, int>(Color.Green, 3),
            }),
            new Straw(3, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 3),
                new KeyValuePair<Color, int>(Color.Blue, 2),
                new KeyValuePair<Color, int>(Color.Green, 1),
            }),
            new Straw(4, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 4),
                new KeyValuePair<Color, int>(Color.Blue, 4),
                new KeyValuePair<Color, int>(Color.Green, 4),
            }),
            new Straw(5, new List<KeyValuePair<Color, int>>()
            {
                new KeyValuePair<Color, int>(Color.Red, 5),
                new KeyValuePair<Color, int>(Color.Blue, 5),
                new KeyValuePair<Color, int>(Color.Green, 4),
            }),
        };
    }
}
