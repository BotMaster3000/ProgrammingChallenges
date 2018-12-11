using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MarkovChainSentenceGenerator.Logic;
using MarkovChainSentenceGenerator.Interfaces;

namespace MarkovChainSentenceGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "";
            do
            {
                Console.WriteLine("Write a file you want to read from:");
                fileName = Console.ReadLine();
            }
            while (!File.Exists(fileName));

            Console.WriteLine("Parsing File. Please wait.");
            DataCollector collector = new DataCollector();
            IWordModel[] wordModelArray = collector.ParseDataFromFile(fileName);

            Console.WriteLine("Generating Sentences. Type /s to abort and exit");
            ChainSentenceGenerator sentenceGenerator = new ChainSentenceGenerator()
            {
                WordModels = wordModelArray
            };
            do
            {
                Console.WriteLine(sentenceGenerator.GenerateSentence());
            }
            while (Console.ReadLine() != "/s");
        }
    }
}
