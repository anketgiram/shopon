using ShoponCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Contracts
{
    public interface IOrderManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Order AddOrder(Order order);
    }
}
