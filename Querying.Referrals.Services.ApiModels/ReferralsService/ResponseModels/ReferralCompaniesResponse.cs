namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class ReferralCompaniesResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public long? LastHistoryProcessedId { get; set; }
        public int? LastReferralProcessedId { get; set; }
        public int? LastStatusUpdateProcessedId { get; set; }
    }
}
