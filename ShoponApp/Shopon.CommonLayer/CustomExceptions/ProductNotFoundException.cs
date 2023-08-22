using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.CustomExceptions
{
    public class ProductNotFoundException:ApplicationException
    {
        public ProductNotFoundException()
        {

        }
        public ProductNotFoundException(string errMessage)
            :base(errMessage)
        {

        }
        public ProductNotFoundException(string errMessage,Exception innerException)
            :base(errMessage,innerException)
        {

        }
    }
}
