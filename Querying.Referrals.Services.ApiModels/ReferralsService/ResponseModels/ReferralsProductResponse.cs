using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    /// <summary>
    /// The ReferralsProduct. Related table the Product table in the ReferralsService database.
    /// </summary>
    public class ReferralsProductResponse
    {
        public int ProductId { get; set; }
        public short? ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime? ProductCreated { get; set; }
    }
}
