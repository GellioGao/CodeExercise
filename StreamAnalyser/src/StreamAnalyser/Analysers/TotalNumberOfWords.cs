using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public class TotalNumberOfWords : BaseAnalyser, IAnalyser
    {
        private long wordCount = 0;

        public TotalNumberOfWords() : base(Constants.TotalNumberOfWordsTitle)
        {
            base.Result = this.wordCount.ToString();
        }

        protected override string ProcessWord(string word)
        {
            this.wordCount++;
            return this.wordCount.ToString();
        }
    }
}