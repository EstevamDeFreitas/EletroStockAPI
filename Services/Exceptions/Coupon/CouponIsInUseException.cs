using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Coupon
{
    [Serializable]
    public class CouponIsInUseException : Exception
    {
        public CouponIsInUseException() : base("Coupon cannot be deleted while being in use")
        {

        }
    }
}
