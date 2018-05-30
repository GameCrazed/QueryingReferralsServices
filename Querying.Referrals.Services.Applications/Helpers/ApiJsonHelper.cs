using System;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace Querying.Referrals.Services.Applications.Helpers
{
    public class ApiJsonHelper : IApiJsonHelper
    {
        /// <summary>
        /// Method returns the HttpRequestBase's body.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        public string GetHttpRequestBaseBody(HttpRequestBase request)
        {
            try
            {
                var req = request.InputStream;
                req.Seek(0, SeekOrigin.Begin);
                return new StreamReader(req).ReadToEnd();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Helpers/GetHttpRequestBaseBody", e);
            }
        }

        /// <summary>
        /// Method returns the T object deserializing the HttpRequestBase's body.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="request">HttpRequestBase</param>
        /// <returns>T</returns>
        public T GetDeserializedObject<T>(HttpRequestBase request) where T : class
        {
            try
            {
                var js = new JavaScriptSerializer();
                return js.Deserialize<T>(GetHttpRequestBaseBody(request));
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Helpers/GetDeserializedObject", e);
            }
        }

        /// <summary>
        /// Method returns the string serializing the request.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="request">T</param>
        /// <returns>string</returns>
        public string GetSeserializedObject<T>(T request) where T : class
        {
            try
            {
                var js = new JavaScriptSerializer();
                return js.Serialize(request);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Helpers/GetDeserializedObject", e);
            }
        }
    }
}