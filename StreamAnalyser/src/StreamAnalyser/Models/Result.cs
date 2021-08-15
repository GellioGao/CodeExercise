using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamAnalyser.Models
{
    public class Result
    {
        public Result(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public string Title { get; }
        public string Content { get; }
    }
}