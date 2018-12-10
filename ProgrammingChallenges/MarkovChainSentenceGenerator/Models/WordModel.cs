using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkovChainSentenceGenerator.Interfaces;

namespace MarkovChainSentenceGenerator.Models
{
    public class WordModel : IWordModel
    {
        public string Word { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, int> WordAndOccurance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
