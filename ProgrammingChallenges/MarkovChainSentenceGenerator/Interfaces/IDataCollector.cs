﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChainSentenceGenerator.Interfaces
{
    public interface IDataCollector
    {
        IWordModel[] ParseDataFromFile(string fileName);
    }
}
