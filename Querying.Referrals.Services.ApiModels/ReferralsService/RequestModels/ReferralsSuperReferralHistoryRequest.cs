using System.Collections.Generic;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralsSuperReferralHistoryRequest
    {
        public List<ReferralHistoryRequest> ReferralHistoryRequestList { get; set; }
        public ReferralsSupportDataRequest ReferralsSupportData { get; set; }

    }
}
