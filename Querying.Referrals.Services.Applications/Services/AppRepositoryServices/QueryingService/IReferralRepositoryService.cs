using System.Collections.Generic;
using System.Threading.Tasks;
using Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels;
using Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService
{
    public interface IReferralRepositoryService
    {
        List<Referral> GetAllReferralToList();
        Task<List<Referral>> GetAllReferralToListAsync();
        List<Referral> GetReferralsInToList(ReferralsInRequest referralsInRequest);
        Task<List<Referral>> GetReferralsInToListAsync(ReferralsInRequest referralsInRequest);
        Task<ReferralsReferralIdResponse> GetReferralsIdFromCustomerIdAndSourceCompanyIdAsync(ReferralsCustomerIdRequest referralsCustomerIdRequest);
        List<Referral> GetReferralsByReferralIdToList(int referralId);
        Task<List<Referral>> GetReferralsByReferralIdToListAsync(int referralId);
        List<Referral> GetReferralsByApCustomerIdToList(int apCustomerId);
        Task<List<Referral>> GetReferralsByApCustomerIdToListAsync(int apCustomerId);
        int? GetApCustomerIdFromAsCustomerId(int asCustomerId);
        Task<int?> GetApCustomerIdFromAsCustomerIdAsync(int asCustomerId);
        void AddOrUpdateReferrals(List<Referral> referralsToAddOrUpdate);
        Task AddOrUpdateReferralsAsync(List<Referral> referralsToAddOrUpdate);
        void RemoveReferrals(List<Referral> referralsToRemove);
        Task RemoveReferralsAsync(List<Referral> referralsToRemove);
    }
}