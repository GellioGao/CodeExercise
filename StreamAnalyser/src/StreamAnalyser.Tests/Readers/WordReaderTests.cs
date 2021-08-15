using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using StreamAnalyser.Readers;

namespace StreamAnalyser.Readers.Tests
{
    public class WordReaderTests
    {
        [Theory()]
        [InlineData(" ", "")]
        [InlineData(" a ", "a")]
        [InlineData(" A ", "a")]
        [InlineData(" a b", "a")]
        [InlineData(" a, b", "a")]
        [InlineData(" A. b", "a")]
        [InlineData("a.", "a")]
        public void ReadWordTest_Read_First(string given, string expected)
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(given));
            using var reader = new WordReader(stream);
            Assert.Equal(expected, reader.ReadWord());
        }

        [Theory()]
        [InlineData(" a ", new string[] { "a" })]
        [InlineData(" A ", new string[] { "a" })]
        [InlineData(" a b", new string[] { "a", "b" })]
        [InlineData(" a, b", new string[] { "a", "b" })]
        [InlineData(" A. b", new string[] { "a", "b" })]
        [InlineData("a.", new string[] { "a" })]
        public void ReadWordTest_Read_All(string given, IEnumerable<string> expected)
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(given));
            var list = new List<string>();
            using var reader = new WordReader(stream);
            while (reader.CanRead)
            {
                list.Add(reader.ReadWord());
            }
            Assert.Equal(expected, list);
        }
    }
}