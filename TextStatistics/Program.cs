using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextStatistics
{
    class Program
    {

        static void Main(string[] args)
        {

            TextStatic theRiverBoss = new TextStatic("The River Boss.txt");

            Console.WriteLine("\n-------------------{The River Boss}-----------------\n");

            List<WordFrequency> freq = theRiverBoss.topWords(20);

            Console.WriteLine("Top 20 words are listed below");
            Console.WriteLine("\n");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Word: " + freq[i]._word + "--" + " Frequency:" + freq[i]._frequency);
            }
        
            Console.WriteLine("\n");
            Console.WriteLine("Number of lines: " + theRiverBoss.numberOfLines()); 
            Console.WriteLine("\n");
            Console.WriteLine("Number of words: " + theRiverBoss.numberOfWords());

            theRiverBoss.longestWords(20);

            Console.WriteLine("\n");
            Console.WriteLine("Top 10 longest words are listed below");
            List<String> longests = theRiverBoss.longestWords(10);
            Console.WriteLine("\n");

            foreach (var word in longests)
            {
                Console.WriteLine(word);
            }

            TextStatic dracula = new TextStatic("Dracula.txt");

            Console.WriteLine("\n-------------------{Dracula}-----------------\n");


            List<WordFrequency> freq2 = dracula.topWords(20);

            Console.WriteLine("Top 20 words are listed below");
            Console.WriteLine("\n");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Word: " + freq2[i]._word + "--" + " Frequency:" + freq2[i]._frequency);
            }


            Console.WriteLine("\n");
            Console.WriteLine("Number of lines: " + dracula.numberOfLines());
            Console.WriteLine("\n");
            Console.WriteLine("Number of words: " + dracula.numberOfWords());

            dracula.longestWords(20);

            Console.WriteLine("\n");
            Console.WriteLine("Top 10 longest words are listed below");
            List<String> longests2 = dracula.longestWords(10);
            Console.WriteLine("\n");

            foreach (var word in longests2)
            {
                Console.WriteLine(word);
            }

        }
    }
}
