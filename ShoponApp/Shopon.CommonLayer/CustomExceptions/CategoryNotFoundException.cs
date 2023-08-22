using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.CustomExceptions
{
    public class CategoryNotFoundException:ApplicationException
    {
        public CategoryNotFoundException()
        {

        }
        public CategoryNotFoundException(string errorMsg)
            :base(errorMsg)
        {

        }
        public CategoryNotFoundException(string errorMsg,Exception innerException)
            :base(errorMsg,innerException)
        {

        }
    }
}
