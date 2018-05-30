namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class StatusUpdateResponse
    {
        public int StatusUpdateId { get; set; }
        public int CustomerId { get; set; }
        public int SourceCompanyId { get; set; }
        public string NewStatus { get; set; }
        public string NewSubStatus { get; set; }
        public System.DateTime StatusUpdateCreated { get; set; }
        public bool? IsProcessed { get; set; }
        public string Reason { get; set; }
    }
}
