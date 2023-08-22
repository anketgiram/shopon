using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.CustomExceptions
{
    public class CompanyNotFoundException:ApplicationException
    {
        public CompanyNotFoundException()
        {

        }
        public CompanyNotFoundException(string errorMsg)
            :base(errorMsg)
        {

        }
        public CompanyNotFoundException(string errorMsg,Exception innerException)
            :base(errorMsg,innerException)
        {

        }
    }
}
