using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Models;

namespace StreamAnalyser.Interfaces
{
    public interface IOutputter
    {
        void Output(IEnumerable<Result> results);
    }
}