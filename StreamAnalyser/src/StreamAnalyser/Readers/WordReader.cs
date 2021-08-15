using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StreamAnalyser.Interfaces;

namespace StreamAnalyser.Readers
{
    public class WordReader : IWordReader, IDisposable
    {
        // Can be more.
        private static char[] WordSeparators = new char[] { ' ', ',', '.' };

        private readonly StreamReader reader;

        private bool disposed = false;

        public WordReader(Stream stream)
        {
            this.reader = new StreamReader(stream);
        }

        public bool CanRead => !this.reader.EndOfStream;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.reader.Dispose();
                }

                this.disposed = true;
            }
        }

        public string ReadWord()
        {
            if (!this.CanRead)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            while (this.CanRead)
            {
                var currentInt = this.reader.Read();
                var current = Convert.ToChar(currentInt);

                if (WordSeparators.Contains(current))
                {
                    break;
                }

                builder.Append(current);
            }

            var result = builder.ToString().ToLower();
            return string.IsNullOrEmpty(result) ? this.ReadWord() : result;
        }

        ~WordReader()
        {
            this.Dispose(false);
        }
    }
}