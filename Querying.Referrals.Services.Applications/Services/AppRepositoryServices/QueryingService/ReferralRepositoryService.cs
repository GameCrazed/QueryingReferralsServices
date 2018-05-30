using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels;
using Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels;
using Querying.Referrals.Services.Applications.Services.NLogServices;
using Querying.Referrals.Services.Data.DataContexts;
using Querying.Referrals.Services.Repository.Applications;

namespace Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService
{
    public class ReferralRepositoryService : IReferralRepositoryService
    {
        private readonly IApplicationsRepository _myIApplicationsRepository;
        private readonly INLogService _myInLogService;

        #region "Constructor"
        public ReferralRepositoryService(IApplicationsRepository myIApplicationsRepository, INLogService myInLogService)
        {
            _myIApplicationsRepository = myIApplicationsRepository;
            _myInLogService = myInLogService;
        }
        #endregion
        
        #region "Get"
        public List<Referral> GetAllReferralToList()
        {
            var myReferralList = new List<Referral>();

            try
            {
                // Get the object from the db.
                myReferralList = _myIApplicationsRepository.ReferralsServiceRepository.GetAllToList();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetAllReferralToList) + ": " + e.Message);
            }

            return myReferralList;
        }

        public async Task<List<Referral>> GetAllReferralToListAsync()
        {
            var myReferralList = new List<Referral>();

            try
            {
                // Get the object from the db.
                myReferralList = await _myIApplicationsRepository.ReferralsServiceRepository.GetAllToListAsync();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetAllReferralToListAsync) + ": " + e.Message);
            }

            return myReferralList;
        }

        public List<Referral> GetReferralsInToList(ReferralsInRequest referralsInRequest)
        {
            var myReferralList = new List<Referral>();

            try
            {
                var arrIds = referralsInRequest.ProductIds.Split(',').Select(int.Parse).ToArray();

                // Get the object from the db.
                myReferralList = _myIApplicationsRepository.ReferralsServiceRepository.GetAllToIQuerable().Where(x => x.ReferralId > referralsInRequest.MaxReferralId && arrIds.Contains(x.ProductId)).ToList();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsInToList) + ": " + e.Message);
            }

            return myReferralList;
        }

        public async Task<List<Referral>> GetReferralsInToListAsync(ReferralsInRequest referralsInRequest)
        {
            var myReferralList = new List<Referral>();

            try
            {
                var arrIds = referralsInRequest.ProductIds.Split(',').Select(int.Parse).ToArray();

                // Get the object from the db.
                myReferralList = await _myIApplicationsRepository.ReferralsServiceRepository.GetAllToIQuerable().Where(x => x.ReferralId > referralsInRequest.MaxReferralId && arrIds.Contains(x.ProductId)).ToListAsync();
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsInToListAsync) + ": " + e.Message);
            }

            return myReferralList;
        }

        public async Task<ReferralsReferralIdResponse> GetReferralsIdFromCustomerIdAndSourceCompanyIdAsync(ReferralsCustomerIdRequest referralsCustomerIdRequest)
        {
            var myReferralsReferralIdResponse = new ReferralsReferralIdResponse();

            try
            {
                // Get the object from the db.
                var myReferral = await _myIApplicationsRepository.ReferralsServiceRepository.GetAllToIQuerable().Where(x => x.CustomerId == referralsCustomerIdRequest.CustomerId && x.SourceCompanyId == referralsCustomerIdRequest.SourceCompanyId).FirstOrDefaultAsync();

                if (myReferral != null)
                    myReferralsReferralIdResponse.ReferralId = myReferral.ReferralId;
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsIdFromCustomerIdAndSourceCompanyIdAsync) + ": " + e.Message);
            }

            return myReferralsReferralIdResponse;
        }

        public List<Referral> GetReferralsByReferralIdToList(int referralId)
        {
            var myReferralsList = new List<Referral>();

            try
            {
                // Get the object from the db.
                myReferralsList = _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToList(x => x.ReferralId == referralId);
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsByReferralIdToList) + ": " + e.Message);
            }

            return myReferralsList;
        }

        public async Task<List<Referral>> GetReferralsByReferralIdToListAsync(int referralId)
        {
            var myReferralsList = new List<Referral>();

            try
            {
                // Get the object from the db.
                myReferralsList = await _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToListAsync(x => x.ReferralId == referralId);
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsByReferralIdToListAsync) + ": " + e.Message);
            }

            return myReferralsList;
        }

        public List<Referral> GetReferralsByApCustomerIdToList(int apCustomerId)
        {
            var myReferralsList = new List<Referral>();

            try
            {
                var myReferredInOutList = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToList(x => x.CustomerId == apCustomerId);
                // Get the object from the db.
                var referralIds = myReferredInOutList.Select(x => x.ReferralId);
                myReferralsList = _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToList(x => referralIds.Contains(x.ReferralId));
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsByApCustomerIdToList) + ": " + e.Message);
            }

            return myReferralsList;
        }

        public async Task<List<Referral>> GetReferralsByApCustomerIdToListAsync(int apCustomerId)
        {
            var myReferralsList = new List<Referral>();

            try
            {
                var myReferralIds = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToList(x => x.CustomerId == apCustomerId).Select(x => x.ReferralId);
                // Get the object from the db.
                myReferralsList = await _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToListAsync(x => myReferralIds.Contains(x.ReferralId));
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsByApCustomerIdToListAsync) + ": " + e.Message);
            }

            return myReferralsList;
        }

        public int? GetApCustomerIdFromAsCustomerId(int asCustomerId)
        {
            int? myApCustomerId = null;

            try
            {
                var asReferral = _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToIQuerable(x => x.CustomerId == asCustomerId).OrderByDescending(x => x.ReferralId).FirstOrDefault();
                // Get the object from the db.
                myApCustomerId = _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToIQuerable(x => x.ReferralId == asReferral.ReferralId).FirstOrDefault()?.CustomerId;
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetReferralsByApCustomerIdToList) + ": " + e.Message);
            }

            return myApCustomerId;
        }

        public async Task<int?> GetApCustomerIdFromAsCustomerIdAsync(int asCustomerId)
        {
            int? myApCustomerId = null;

            try
            {
                var asReferral = Task.Run(() => _myIApplicationsRepository.ReferralsServiceRepository.GetFilteredToIQuerable(x => x.CustomerId == asCustomerId).OrderByDescending(x => x.ReferralId).FirstOrDefault());
                // Get the object from the db.
                var tmyApCustomerId = await _myIApplicationsRepository.LegalReferredInOutCustomersLegalRepository.GetFilteredToListAsync(x => x.ReferralId == asReferral.Result.ReferralId);
                myApCustomerId = tmyApCustomerId.FirstOrDefault()?.CustomerId;
            }
            catch (Exception e)
            {
                _myInLogService.LogError(e, "Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(GetApCustomerIdFromAsCustomerIdAsync) + ": " + e.Message);
            }

            return myApCustomerId;
        }
        #endregion

        #region "Add or Update"
        public void AddOrUpdateReferrals(List<Referral> referralsToAddOrUpdate)
        {
            try
            {
                // Add of Update referrals from entity.
                _myIApplicationsRepository.ReferralsServiceRepository.AddOrUpdateRange(referralsToAddOrUpdate);

                // Update the db.
                _myIApplicationsRepository.ReferralsServiceRepository.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(AddOrUpdateReferrals) + ": ", e);
            }
        }

        public async Task AddOrUpdateReferralsAsync(List<Referral> referralsToAddOrUpdate)
        {
            try
            {
                // Add of Update referrals from entity.
                _myIApplicationsRepository.ReferralsServiceRepository.AddOrUpdateRange(referralsToAddOrUpdate);

                // Update the db.
                await _myIApplicationsRepository.ReferralsServiceRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(AddOrUpdateReferralsAsync) + ": ", e);
            }
        }
        #endregion

        #region "Remove"
        public void RemoveReferrals(List<Referral> referralsToRemove)
        {
            try
            {
                // Remove referrals from entity.
                _myIApplicationsRepository.ReferralsServiceRepository.RemoveRange(referralsToRemove);

                // Update the db.
                _myIApplicationsRepository.ReferralsServiceRepository.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(RemoveReferrals) + ": ", e);
            }
        }

        public async Task RemoveReferralsAsync(List<Referral> referralsToRemove)
        {
            try
            {
                // Remove referrals from entity.
                _myIApplicationsRepository.ReferralsServiceRepository.RemoveRange(referralsToRemove);

                // Update the db.
                await _myIApplicationsRepository.ReferralsServiceRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AppRepositoryServices.ReferralsService/ReferralRepositoryService/" + nameof(RemoveReferralsAsync) + ": ", e);
            }
        }
        #endregion
    }
}