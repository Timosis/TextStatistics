using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace TextStatistics
{
    public class TextStatic : ITextStatics
    {
        /// <summary>
        /// Sorted dictionary that contains words and their frequency
        /// </summary>
        SortedDictionary<string, int> words { get; set; }

        /// <summary>
        /// Location of text like C:\\Books\\bookname.txts...
        /// </summary>
        public string textFilename { get; set; }

        public void  getTextFile(string textFilename)
        {
            this.textFilename = textFilename;
            words = wordCounts();
        }
       
        /// <summary>
        ///  Getting n longest words in text
        /// </summary>
        /// <param name="n">user input</param>
        /// <returns>List of n longest word</returns>
        public List<string> longestWords(int n)
        {
            //For storing words count
            List<String> longestWords = new List<String>();
            int counter = words.Count;

            foreach (KeyValuePair<string, int> word in words.OrderBy(word => word.Key.Length))
            {
                if(counter < n)
                {
                    longestWords.Add(word.Key);
                }
                counter--;
            }
            return longestWords;
        }

        /// <summary>
        /// Calculating number lines of text file.
        /// </summary>
        /// <returns>Number Of Lines</returns>
        public long numberOfLines()
        {
            long lineNumber = 0;
            
            using (StreamReader reader = File.OpenText(textFilename))
            {
                while (reader.ReadLine() != null)
                {
                    lineNumber++;
                }
            }

            return lineNumber;
        }

        /// <summary>
        /// Calculating number of words in text file
        /// </summary>
        /// <returns>Number of words</returns>
        public long numberOfWords()
        {
            using (TextReader reader = File.OpenText(textFilename))
            {
                String text = reader.ReadToEnd();
                int wordCount = 0;
                int index = 0;

                while (index < text.Length)
                {
                    //karakter var mı yok mu onu kontrol ediyor. Varsa döngüden çıkıp wordcount'ı arttıryor.
                    while (index < text.Length && !char.IsWhiteSpace(text[index]))
                        index++;

                    wordCount++;

                    //Boşlukları geçmek için. Birden fazla boşluk olduğu için while loop kullanıldı.
                    while(index < text.Length && char.IsWhiteSpace(text[index]))
                            index++;
                }

                return wordCount;
            }
        }

        /// <summary>
        /// Listing top n words in frequency
        /// </summary>
        /// <param name="n">How much words user would like to see on screen.</param>
        /// <returns>List of word frequency</returns>
        public List<WordFrequency> topWords(int n)
        {           
            List<WordFrequency> list = new List<WordFrequency>();

            int counter = words.Count;

            foreach (KeyValuePair<string, int> author in words.OrderBy(key => key.Value))
            {
                counter--;

                if(counter < n)
                {

                    long value = author.Value;
                    WordFrequency wordFrequency = new WordFrequency(author.Key, value);
                    list.Add(wordFrequency);
                }
                
            }

            return list;
        }

        /// <summary>
        /// Removing special characters in text
        /// </summary>
        /// <returns>Text which is removed special characters</returns>
        public String filterer()
        {
            String filtered = File.ReadAllText(textFilename);
            filtered = (Regex.Replace(filtered, @"[^0-9a-zA-Z]+", " ")).ToLower();

            return filtered;
        }

        /// <summary>
        /// Creates a dictionary with words and their frequency from text.
        /// </summary>
        /// <returns>Sorted dictionary with word as a key and frequency as a value</returns>
        public SortedDictionary<string, int> wordCounts()
        {
            String book = filterer();

            SortedDictionary<string, int> wordCounts = new SortedDictionary<string, int>();

            string[] words = book.Split(' ');
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    int frequency = 1;
                    if (wordCounts.ContainsKey(word))
                    {
                        frequency = wordCounts[word] + 1;
                    }

                    wordCounts[word] = frequency;
                }
            }           
            return wordCounts;

        }
    }
}
