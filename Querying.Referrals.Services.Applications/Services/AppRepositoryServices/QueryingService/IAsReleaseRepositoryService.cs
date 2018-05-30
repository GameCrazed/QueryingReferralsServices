using System.Collections.Generic;
using System.Threading.Tasks;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService
{
    public interface IAsReleaseRepositoryService
    {
        List<AsCustomerHistory> GetReferralCustomerHistoryUsingAsCustomerId(int asCustomerId);
        Task<List<AsCustomerHistory>> GetReferralCustomerHistoryUsingAsCustomerIdAsync(int asCustomerId);
    }
}