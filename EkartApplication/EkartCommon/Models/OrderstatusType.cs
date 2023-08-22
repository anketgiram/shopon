using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkartCommon.Models
{
    //we want value directly in method that we use enum 
    public enum OrderstatusType
    {
            ORDERECEVIED = 1001,
            ORDERPICED = 1002,
            ORDERSHIPPED = 1003,
            ORDEROUTFORDELIVERY = 1004,
           ORDERDELIVERD = 1005
    }
}
