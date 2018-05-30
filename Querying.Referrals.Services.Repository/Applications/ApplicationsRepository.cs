using System;
using Querying.Referrals.Services.Data.DataContexts;
using Querying.Referrals.Services.Repository.Applications.QueryingService;

namespace Querying.Referrals.Services.Repository.Applications
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private bool _disposed;

        public ReferralsRepository ReferralsServiceRepository { get; set; }
        public LegalReferredInOutCustomersRepository LegalReferredInOutCustomersLegalRepository { get; set; }
        public LegalCustomerHistoryRepository LegalCustomerHistoryRepository { get; set; }
        public AsCustomerHistoryRepository AsCustomerHistoryRepository { get; set; }

        #region "Constructor"
        public ApplicationsRepository()
        {
            SetAppReferralServiceRepos();
        }
        #endregion

        #region "Set the repos"
        private void SetAppReferralServiceRepos()
        {
            var localReferralServiceEntities = new ReferralsServiceEntities();
            var localLegalServiceEntities = new LegalEntities();
            var localAsServiceEntities = new AsReleaseEntities();

            ReferralsServiceRepository = new ReferralsRepository(localReferralServiceEntities);
            LegalReferredInOutCustomersLegalRepository = new LegalReferredInOutCustomersRepository(localLegalServiceEntities);
            LegalCustomerHistoryRepository = new LegalCustomerHistoryRepository(localLegalServiceEntities);
            AsCustomerHistoryRepository = new AsCustomerHistoryRepository(localAsServiceEntities);
        }
        #endregion

        #region "Dispose"
        /// <summary>
        /// Disposes the Context.
        /// </summary>
        /// <param name="disposing">bool</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeAppReferralServiceRepos();

                    // Dispose the rest of the repositories here.
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose any previously registered repositories.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all the  ReferralsService repos.
        /// </summary>
        private void DisposeAppReferralServiceRepos()
        {
            ReferralsServiceRepository.Dispose();
            LegalReferredInOutCustomersLegalRepository.Dispose();
            LegalCustomerHistoryRepository.Dispose();
            AsCustomerHistoryRepository.Dispose();
        }
        #endregion
    }
}
