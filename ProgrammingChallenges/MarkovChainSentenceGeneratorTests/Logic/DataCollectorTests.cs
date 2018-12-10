using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarkovChainSentenceGenerator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MarkovChainSentenceGenerator.Interfaces;

namespace MarkovChainSentenceGenerator.Logic.Tests
{
    [TestClass]
    public class DataCollectorTests
    {
        private const string testFileName = "Test.txt";
        private const string testFileContent = "Test, this is a test, a test for testing the tests created for testing";

        private void GenerateTestFile()
        {
            File.Create(testFileName).Close();
            File.AppendAllText(testFileName, testFileContent);
        }

        [TestMethod]
        public void ParseDataFromFile_AllWordsFoundTest()
        {
            GenerateTestFile();
            DataCollector dataCollector = new DataCollector();
            IWordModel[] wordModels = dataCollector.ParseDataFromFile(testFileName);
            foreach (string word in testFileContent.Split(' '))
            {
                bool found = false;
                foreach (IWordModel wordModel in wordModels)
                {
                    if (wordModel.Word == word)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Assert.Fail("Word not found: " + word);
                }
            }
        }
    }
}