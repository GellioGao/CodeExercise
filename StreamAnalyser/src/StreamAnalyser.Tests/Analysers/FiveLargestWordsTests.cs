using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class FiveLargestWordsTests
    {
        [Fact]
        public void FiveLargestWordsTest_Title()
        {
            var target = new FiveLargestWords();
            Assert.Equal(Constants.FiveLargestWordsTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "")]
        [InlineData(new string[] { "a", "b" }, "a,b")]
        [InlineData(new string[] { "a", "a" }, "a")]
        [InlineData(new string[] { "a", "a", "a", "a", "a", "b" }, "a,b")]
        public void FiveLargestWordsTest(IEnumerable<string> words, string expected)
        {
            var target = new FiveLargestWords();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}