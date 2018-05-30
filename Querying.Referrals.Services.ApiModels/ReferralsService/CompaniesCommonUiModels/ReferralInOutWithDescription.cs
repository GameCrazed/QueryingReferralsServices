namespace Querying.Referrals.Services.ApiModels.ReferralsService.CompaniesCommonUiModels
{
    public class ReferralInOutWithDescription
    {
        public int ReferredInOutId { get; set; }
        public int ReferralId { get; set; }
        public int ProductId { get; set; }
        public string ProductCategoryDescr { get; set; }
        public string ProductName { get; set; }
        public bool InOut { get; set; }
    }
}
