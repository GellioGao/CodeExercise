using System.Collections.Generic;
using System.Linq;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class FiveSmallestWords : BaseAnalyser, IAnalyser
    {
        private string[] smallest;

        public FiveSmallestWords() : base(Constants.FiveSmallestWordsTitle)
        {
            this.smallest = Enumerable.Repeat(Constants.LargestWordPlaceholder, 5).ToArray();
        }

        protected override string ProcessWord(string word)
        {
            if (smallest.All(s => s != word) && smallest.Any(s => s.Length > word.Length))
            {
                var list = new List<string>(6);
                list.AddRange(this.smallest);
                list.Add(word);
                this.smallest = list.OrderBy(s => s.Length).Take(5).ToArray();
            }
            return string.Join(",", this.smallest.Where(s => s != Constants.LargestWordPlaceholder));
        }
    }
}