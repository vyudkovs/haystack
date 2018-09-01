using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;

namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// SortByColorResult holds results of sorted straw
    /// it also contains business rules to how to sort it.
    /// </summary>
    public class SortByColorResult : ISortByColorResult
    {
        private Color[] Colors = ColorRules.GetColorsList(true);
        public SortByColorResult()
        {
            SortedHay = new Dictionary<Color, OrderedDictionary>();
            foreach(var color in Colors)
            {
                SortedHay.Add(color, new OrderedDictionary());
            }
        }

        public Dictionary<Color, OrderedDictionary> SortedHay { get; set; }

        public void Add(Straw straw)
        {
            var maxValue = 0;
            var selectedColor = Colors.Last();
            var colorSame = true;
            int prevValue = -1;
            foreach (var color in straw.ColorsWithValues)
            {
                colorSame = colorSame && (prevValue == -1 || prevValue == color.Value);
                prevValue = color.Value;
                if (maxValue < color.Value)
                {
                    maxValue = color.Value;
                    selectedColor = color.Key;
                }
                else if (maxValue == color.Value && color.Key < selectedColor)
                {
                    maxValue = color.Value;
                    selectedColor = color.Key;
                }
            }
            selectedColor = colorSame ? Color.Gray : selectedColor;
            var dictionary = SortedHay[selectedColor];
            if (!dictionary.Contains(straw.LengthInCm))
            {
                dictionary.Add(straw.LengthInCm, straw);
            }
        }
    }
}
