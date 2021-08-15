using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Interfaces;
using StreamAnalyser.Models;

namespace StreamAnalyser
{
    public class StreamAnalyser : IStreamAnalyser
    {
        private readonly IEnumerable<IAnalyser> analysers;

        public StreamAnalyser(IEnumerable<IAnalyser> analysers)
        {
            this.analysers = analysers;
        }

        public void Analyse(IWordReader reader, IOutputter outputter)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (outputter == null)
            {
                throw new ArgumentNullException(nameof(outputter));
            }
            while (reader.CanRead)
            {
                try
                {
                    var word = reader.ReadWord();
                    foreach (var analyser in analysers)
                    {
                        analyser.SetWord(word);
                    }
                    var result = this.analysers
                        .Select(analyser => new Result(analyser.Title, analyser.Result));
                    outputter.Output(result);
                }
                catch (IOException)
                {
                    outputter.Output(new[] { new Result(Constants.ErrorMessageTitle, Constants.FailedToReadStreamMessage) });
                }
                catch (Exception ex)
                {
                    outputter.Output(new[] { new Result(Constants.ErrorMessageTitle, ex.Message) });
                }

                // Only for the demo, too fast to read the output if no delay.
                Task.Delay(200).Wait();
            }
        }
    }
}