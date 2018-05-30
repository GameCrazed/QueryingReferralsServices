using Querying.Referrals.Services.Data.DataContexts;
using Querying.Referrals.Services.Repository.Base;

namespace Querying.Referrals.Services.Repository.Applications.QueryingService
{
    public class ReferralsRepository : Repository<ReferralsServiceEntities, Referral>
    {
        /// <inheritdoc />
        /// <summary>
        /// ReferralRepository constructor. The context gets its connection string from the .config file.
        /// </summary>
        /// <param name="context"></param>
        public ReferralsRepository(ReferralsServiceEntities context) : base(context)
        {
        }
    }
}
