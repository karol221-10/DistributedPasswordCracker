using CrackServer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class ObjectToCrackProvider
    {
        private Dictionary<string, ObjectToCrackDefinition> objectToCrackDictionary = new Dictionary<string, ObjectToCrackDefinition>();

        public ObjectToCrackDefinition getObject(String objectName)
        {
            return objectToCrackDictionary.GetValueOrDefault(objectName, null);
        }

        public void addObject(ObjectToCrackDefinition objectToAdd)
        {
            objectToCrackDictionary.Add(objectToAdd.objectName, objectToAdd);
            Console.WriteLine("Dodano obiekt do crackowania typu: {0} o nazwie {1} i zawartości {2}", objectToAdd.type, objectToAdd.objectName, objectToAdd.objectContent);
        }
    }
}
