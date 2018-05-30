namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralCompanyRequest
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public long? LastHistoryProcessedId { get; set; }
        public int? LastReferralProcessedId { get; set; }
        public int? LastStatusUpdateProcessedId { get; set; }
    }
}
