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
        public IWordModel[] WordModels { get; set; }

        public string GenerateSentence()
        {
            return "";
        }
    }
}
