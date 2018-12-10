using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkovChainSentenceGenerator.Interfaces;

namespace MarkovChainSentenceGenerator.Logic
{
    public class ChainSentenceGenerator : IChainSentenceGenerator
    {
        public Random rand { get; set; } = new Random();

        public IWordModel[] WordModels { get; set; }

        public string GenerateSentence()
        {
            IWordModel currentWord = GetRandomWord();
            string returnSentence = currentWord.Word;

            for (int i = 0; i < 10; ++i)
            {
                string[] wordPool = null;
                wordPool = GenerateWordPool(currentWord);
                while (wordPool?.Length == 0)
                {
                    currentWord = GetRandomWord();
                    wordPool = GenerateWordPool(currentWord);
                }

                string chosenWord = wordPool[rand.Next(0, wordPool.Length)];
                returnSentence += " " + chosenWord;
                currentWord = GetNextWordModel(chosenWord);
            }

            return returnSentence;
        }

        private IWordModel GetRandomWord()
        {
            return WordModels[rand.Next(0, WordModels.Length - 1)];
        }

        private string[] GenerateWordPool(IWordModel word)
        {
            List<string> wordPool = new List<string>();
            foreach (KeyValuePair<string, int> wordAndOccurance in word.WordAndOccurance)
            {
                for (int i = 0; i < wordAndOccurance.Value; ++i)
                {
                    wordPool.Add(wordAndOccurance.Key);
                }
            }
            return wordPool.ToArray();
        }

        private IWordModel GetNextWordModel(string word)
        {
            foreach (IWordModel wordmodel in WordModels)
            {
                if (wordmodel.Word == word)
                {
                    return wordmodel;
                }
            }
            return null;
        }
    }
}
