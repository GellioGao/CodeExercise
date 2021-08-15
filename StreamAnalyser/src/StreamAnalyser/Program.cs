using System;
using System.Threading.Tasks;

using Booster.CodingTest.Library;

using StreamAnalyser.Analysers;
using StreamAnalyser.Interfaces;
using StreamAnalyser.Outputters;
using StreamAnalyser.Readers;

namespace StreamAnalyser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var outputter = new ConsoleOutputter();
            var stream = new WordStream();
            using var reader = new WordReader(stream);

            // Configure analysers
            var analser = new StreamAnalyser(new IAnalyser[]
            {
                new TotalNumberOfCharacters(),
                new TotalNumberOfWords(),
                new FiveLargestWords(),
                new FiveSmallestWords(),
                new TenMostFrequentlyAppearingWords(),
                new AllCharactersOrderDescending()
            });
            try
            {
                analser.Analyse(reader, outputter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}