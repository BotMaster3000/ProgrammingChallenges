using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChainSentenceGenerator.Interfaces
{
    public interface IChainSentenceGenerator
    {
        Random rand { get; set; }
        IWordModel[] WordModels { get; set; }
        string GenerateSentence();
    }
}
