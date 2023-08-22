using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.CustomExceptions
{
    public class InvalidPriceException:ApplicationException
    {
        public InvalidPriceException()
        {

        }
        public InvalidPriceException(string errorMsg)
            :base(errorMsg)
        {

        }
        public InvalidPriceException(string errorMsg,Exception innerException)
            :base(errorMsg,innerException)
        {

        }
    }
}
