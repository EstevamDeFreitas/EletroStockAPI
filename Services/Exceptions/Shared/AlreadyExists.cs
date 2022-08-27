using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Shared
{
    [Serializable]
    public class AlreadyExists : Exception
    {
        public AlreadyExists(string entityName, string value) : base($"Value: {value}, already exists for entity {entityName}.") {}
    }
}
