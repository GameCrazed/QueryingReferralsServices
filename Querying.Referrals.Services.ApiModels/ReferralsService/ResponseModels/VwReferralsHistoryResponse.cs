using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class VwReferralsHistoryResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public short ProductCategoryId { get; set; }
        public string ProductCategoryDescr { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ReferralId { get; set; }
        public int? CustomerId { get; set; }
        public int? SecondCustomerId { get; set; }
        public int? SourceCompanyId { get; set; }
        public long ReferralHistoryId { get; set; }
        public string ReferralHistoryTitle { get; set; }
        public string ReferralHistoryBody { get; set; }
        public DateTime ReferralHistoryCreated { get; set; }
        public int? ProductEventId { get; set; }
        public bool? IsProcessed { get; set; }
    }
}
