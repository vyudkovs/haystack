using System;
using System.Collections.Generic;
using System.Linq;

namespace eBags.PileOfBeans.Haystack
{
    /// <summary>
    /// ColorRules: grey only exists when all colors are same
    /// </summary>
    public static class ColorRules
    {
        public static Color[] GetColorsList(bool all)
        {
            Color[] availableColors = (Color[])Enum.GetValues(typeof(Color));
            if (!all)
            { 
                availableColors = availableColors.Skip(1).ToArray();
            }
            return availableColors;
        }
    }
}
