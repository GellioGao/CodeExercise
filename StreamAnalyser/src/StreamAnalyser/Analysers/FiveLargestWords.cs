using System.Collections.Generic;
using System.Linq;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class FiveLargestWords : BaseAnalyser, IAnalyser
    {
        private string[] largest;

        public FiveLargestWords() : base(Constants.FiveLargestWordsTitle)
        {
            this.largest = Enumerable.Repeat(string.Empty, 5).ToArray();
        }

        protected override string ProcessWord(string word)
        {
            if (largest.All(s => s != word) && largest.Any(s => s.Length < word.Length))
            {
                var list = new List<string>(6);
                list.AddRange(this.largest);
                list.Add(word);
                this.largest = list.OrderByDescending(s => s.Length).Take(5).ToArray();
            }
            return string.Join(",", this.largest.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}