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
    public class AsReleaseRepositoryService : IAsReleaseRepositoryService
    {
        private readonly IApplicationsRepository _myIApplicationsRepository;
        private readonly IAutoMapperService _myIAutoMapperService;
        private readonly INLogService _myInLogService;

        #region "Constructor"
        public AsReleaseRepositoryService(IApplicationsRepository myIApplicationsRepository, INLogService myInLogService, IAutoMapperService myIAutoMapperService)
        {
            _myIApplicationsRepository = myIApplicationsRepository;
            _myIAutoMapperService = myIAutoMapperService;
            _myInLogService = myInLogService;
        }
        #endregion
        
        #region "Post"
        public List<AsCustomerHistory> GetReferralCustomerHistoryUsingAsCustomerId(int asCustomerId)
        {
            var myCustomerHistory = new List<AsCustomerHistory>();

            try
            {
                // Get results from AS database.
                myCustomerHistory = _myIApplicationsRepository.AsCustomerHistoryRepository.GetFilteredToList(x => x.customerID == asCustomerId);

                //Calculate the corresponding AP customerID
                var latestAsReferralId = _myIApplicationsRepository.ReferralsServiceRepository
                    .GetFilteredToIQuerable(x => x.CustomerId == asCustomerId).OrderByDescending(x => x.ReferralId)
                    .FirstOrDefault()?.ReferralId;

                var apCustomerId = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository
                    .GetFilteredToIQuerable(x => x.ReferralId == latestAsReferralId).FirstOrDefault()?.CustomerId;

                //Add APCustomerHistory to list and order.
                myCustomerHistory.AddRange(_myIApplicationsRepository.LegalCustomerHistoryRepository
                    .GetFilteredToList(x => x.customerID == apCustomerId).Select(apCustomerHistoryListItem =>
                        _myIAutoMapperService.MapAsCustomerHistory(apCustomerHistoryListItem)).ToList());
                myCustomerHistory = myCustomerHistory.OrderByDescending(x => x.logtime).ToList();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferralCustomerHistoryUsingAsCustomerId) + ": " + e.Message);
            }

            return myCustomerHistory;
        }

        public async Task<List<AsCustomerHistory>> GetReferralCustomerHistoryUsingAsCustomerIdAsync(int asCustomerId)
        {
            var myCustomerHistory = new List<AsCustomerHistory>();

            try
            {
                // Get results from AS database.
                myCustomerHistory = await _myIApplicationsRepository.AsCustomerHistoryRepository.GetFilteredToListAsync(x => x.customerID == asCustomerId);

                //Calculate the corresponding AP customerID
                var latestAsReferralId = _myIApplicationsRepository.ReferralsServiceRepository
                    .GetFilteredToIQuerable(x => x.CustomerId == asCustomerId).OrderByDescending(x => x.ReferralId)
                    .FirstOrDefault()?.ReferralId;

                var apCustomerId = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository
                    .GetFilteredToIQuerable(x => x.ReferralId == latestAsReferralId).FirstOrDefault()?.CustomerId;

                //Add APCustomerHistory to list and order.
                await Task.Run(() =>
                {
                    myCustomerHistory.AddRange(_myIApplicationsRepository.LegalCustomerHistoryRepository
                        .GetFilteredToList(x => x.customerID == apCustomerId).Select(apCustomerHistoryListItem =>
                            _myIAutoMapperService.MapAsCustomerHistory(apCustomerHistoryListItem)).ToList());

                    myCustomerHistory = myCustomerHistory.OrderByDescending(x => x.logtime).ToList();
                });

            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/LegalRepositoryService/" + nameof(GetReferralCustomerHistoryUsingAsCustomerIdAsync) + ": " + e.Message);
            }

            return myCustomerHistory;
        }
        #endregion
    }
}