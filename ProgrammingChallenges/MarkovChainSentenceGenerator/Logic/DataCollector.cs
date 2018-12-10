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

            IWordModel[] wordModels = GetWordModels(words);

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

        private IWordModel[] GetWordModels(string[] words)
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
            foreach(IWordModel wordModel in wordModels)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (wordModel.Word == words[i] && i + 1 < words.Length)
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
