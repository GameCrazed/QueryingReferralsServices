using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralHistoryRequest
    {
        public long ReferralHistoryId { get; set; }
        public int ReferralId { get; set; }
        public string ReferralHistoryTitle { get; set; }
        public string ReferralHistoryBody { get; set; }
        public DateTime ReferralHistoryCreated { get; set; }
        public int? ProductEventId { get; set; }
        public bool? IsProcessed { get; set; }
    }
}
