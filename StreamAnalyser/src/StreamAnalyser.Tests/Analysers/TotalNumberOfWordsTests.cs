using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Analysers;

namespace StreamAnalyser.Analysers.Tests
{
    public class TotalNumberOfWordsTests
    {
        [Fact]
        public void TotalNumberOfWordsTest_Title()
        {
            var target = new TotalNumberOfWords();
            Assert.Equal(Constants.TotalNumberOfWordsTitle, target.Title);
        }

        [Theory]
        [InlineData(new string[] { " " }, "0")]
        [InlineData(new string[] { "a" }, "1")]
        [InlineData(new string[] { "a", "b" }, "2")]
        public void TotalNumberOfWordsTest(IEnumerable<string> words, string expected)
        {
            var target = new TotalNumberOfWords();
            foreach (var word in words)
            {
                target.SetWord(word);
            }

            Assert.Equal(expected, target.Result);
        }
    }
}