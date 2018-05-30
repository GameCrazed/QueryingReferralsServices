using System.Web.Http;
using Querying.Referrals.Services.Applications.Helpers;

namespace Querying.Referrals.Services.Applications
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ModelValidationErrorHandlerFilterAttribute());
        }
    }
}
