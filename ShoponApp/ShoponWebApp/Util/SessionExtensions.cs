using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Util
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Methos to get session value based on key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSession<T>(this ISession session,string key)
        {
            var data = session.GetString(key);       //get the session data
            return data == null ? default : JsonConvert.DeserializeObject<T>(data);  //convert it into T type
        }
        /// <summary>
        /// Method to set value based on key to session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSession<T>(this ISession session,string key,Object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
