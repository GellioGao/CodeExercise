using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Interfaces;
using StreamAnalyser.Models;

namespace StreamAnalyser.Outputters
{
    public class ConsoleOutputter : IOutputter
    {
        public void Output(IEnumerable<Result> results)
        {
            var message = string.Join(Environment.NewLine,
                results.Select(r => $"{r.Title}: {r.Content}"));

            Console.Clear();
            Console.WriteLine(message);
        }
    }
}