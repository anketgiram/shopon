using System;

namespace EkartCommon.CustomExceptions
{
    public class InvaliedOrderException : ApplicationException
    {
        public InvaliedOrderException()
        {

        }

        public InvaliedOrderException(string errorMsg)
            : base(errorMsg)
        {

        }

        public InvaliedOrderException(string errorMsg, Exception innerexception)
            : base(errorMsg, innerexception)
        {

        }
    }
}
