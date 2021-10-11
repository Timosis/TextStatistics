using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatistics
{
    public class WordFrequency : IWordFrequency
    {
        public string _word { get; set; }
        public long _frequency { get; set; }

        public WordFrequency(string word, long frequency) {
            _word = word;
            _frequency = frequency;
        }

        public long frequency()
        {
            return _frequency;
        }

        public string word()
        {
            return _word;
        }
    }
}
