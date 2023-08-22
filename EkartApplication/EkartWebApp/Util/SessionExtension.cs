using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkartWebApp.Util
{
    // in session we can not store object as it so that why we have to convert everthing to jason structure
    // we can store only a string value or int value in jason structure
    //and here we are trying to convert string value to jason structure and by using "SessionExtension" we are doing that
    //in SetSession we are seting tht data and in from getSession we are getting that data

    public static class SessionExtension
    {
        //this genric method
        public static void SetSession<T>(this ISession session, string Key, object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
