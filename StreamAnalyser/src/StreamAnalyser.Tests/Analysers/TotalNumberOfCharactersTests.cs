using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class TotalNumberOfCharactersTests
    {
        [Fact]
        public void TotalNumberOfCharactersTest_Title()
        {
            var target = new TotalNumberOfCharacters();
            Assert.Equal(Constants.TotalNumberOfCharactersTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "0")]
        [InlineData(new string[] { "a" }, "1")]
        [InlineData(new string[] { "a", "b" }, "2")]
        public void TotalNumberOfCharactersTest(IEnumerable<string> words, string expected)
        {
            var target = new TotalNumberOfCharacters();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}