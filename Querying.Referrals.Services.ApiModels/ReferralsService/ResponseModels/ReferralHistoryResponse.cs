using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class ReferralHistoryResponse
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
