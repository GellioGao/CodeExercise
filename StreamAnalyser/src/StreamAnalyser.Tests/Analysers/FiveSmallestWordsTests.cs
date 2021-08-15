using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class FiveSmallestWordsTests
    {
        [Fact]
        public void FiveSmallestWordsTest_Title()
        {
            var target = new FiveSmallestWords();
            Assert.Equal(Constants.FiveSmallestWordsTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "")]
        [InlineData(new string[] { "a", "b" }, "a,b")]
        [InlineData(new string[] { "a", "a" }, "a")]
        [InlineData(new string[] { "a", "a", "a", "a", "a", "b" }, "a,b")]
        public void FiveSmallestWordsTest(IEnumerable<string> words, string expected)
        {
            var target = new FiveSmallestWords();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}