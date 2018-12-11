using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MarkovChainSentenceGenerator.Interfaces;
using MarkovChainSentenceGenerator.Models;

namespace MarkovChainSentenceGenerator.Logic
{
    public class DataCollector : IDataCollector
    {
        string fileName;

        public IWordModel[] ParseDataFromFile(string fileName)
        {
            this.fileName = fileName;
            if (FileExists())
            {
                return GetWordModelArray();
            }
            return null;
        }

        private bool FileExists()
        {
            return File.Exists(fileName);
        }

        private IWordModel[] GetWordModelArray()
        {
            string fileString = GetFileAsString();

            string[] words = GetWords(fileString);

            IWordModel[] wordModels = GetWordModelsFromUniqueWords(words);

            CountNextWordsOccurances(wordModels, words);

            return wordModels;
        }

        private string GetFileAsString()
        {
            return String.Join(" ", File.ReadAllLines(fileName));
        }

        private string[] GetWords(string inputString)
        {
            return inputString.Split(' ');
        }

        private IWordModel[] GetWordModelsFromUniqueWords(string[] words)
        {
            List<string> usedWords = new List<string>();
            List<IWordModel> wordModelList = new List<IWordModel>();
            foreach(string word in words)
            {
                if (!usedWords.Contains(word))
                {
                    wordModelList.Add(new WordModel() { Word = word });
                    usedWords.Add(word);
                }
            }

            return wordModelList.ToArray();
        }

        private void CountNextWordsOccurances(IWordModel[] wordModels, string[] words)
        {
            int wordsLength = words.Length; // Performance
            foreach(IWordModel wordModel in wordModels)
            {
                string currentWord = wordModel.Word; // Performance
                for (int i = 0; i < wordsLength; i++)
                {
                    if (currentWord == words[i] && i + 1 < wordsLength)
                    {
                        if (!wordModel.WordAndOccurance.Keys.Contains(words[i + 1]))
                        {
                            wordModel.WordAndOccurance.Add(words[i + 1], 1);
                        }
                        else
                        {
                            ++wordModel.WordAndOccurance[words[i + 1]];
                        }
                    }
                }
            }
        }
    }
}
