using Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Services.AutoMapperServices
{
    public interface IAutoMapperService
    {
        /// <summary>
        /// Maps a ReferralsReferralRequest object to a Referral object.
        /// </summary>
        /// <param name="myReferralsReferralRequest">ReferralsReferralRequest, parameter.</param>
        /// <returns>Referral</returns>
        Referral MapReferral(ReferralsReferralRequest myReferralsReferralRequest);

        LegalCustomerHistory MapLegalCustomerHistory(AsCustomerHistory myAsCustomerHistory);
        AsCustomerHistory MapAsCustomerHistory(LegalCustomerHistory myLegalCustomerHistory);
    }
}