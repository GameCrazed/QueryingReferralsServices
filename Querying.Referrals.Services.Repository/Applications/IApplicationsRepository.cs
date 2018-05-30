using Querying.Referrals.Services.Repository.Applications.QueryingService;

namespace Querying.Referrals.Services.Repository.Applications
{
    public interface IApplicationsRepository
    {
        ReferralsRepository ReferralsServiceRepository { get; set; }
        LegalReferredInOutCustomersRepository LegalReferredInOutCustomersLegalRepository { get; set; }
        LegalCustomerHistoryRepository LegalCustomerHistoryRepository { get; set; }
        AsCustomerHistoryRepository AsCustomerHistoryRepository { get; set; }

        /// <summary>
        /// Dispose any previously registered repositories.
        /// </summary>
        void Dispose();
    }
}