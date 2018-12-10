using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChainSentenceGenerator.Interfaces
{
    public interface IChainSentenceGenerator
    {
        IWordModel[] WordModels { get; set; }
        string GenerateSentence();
    }
}
