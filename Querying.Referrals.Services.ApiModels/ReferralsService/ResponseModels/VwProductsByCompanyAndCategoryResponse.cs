namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class VwProductsByCompanyAndCategoryResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public short ProductCategoryId { get; set; }
        public string ProductCategoryDescr { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
