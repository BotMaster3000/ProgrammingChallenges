using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarkovChainSentenceGenerator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarkovChainSentenceGenerator.Logic.Tests
{
    [TestClass]
    public class ChainSentenceGeneratorTests
    {
        private const string testFileName = "Test.txt";
        private const string testFileContent = "Test, this is a test, a test for testing the tests created for testing apple pies and lemon cakes whereas apple cakes and pies come together";

        private void GenerateTestFile()
        {
            File.Create(testFileName).Close();
            File.AppendAllText(testFileName, testFileContent);
        }

        [TestMethod]
        public void GenerateSentenceTest()
        {
            GenerateTestFile();

            ChainSentenceGenerator sentenceGenerator = new ChainSentenceGenerator();
            sentenceGenerator.WordModels = new DataCollector().ParseDataFromFile(testFileName);

            string result = sentenceGenerator.GenerateSentence();

            foreach (string resultWord in result.Split(' '))
            {
                bool wordExistsInOriginalSentence = false;
                foreach (string word in testFileContent.Split(' '))
                {
                    if(resultWord == word)
                    {
                        wordExistsInOriginalSentence = true;
                        break;
                    }
                }
                if (!wordExistsInOriginalSentence)
                {
                    Assert.Fail("Word does not exist in original sentence: " + resultWord);
                }
            }
        }

        [TestMethod]
        public void GenerateSentenceTest_NoWordModelsProvided()
        {
            ChainSentenceGenerator sentenceGenerator = new ChainSentenceGenerator();
            Assert.AreEqual(null, sentenceGenerator.GenerateSentence());
        }
    }
}