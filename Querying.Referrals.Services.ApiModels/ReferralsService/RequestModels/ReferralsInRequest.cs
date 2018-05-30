using System.ComponentModel.DataAnnotations;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralsInRequest
    {
        [Required]
        public int MaxReferralId { get; set; }

        [Required]
        public string ProductIds { get; set; }
    }
}
