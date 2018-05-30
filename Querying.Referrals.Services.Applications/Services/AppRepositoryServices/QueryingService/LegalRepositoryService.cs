using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Querying.Referrals.Services.Applications.Services.AutoMapperServices;
using Querying.Referrals.Services.Applications.Services.NLogServices;
using Querying.Referrals.Services.Data.DataContexts;
using Querying.Referrals.Services.Repository.Applications;

namespace Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService
{
    public class LegalRepositoryService : ILegalRepositoryService
    {
        private readonly IApplicationsRepository _myIApplicationsRepository;
        private readonly IAutoMapperService _myIAutoMapperService;
        private readonly INLogService _myInLogService;

        #region "Constructor"
        public LegalRepositoryService(IApplicationsRepository myIApplicationsRepository, INLogService myInLogService, IAutoMapperService myIAutoMapperService)
        {
            _myIApplicationsRepository = myIApplicationsRepository;
            _myIAutoMapperService = myIAutoMapperService;
            _myInLogService = myInLogService;
        }
        #endregion

        #region "Get"
        public List<LegalReferredInOutCustomer> GetAllReferredInOutCustomersToList()
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                // Get the object from the db.
                myReferredInOutList = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetAllToList();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetAllReferredInOutCustomersToList) + ": " + e.Message);
            }

            return myReferredInOutList;
        }

        public async Task<List<LegalReferredInOutCustomer>> GetAllReferredInOutCustomersToListAsync()
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                // Get the object from the db.
                myReferredInOutList = await _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetAllToListAsync();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetAllReferredInOutCustomersToListAsync) + ": " + e.Message);
            }

            return myReferredInOutList;
        }
        #endregion

        #region "Post"
        public List<LegalReferredInOutCustomer> GetAllReferredInOutCustomersByLegalCustomerIdToList(int customerId)
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                // Get the object from the db.
                myReferredInOutList = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToList(x => x.CustomerId == customerId);
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetAllReferredInOutCustomersByLegalCustomerIdToList) + ": " + e.Message);
            }

            return myReferredInOutList;
        }

        public async Task<List<LegalReferredInOutCustomer>> GetAllReferredInOutCustomersByLegalCustomerIdToListAsync(int customerId)
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                // Get the object from the db.
                myReferredInOutList = await _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToListAsync(x => x.CustomerId == customerId);
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetAllReferredInOutCustomersByLegalCustomerIdToListAsync) + ": " + e.Message);
            }

            return myReferredInOutList;
        }

        public List<LegalReferredInOutCustomer> GetReferredInOutCustomersByAsCustomerIdToList(int asCustomerId)
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                var myReferralIds = _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToList(x => x.CustomerId == asCustomerId).Select(x => x.ReferralId);
                // Get the object from the db.
                myReferredInOutList = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToList(x => myReferralIds.Contains(x.ReferralId));
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferredInOutCustomersByAsCustomerIdToList) + ": " + e.Message);
            }

            return myReferredInOutList;
        }

        public async Task<List<LegalReferredInOutCustomer>> GetReferredInOutCustomersByAsCustomerIdToListAsync(int asCustomerId)
        {
            var myReferredInOutList = new List<LegalReferredInOutCustomer>();

            try
            {
                var myReferralIds = Task.Run(() => _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToListAsync(x => x.CustomerId == asCustomerId)).Result.Select(x => x.ReferralId);
                // Get the object from the db.
                myReferredInOutList = await _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToListAsync(x => myReferralIds.Contains(x.ReferralId));
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferredInOutCustomersByAsCustomerIdToListAsync) + ": " + e.Message);
            }

            return myReferredInOutList;
        }

        public int? GetAsCustomerIdFromApCustomerId(int apCustomerId)
        {
            int? myAsCustomerId = null;

            try
            {
                var apReferral = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToIQuerable(x => x.CustomerId == apCustomerId).OrderByDescending(x => x.ReferralId).FirstOrDefault();
                // Get the object from the db.
                myAsCustomerId = _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToIQuerable(x => x.ReferralId == apReferral.ReferralId).FirstOrDefault()?.CustomerId;
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetAsCustomerIdFromApCustomerId) + ": " + e.Message);
            }

            return myAsCustomerId;
        }

        public async Task<int?> GetAsCustomerIdFromApCustomerIdAsync(int apCustomerId)
        {
            int? myAsCustomerId = null;

            try
            {
                var apReferral = Task.Run(() => _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToIQuerable(x => x.CustomerId == apCustomerId).OrderByDescending(x => x.ReferralId).FirstOrDefault());
                // Get the object from the db.
                var tmyApCustomerId = await _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToListAsync(x => x.ReferralId == apReferral.Result.ReferralId);
                myAsCustomerId = tmyApCustomerId.FirstOrDefault()?.CustomerId;
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetAsCustomerIdFromApCustomerIdAsync) + ": " + e.Message);
            }

            return myAsCustomerId;
        }

        public List<LegalCustomerHistory> GetReferralCustomerHistoryUsingApCustomerId(int apCustomerId)
        {
            var myCustomerHistory = new List<LegalCustomerHistory>();

            try
            {
                // Get results from AS database.
                myCustomerHistory = _myIApplicationsRepository.LegalCustomerHistoryRepository.GetFilteredToList(x => x.customerID == apCustomerId);

                //Calculate the corresponding AP customerID
                var latestLegalReferralId = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository
                    .GetFilteredToIQuerable(x => x.CustomerId == apCustomerId).OrderByDescending(x => x.ReferralId)
                    .FirstOrDefault()?.ReferralId;

                var asCustomerId = _myIApplicationsRepository.ReferralsServiceRepository
                    .GetFilteredToIQuerable(x => x.ReferralId == latestLegalReferralId).FirstOrDefault()?.CustomerId;

                //Add APCustomerHistory to list and order.
                myCustomerHistory.AddRange(_myIApplicationsRepository.AsCustomerHistoryRepository
                    .GetFilteredToList(x => x.customerID == asCustomerId).Select(asCustomerHistoryListItem =>
                        _myIAutoMapperService.MapLegalCustomerHistory(asCustomerHistoryListItem)).ToList());
                myCustomerHistory = myCustomerHistory.OrderByDescending(x => x.logtime).ToList();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferralCustomerHistoryUsingApCustomerId) + ": " + e.Message);
            }

            return myCustomerHistory;
        }

        public async Task<List<LegalCustomerHistory>> GetReferralCustomerHistoryUsingApCustomerIdAsync(int apCustomerId)
        {
            var myCustomerHistory = new List<LegalCustomerHistory>();

            try
            {
                // Get results from AS database.
                myCustomerHistory = await _myIApplicationsRepository.LegalCustomerHistoryRepository.GetFilteredToListAsync(x => x.customerID == apCustomerId);

                //Calculate the corresponding AP customerID
                var latestLegalReferralId = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository
                    .GetFilteredToIQuerable(x => x.CustomerId == apCustomerId).OrderByDescending(x => x.ReferralId)
                    .FirstOrDefault()?.ReferralId;

                var asCustomerId = _myIApplicationsRepository.ReferralsServiceRepository
                    .GetFilteredToIQuerable(x => x.ReferralId == latestLegalReferralId).FirstOrDefault()?.CustomerId;

                //Add APCustomerHistory to list and order.
                await Task.Run(() =>
                    {
                        myCustomerHistory.AddRange(_myIApplicationsRepository.AsCustomerHistoryRepository
                        .GetFilteredToList(x => x.customerID == asCustomerId).Select(asCustomerHistoryListItem =>
                            _myIAutoMapperService.MapLegalCustomerHistory(asCustomerHistoryListItem)).ToList());
                        myCustomerHistory = myCustomerHistory.OrderByDescending(x => x.logtime).ToList();
                    });
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferralCustomerHistoryUsingApCustomerIdAsync) + ": " + e.Message);
            }

            return myCustomerHistory;
        }
        #endregion
    }
}