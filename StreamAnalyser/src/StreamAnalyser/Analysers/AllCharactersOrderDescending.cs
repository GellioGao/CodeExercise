using System.Collections.Generic;
using System.Linq;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class AllCharactersOrderDescending : BaseAnalyser, IAnalyser
    {
        private readonly Dictionary<char, int> characterCount = new();

        public AllCharactersOrderDescending() : base(Constants.AllCharactersOrderDescendingTitle)
        {
        }

        protected override string ProcessWord(string word)
        {
            foreach (char c in word)
            {
                if (!this.characterCount.ContainsKey(c))
                {
                    this.characterCount[c] = 0;
                }
                this.characterCount[c]++;
            }
            return string.Join(",",
                this.characterCount
                    .OrderByDescending(kvp => kvp.Value)
                    .Select(kvp => kvp.Key));
        }
    }
}