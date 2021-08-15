using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Analysers
{
    public abstract class BaseAnalyser : IAnalyser
    {
        public string Title { get; }

        public virtual string Result { get; protected set; } = string.Empty;

        public BaseAnalyser(string title)
        {
            this.Title = title;
        }

        public virtual void SetWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }
            this.Result = this.ProcessWord(word);
        }

        protected abstract string ProcessWord(string word);
    }
}