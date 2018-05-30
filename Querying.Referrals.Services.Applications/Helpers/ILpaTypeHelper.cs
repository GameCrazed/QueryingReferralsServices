using System.Collections.Generic;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Helpers
{
    public interface ILpaTypeHelper
    {
        int? GetLegalLpaTypeFromReferralsRequest(List<Referral> referralsToAddOrUpdate);
    }
}