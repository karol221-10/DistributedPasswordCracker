using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.IServices
{
    public interface IWordProvider
    {
        string[] getWords(string startPointer, string endPointer);
    }
}
