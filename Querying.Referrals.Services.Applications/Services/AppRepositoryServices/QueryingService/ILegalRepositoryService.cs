using System.Collections.Generic;
using System.Threading.Tasks;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService
{
    public interface ILegalRepositoryService
    {
        List<LegalReferredInOutCustomer> GetAllReferredInOutCustomersToList();
        Task<List<LegalReferredInOutCustomer>> GetAllReferredInOutCustomersToListAsync();
        List<LegalReferredInOutCustomer> GetAllReferredInOutCustomersByLegalCustomerIdToList(int customerId);
        Task<List<LegalReferredInOutCustomer>> GetAllReferredInOutCustomersByLegalCustomerIdToListAsync(int customerId);
        List<LegalReferredInOutCustomer> GetReferredInOutCustomersByAsCustomerIdToList(int asCustomerId);
        Task<List<LegalReferredInOutCustomer>> GetReferredInOutCustomersByAsCustomerIdToListAsync(int asCustomerId);
        int? GetAsCustomerIdFromApCustomerId(int apCustomerId);
        Task<int?> GetAsCustomerIdFromApCustomerIdAsync(int apCustomerId);
        List<LegalCustomerHistory> GetReferralCustomerHistoryUsingApCustomerId(int apCustomerId);
        Task<List<LegalCustomerHistory>> GetReferralCustomerHistoryUsingApCustomerIdAsync(int apCustomerId);
    }
}