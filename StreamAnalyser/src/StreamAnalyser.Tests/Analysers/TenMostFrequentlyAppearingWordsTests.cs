using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class TenMostFrequentlyAppearingWordsTests
    {
        [Fact]
        public void TenMostFrequentlyAppearingWordsTest_Title()
        {
            var target = new TenMostFrequentlyAppearingWords();
            Assert.Equal(Constants.TenMostFrequentlyAppearingWordsTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "")]
        [InlineData(new string[] { "a", "b" }, "a,b")]
        [InlineData(new string[] {
            "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "b", "b", "b", "b", "b", "b", "b", "b", "b",
            "c", "c", "c", "c", "c", "c", "c", "c",
            "d", "d", "d", "d", "d", "d", "d",
            "e", "e", "e", "e", "e", "e",
            "f", "f", "f", "f", "f",
            "g", "g", "g", "g",
            "h", "h", "h",
            "i", "i",
            "j"
        }, "a,b,c,d,e,f,g,h,i,j")]
        public void TenMostFrequentlyAppearingWordsTest(IEnumerable<string> words, string expected)
        {
            var target = new TenMostFrequentlyAppearingWords();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}