using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class AllCharactersOrderDescendingTests
    {
        [Fact]
        public void AllCharactersOrderDescendingTest_Title()
        {
            var target = new AllCharactersOrderDescending();
            Assert.Equal(Constants.AllCharactersOrderDescendingTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "")]
        [InlineData(new string[] { "a" }, "a")]
        [InlineData(new string[] { "a", "b" }, "a,b")]
        [InlineData(new string[] { "a", "bb" }, "b,a")]
        public void AllCharactersOrderDescendingTest(IEnumerable<string> words, string expected)
        {
            var target = new AllCharactersOrderDescending();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}