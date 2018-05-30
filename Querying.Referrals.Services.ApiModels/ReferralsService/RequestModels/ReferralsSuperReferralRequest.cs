using System.Collections.Generic;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralsSuperReferralRequest
    {
        public List<ReferralsReferralRequest> ReferralsReferralRequestList { get; set; }
        public ReferralsSupportDataRequest ReferralsSupportData { get; set; }
    }
}
