using System;
using AutoMapper;
using Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Services.AutoMapperServices
{
    public class AutoMapperService : IAutoMapperService
    {
        /// <summary>
        /// Maps a ReferralsReferralRequest object to a Referral object.
        /// </summary>
        /// <param name="myReferralsReferralRequest">ReferralsReferralRequest, parameter.</param>
        /// <returns>Referral</returns>
        public Referral MapReferral(ReferralsReferralRequest myReferralsReferralRequest)
        {
            try
            {
                var myRes = Mapper.Map<Referral>(myReferralsReferralRequest);

                return myRes;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AutoMapperServices/AutoMapperService/" + nameof(MapReferral) + ": " + e.Message, e);
            }
        }


        public LegalCustomerHistory MapLegalCustomerHistory(AsCustomerHistory myAsCustomerHistory)
        {
            try
            {
                var myRes = Mapper.Map<LegalCustomerHistory>(myAsCustomerHistory);

                return myRes;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AutoMapperServices/AutoMapperService/" + nameof(MapLegalCustomerHistory) + ": " + e.Message, e);
            }
        }

        public AsCustomerHistory MapAsCustomerHistory(LegalCustomerHistory myLegalCustomerHistory)
        {
            try
            {
                var myRes = Mapper.Map<AsCustomerHistory>(myLegalCustomerHistory);

                return myRes;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Services.AutoMapperServices/AutoMapperService/" + nameof(MapAsCustomerHistory) + ": " + e.Message, e);
            }
        }
    }
}