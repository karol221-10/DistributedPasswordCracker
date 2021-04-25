using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.api
{
    interface StartupParameterResolver
    {
        List<String> getCrackServerAddresses();
        String getDictionaryFilename();
        String getFileToCrackFilename();
        int getBlockSize(); 
    }
}
