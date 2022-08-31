using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Address
{
    [Serializable]
    public class AddressIsSetAsDefault : Exception
    {
        public AddressIsSetAsDefault() : base("Address is set as default for delivery and/or charge, please change the default address and try again.") { }
    }
}
