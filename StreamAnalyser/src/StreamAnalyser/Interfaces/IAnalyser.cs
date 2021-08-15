using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamAnalyser.Interfaces
{
    public interface IAnalyser
    {
        string Title { get; }
        string Result { get; }

        void SetWord(string word);
    }
}