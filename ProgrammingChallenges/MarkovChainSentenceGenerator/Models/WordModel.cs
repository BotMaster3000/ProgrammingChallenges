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
        public string Word { get; set; }
        public Dictionary<string, int> WordAndOccurance { get; set; } = new Dictionary<string, int>();
    }
}
