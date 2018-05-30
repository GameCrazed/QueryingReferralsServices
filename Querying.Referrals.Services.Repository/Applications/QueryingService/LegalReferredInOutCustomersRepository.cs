using Querying.Referrals.Services.Data.DataContexts;
using Querying.Referrals.Services.Repository.Base;

namespace Querying.Referrals.Services.Repository.Applications.QueryingService
{
    public class LegalReferredInOutCustomersRepository : Repository<LegalEntities, LegalReferredInOutCustomer>
    {
        /// <inheritdoc />
        /// <summary>
        /// ProductEventsRepository constructor. The context gets its connection string from the .config file.
        /// </summary>
        /// <param name="context"></param>
        public LegalReferredInOutCustomersRepository(LegalEntities context) : base(context)
        {
        }
    }
}
