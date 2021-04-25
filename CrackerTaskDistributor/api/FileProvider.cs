using CrackerTaskDistributor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.api
{
    interface FileProvider
    {
        DictionaryModel readDictionary(String filename);
        Base64EncodedFile readFileToCrack(String filename);
    }
}
