using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Querying.Referrals.Services.Applications.Controllers
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage Response(HttpStatusCode status)
        {
            return Request.CreateResponse(status);
        }

        protected HttpResponseMessage Response<T>(HttpStatusCode status, T content)
        {
            return Request.CreateResponse(status, content);
        }
    }
}