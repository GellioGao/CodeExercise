using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class TotalNumberOfCharacters : BaseAnalyser, IAnalyser
    {
        private long characterCount = 0;

        public TotalNumberOfCharacters() : base(Constants.TotalNumberOfCharactersTitle)
        {
            base.Result = this.characterCount.ToString();
        }

        protected override string ProcessWord(string word)
        {
            this.characterCount += word.Length;
            return this.characterCount.ToString();
        }
    }
}