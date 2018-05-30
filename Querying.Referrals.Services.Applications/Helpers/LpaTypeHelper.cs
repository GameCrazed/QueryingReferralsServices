using System;
using System.Collections.Generic;
using System.Linq;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications.Helpers
{
    public class LpaTypeHelper : ILpaTypeHelper
    {
        public int? GetLegalLpaTypeFromReferralsRequest(List<Referral> referralsToAddOrUpdate)
        {
            try
            {
                if (!referralsToAddOrUpdate.Any())
                {
                    return null;
                }

                var myReferralsReferralProductIds = referralsToAddOrUpdate.Select(x => x.ProductId).ToList();

                var pfaYes = myReferralsReferralProductIds.Any(x => x == 12 || x == 13);

                if (pfaYes)
                {
                    var hwYes = myReferralsReferralProductIds.Any(x => x == 5 || x == 6);

                    if (hwYes)
                    {
                        var willYes = myReferralsReferralProductIds.Any(x => x == 4 || x == 11);

                        return willYes ? 6 : 3;
                    }
                    else
                    {
                        var willYes = myReferralsReferralProductIds.Any(x => x == 4 || x == 11);

                        return willYes ? 4 : 1;
                    }
                }
                else
                {
                    var hwYes = myReferralsReferralProductIds.Any(x => x == 5 || x == 6);

                    if (hwYes)
                    {
                        var willYes = myReferralsReferralProductIds.Any(x => x == 4 || x == 11);

                        return willYes ? 5 : 2;
                    }
                    else
                    {
                        var willYes = myReferralsReferralProductIds.Any(x => x == 4 || x == 11);

                        if (willYes)
                        {
                            return 7;
                        }

                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Applications.Helpers/GetLegalLpaTypeFromReferralsRequest", e);
            }
        }
    }
}