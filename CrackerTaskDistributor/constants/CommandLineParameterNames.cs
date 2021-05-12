using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.constants
{
    class CommandLineParameterNames
    {
        public static readonly string SERVER_LIST_PARAMETER = "--serversFile";
        public static readonly string DICTIONARY_FILE_PARAMETER = "--dictionaryFile";
        public static readonly string OBJECT_TO_CRACK_NAME_PARAMETER = "--objectToCrackName";
        public static readonly string OBJECT_TO_CRACK_CONTENT_PARAMETER = "--objectToCrackContent";
        public static readonly string OBJECT_TO_CRACK_TYPE_PARAMETER = "--objectToCrackType";
        public static readonly string OBJECT_TO_CRACK_METHOD_PARAMETER = "--objectToCrackMethod";
        public static readonly string BLOCK_SIZE_PARAMETER = "--blockSize";
    }
}
