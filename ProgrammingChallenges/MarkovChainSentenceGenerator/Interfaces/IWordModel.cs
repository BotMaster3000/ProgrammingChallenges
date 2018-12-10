using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChainSentenceGenerator.Interfaces
{
    public interface IWordModel
    {
        string Word { get; set; }
        Dictionary<string, int> WordAndOccurance { get; set; }
    }
}
