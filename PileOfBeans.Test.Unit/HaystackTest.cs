using Microsoft.VisualStudio.TestTools.UnitTesting;
using eBags.PileOfBeans.Haystack;
using System.Diagnostics;
using System.Linq;

namespace eBags.PileOfBeans.Test.Unit
{
    [TestClass]
    public class HaystackTest
    {
        /// <summary>
        /// set up mock haystack
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            _haystackOrganizer = new HaystackOrganizer();
            _sortByColorResult = _haystackOrganizer.SortByColor(new eBags.PileOfBeans.Test.Haystack(), new SortByColorResult());
            stopWatch.Stop();
            _timeTaken = stopWatch.ElapsedMilliseconds;
        }

        private ISortByColorResult _sortByColorResult = new SortByColorResult();
        private IHaystackOrganizer _haystackOrganizer;
        private long _timeTaken = 0;

        /// <summary>
        /// this is a performance test usnig real haystack.  result is relative to machine it runs on.
        /// it would be more useful to benchmark it on a server running under load.
        /// 10 second rule is entirely made up: this value would need to be calculated using real epectations
        /// also this test would not be part of unit tests.  I would rather have a logger calculate these on the server
        /// </summary>
        [TestMethod]
        public void LoadTest()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            IHaystackOrganizer haystackOrganizer = new HaystackOrganizer();
            ISortByColorResult sortByColorResult = haystackOrganizer.SortByColor(new eBags.PileOfBeans.Haystack.Haystack(), new SortByColorResult());
            stopWatch.Stop();
            var timeTaken = stopWatch.ElapsedMilliseconds;
            Assert.IsTrue(timeTaken < 10000, "Expected to finish this within 10 seconds");
        }

        /// <summary>
        /// check every result to make sure that colors are properly sorted.
        /// this means that if green was larger or equal to blue it goes into the green pile
        /// this will test the following:
        /// 1.  red will win over the other colors if values are equal
        /// 2.  red will win over other colors when red is the greatest
        /// 3.  green will win over other colors only whne green is the greatest or equal to blue
        /// </summary>
        [TestMethod]
        public void ColorTest()
        {
            foreach (var item in _sortByColorResult.SortedHay)
            {
                var color = item.Key;
                foreach (var value in item.Value)
                {
                    Straw straw = (Straw)((System.Collections.DictionaryEntry)value).Value;
                    if (color == Color.Red)
                    {
                        Assert.IsTrue(straw.ColorsWithValues[0].Value >= straw.ColorsWithValues[1].Value, "Expected to have higher count on red");
                        Assert.IsTrue(straw.ColorsWithValues[0].Value >= straw.ColorsWithValues[2].Value, "Expected to have higher count on red");
                    }
                    else if (color == Color.Green)
                    {
                        Assert.IsTrue(straw.ColorsWithValues[1].Value <= straw.ColorsWithValues[2].Value, "Expected to have higher count on green");
                        Assert.IsTrue(straw.ColorsWithValues[0].Value <= straw.ColorsWithValues[2].Value, "Expected to have higher count on green");
                    }
                }
            }
        }

        /// <summary>
        /// We expect to have two blue (third was a duplicate and three red 
        /// one because it's greater, two equals by default because our rules 
        /// favor colors with smallest values in the Color enum
        /// </summary>
        [TestMethod]
        public void CountTest()
        {
            var grays = _sortByColorResult.SortedHay[Color.Gray];
            var reds = _sortByColorResult.SortedHay[Color.Red];
            var greens = _sortByColorResult.SortedHay[Color.Green];
            var blues = _sortByColorResult.SortedHay[Color.Blue];
            Assert.AreEqual(1, grays.Values.Count, "Expected to have one gray");
            Assert.AreEqual(2, reds.Values.Count, "Expected to have three reds");
            Assert.AreEqual(2, greens.Values.Count, "Expected to have two greens");
            Assert.AreEqual(0, blues.Values.Count, "Expected to have zero greens");
        }

        /// <summary>
        /// Check that inside the list numbers are from smallest to largest
        /// </summary>
        [TestMethod]
        public void ValueTest()
        {
            var reds = _sortByColorResult.SortedHay[Color.Red];
            var greens = _sortByColorResult.SortedHay[Color.Green];
            var blues = _sortByColorResult.SortedHay[Color.Blue];

            decimal lastStraw = 0;
            foreach(var value in reds)
            {
                Straw straw = (Straw)((System.Collections.DictionaryEntry)value).Value;
                Assert.IsTrue(lastStraw < straw.LengthInCm, "Expected last strat to be less than current");
            }
        }

        /// <summary>
        /// Test if no straw
        /// </summary>
        [TestMethod]
        public void EmptyTest()
        {
            var haystackOrganizer = new HaystackOrganizer();
            var sortByColorResult = haystackOrganizer.SortByColor(new EmptyHaystack(), new SortByColorResult());
            var reds = sortByColorResult.SortedHay[Color.Red];
            var greens = sortByColorResult.SortedHay[Color.Green];
            var blues = sortByColorResult.SortedHay[Color.Blue];
            Assert.AreEqual(0, reds.Values.Count, "Expected to have zero reds");
            Assert.AreEqual(0, greens.Values.Count, "Expected to have zero greens");
            Assert.AreEqual(0, blues.Values.Count, "Expected to have zero greens");
        }
    }
}
