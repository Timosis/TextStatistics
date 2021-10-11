using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatistics
{
    public interface IWordFrequency
    {
        /**
        * The word.
        * @return the word as a string.
        */
        String word();
        /**
        * The frequency.
        * @return a long representing the frequency of the word.
        */
        long frequency();
    }
}
