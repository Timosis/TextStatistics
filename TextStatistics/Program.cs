using Microsoft.Extensions.DependencyInjection;
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

            var serviceProvider = new ServiceCollection()            
            .AddSingleton<ITextStatics, TextStatic>()
            .AddSingleton<IWordFrequency, WordFrequency>()
            .BuildServiceProvider();

            var textstaticsService = serviceProvider.GetService<ITextStatics>();

            textstaticsService.getTextFile("The River Boss.txt");
                        
            //TextStatic theRiverBoss = new TextStatic();

            Console.WriteLine("\n-------------------{The River Boss}-----------------\n");

            List<WordFrequency> freq = textstaticsService.topWords(20);

            Console.WriteLine("Top 20 words are listed below");
            Console.WriteLine("\n");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Word: " + freq[i]._word + "--" + " Frequency:" + freq[i]._frequency);
            }
        
            Console.WriteLine("\n");
            Console.WriteLine("Number of lines: " + textstaticsService.numberOfLines()); 
            Console.WriteLine("\n");
            Console.WriteLine("Number of words: " + textstaticsService.numberOfWords());

            textstaticsService.longestWords(20);

            Console.WriteLine("\n");
            Console.WriteLine("Top 10 longest words are listed below");
            List<String> longests = textstaticsService.longestWords(10);
            Console.WriteLine("\n");

            foreach (var word in longests)
            {
                Console.WriteLine(word);
            }

            textstaticsService.getTextFile("Dracula.txt");

            Console.WriteLine("\n-------------------{Dracula}-----------------\n");


            List<WordFrequency> freq2 = textstaticsService.topWords(20);

            Console.WriteLine("Top 20 words are listed below");
            Console.WriteLine("\n");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Word: " + freq2[i]._word + "--" + " Frequency:" + freq2[i]._frequency);
            }


            Console.WriteLine("\n");
            Console.WriteLine("Number of lines: " + textstaticsService.numberOfLines());
            Console.WriteLine("\n");
            Console.WriteLine("Number of words: " + textstaticsService.numberOfWords());

            textstaticsService.longestWords(20);

            Console.WriteLine("\n");
            Console.WriteLine("Top 10 longest words are listed below");
            List<String> longests2 = textstaticsService.longestWords(10);
            Console.WriteLine("\n");

            foreach (var word in longests2)
            {
                Console.WriteLine(word);
            }

        }
    }
}
