using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Shared
{
    [Serializable]
    public class NotFound : Exception
    {
        public NotFound(string entityName) : base($"{entityName} not found.") { }
    }
}
