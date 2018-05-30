using System.Web;

namespace Querying.Referrals.Services.Applications.Helpers
{
    public interface IApiJsonHelper
    {
        /// <summary>
        /// Method returns the HttpRequestBase's body.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        string GetHttpRequestBaseBody(HttpRequestBase request);

        /// <summary>
        /// Method returns the T object deserializing the HttpRequestBase's body.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="request">HttpRequestBase</param>
        /// <returns>T</returns>
        T GetDeserializedObject<T>(HttpRequestBase request) where T : class;

        /// <summary>
        /// Method returns the string serializing the request.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="request">T</param>
        /// <returns>string</returns>
        string GetSeserializedObject<T>(T request) where T : class;
    }
}