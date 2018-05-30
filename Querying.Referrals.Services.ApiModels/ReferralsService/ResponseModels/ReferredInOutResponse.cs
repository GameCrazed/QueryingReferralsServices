namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class ReferredInOutResponse
    {
        public int ReferralId { get; set; }
        public int ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? SecondCustomerId { get; set; }
        public int? ProductEventId { get; set; }
    }
}
