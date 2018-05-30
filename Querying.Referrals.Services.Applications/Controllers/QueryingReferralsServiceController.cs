using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService;
using Querying.Referrals.Services.Applications.Services.NLogServices;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Controllers
{
    public class QueryingReferralsServiceController : ApiController
    {
        #region "Members"
        private readonly IReferralRepositoryService _myIQueryingReferralRepositoryService;
        private readonly ILegalRepositoryService _myIQueryingLegalRepositoryService;
        private readonly IAsReleaseRepositoryService _myIAsReleaseRepositoryService;
        private readonly INLogService _myInLogService;
        #endregion

        #region "Constructor"
        public QueryingReferralsServiceController(IReferralRepositoryService myIQueryingReferralRepositoryService,
            ILegalRepositoryService myIQueryingLegalRepositoryService, IAsReleaseRepositoryService myIAsReleaseRepositoryService,
            INLogService myInLogService)
        {
            _myIQueryingReferralRepositoryService = myIQueryingReferralRepositoryService;
            _myIQueryingLegalRepositoryService = myIQueryingLegalRepositoryService;
            _myIAsReleaseRepositoryService = myIAsReleaseRepositoryService;
            _myInLogService = myInLogService;
        }
        #endregion

        #region "Referred In Out Customers"
        #region "Get"
        [HttpGet]
        public IHttpActionResult GetAllReferredInOutCustomersToList()
        {
            try
            {
                // Returns the list as json.
                return Json(_myIQueryingLegalRepositoryService.GetAllReferredInOutCustomersToList());
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAllReferredInOutCustomersToList) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllReferredInOutCustomersToListAsync()
        {
            try
            {
                // Returns the list as json.
                return Json(await _myIQueryingLegalRepositoryService.GetAllReferredInOutCustomersToListAsync());
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAllReferredInOutCustomersToListAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }
        #endregion

        #region "Post"
        [HttpPost]
        public IHttpActionResult GetAllReferredInOutCustomersByLegalCustomerIdToList([FromBody] LegalReferredInOutCustomer referredInOutCustomer)
        {
            try
            {
                // Get object list from db.
                return Json(_myIQueryingLegalRepositoryService.GetAllReferredInOutCustomersByLegalCustomerIdToList(referredInOutCustomer.CustomerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAllReferredInOutCustomersByLegalCustomerIdToList) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetAllReferredInOutCustomersByLegalCustomerIdToListAsync([FromBody] LegalReferredInOutCustomer referredInOutCustomer)
        {
            try
            {
                // Get object list from db.
                return Json(await _myIQueryingLegalRepositoryService.GetAllReferredInOutCustomersByLegalCustomerIdToListAsync(referredInOutCustomer.CustomerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAllReferredInOutCustomersByLegalCustomerIdToListAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public IHttpActionResult GetReferredInOutCustomersByAsCustomerIdToList([FromBody] int customerId)
        {
            try
            {
                // Get object list from db.
                return Json(_myIQueryingLegalRepositoryService.GetReferredInOutCustomersByAsCustomerIdToList(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferredInOutCustomersByAsCustomerIdToList) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReferredInOutCustomersByAsCustomerIdToListAsync([FromBody] int customerId)
        {
            try
            {
                // Get object list from db.
                return Json(await _myIQueryingLegalRepositoryService.GetReferredInOutCustomersByAsCustomerIdToListAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferredInOutCustomersByAsCustomerIdToListAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }
        #endregion
        #endregion

        #region "Referrals"
        #region "Post"
        [HttpPost]
        public IHttpActionResult GetReferralsByReferredInOutCustomerReferralIdToList([FromBody] LegalReferredInOutCustomer referral)
        {
            try
            {
                // Get object list from db.
                return Json(_myIQueryingReferralRepositoryService.GetReferralsByReferralIdToList(referral.ReferralId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralsByReferredInOutCustomerReferralIdToList) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReferralsByReferredInOutCustomerReferralIdToListAsync([FromBody] LegalReferredInOutCustomer referral)
        {
            try
            {
                // Get object list from db.
                return Json(await _myIQueryingReferralRepositoryService.GetReferralsByReferralIdToListAsync(referral.ReferralId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralsByReferredInOutCustomerReferralIdToListAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public IHttpActionResult GetReferralsByApCustomerIdToList([FromBody] int customerId)
        {
            try
            {
                // Get object list from db.
                return Json(_myIQueryingReferralRepositoryService.GetReferralsByApCustomerIdToList(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralsByApCustomerIdToList) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReferralsByApCustomerIdToListAsync([FromBody] int customerId)
        {
            try
            {
                // Get object list from db.
                return Json(await _myIQueryingReferralRepositoryService.GetReferralsByApCustomerIdToListAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralsByApCustomerIdToListAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public IHttpActionResult GetReferralCustomerHistoryUsingAsCustomerId([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(_myIAsReleaseRepositoryService.GetReferralCustomerHistoryUsingAsCustomerId(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralCustomerHistoryUsingAsCustomerId) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReferralCustomerHistoryUsingAsCustomerIdAsync([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(await _myIAsReleaseRepositoryService.GetReferralCustomerHistoryUsingAsCustomerIdAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralCustomerHistoryUsingAsCustomerIdAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public IHttpActionResult GetReferralCustomerHistoryUsingApCustomerId([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(_myIQueryingLegalRepositoryService.GetReferralCustomerHistoryUsingApCustomerId(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralCustomerHistoryUsingApCustomerId) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReferralCustomerHistoryUsingApCustomerIdAsync([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(await _myIQueryingLegalRepositoryService.GetReferralCustomerHistoryUsingApCustomerIdAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetReferralCustomerHistoryUsingApCustomerIdAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }
        #endregion
        #endregion

        #region "CustomerID Converters"
        #region "Post"
        [HttpPost]
        public IHttpActionResult GetApCustomerIdFromAsCustomerId([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(_myIQueryingReferralRepositoryService.GetApCustomerIdFromAsCustomerId(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetApCustomerIdFromAsCustomerId) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetApCustomerIdFromAsCustomerIdAsync([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(await _myIQueryingReferralRepositoryService.GetApCustomerIdFromAsCustomerIdAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetApCustomerIdFromAsCustomerIdAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public IHttpActionResult GetAsCustomerIdFromApCustomerId([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(_myIQueryingLegalRepositoryService.GetAsCustomerIdFromApCustomerId(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAsCustomerIdFromApCustomerId) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetAsCustomerIdFromApCustomerIdAsync([FromBody] int customerId)
        {
            try
            {
                // Get object from db.
                return Json(await _myIQueryingLegalRepositoryService.GetAsCustomerIdFromApCustomerIdAsync(customerId));

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Controllers/QueryingReferralsServiceController/" + nameof(GetAsCustomerIdFromApCustomerIdAsync) + ": " + e.Message);

                return Content(HttpStatusCode.InternalServerError, "Error");
            }
        }
        #endregion
        #endregion
    }
}