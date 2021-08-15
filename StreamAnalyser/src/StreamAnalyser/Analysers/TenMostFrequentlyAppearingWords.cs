using System.Collections.Generic;
using System.Linq;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class TenMostFrequentlyAppearingWords : BaseAnalyser, IAnalyser
    {
        private readonly Dictionary<string, int> appearingFrequency = new();

        public TenMostFrequentlyAppearingWords() : base(Constants.TenMostFrequentlyAppearingWordsTitle)
        {
        }

        protected override string ProcessWord(string word)
        {
            if (!this.appearingFrequency.ContainsKey(word))
            {
                this.appearingFrequency[word] = 0;
            }
            this.appearingFrequency[word]++;
            return string.Join(",",
                this.appearingFrequency
                    .OrderByDescending(kvp => kvp.Value)
                    .Take(10)
                    .Select(kvp => kvp.Key));
        }
    }
}