using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Models;

namespace StreamAnalyser.Interfaces
{
    public interface IStreamAnalyser
    {
        void Analyse(IWordReader reader, IOutputter outputter);
    }
}