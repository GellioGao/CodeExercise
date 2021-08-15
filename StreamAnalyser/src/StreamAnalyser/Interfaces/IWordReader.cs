using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamAnalyser.Interfaces
{
    public interface IWordReader : IDisposable
    {
        bool CanRead { get; }

        string ReadWord();
    }
}