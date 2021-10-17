using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatistics
{
    public interface ITextStatics
    {
        /**
        * Returns a list of the most frequented words of the text.
        * @param n how many items of the list
        * @return a list representing the top n frequent words of the text.
        */
        List<WordFrequency> topWords(int n);
        /**
        * Returns a list of the longest words of the text.
        * @param n how many items to return.
        * @return a list with the n longest words of the text.
        */
        List<string> longestWords(int n);
        /**
        * @return total number of words in the text.
        */
        long numberOfWords();
        /**
        * @return total number of line of the text.
        */
        long numberOfLines();

        /**
         * @return special sign  filtered and lowercased book
         */
        string filterer();

        void getTextFile(string textFilename);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SortedDictionary<string, int> wordCounts();

    }
}
