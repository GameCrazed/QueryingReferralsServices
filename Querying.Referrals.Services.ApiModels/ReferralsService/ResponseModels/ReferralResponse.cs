using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.ResponseModels
{
    public class ReferralResponse
    {
        public int ReferralId { get; set; }
        public int ProductId { get; set; }
        public int? SourceCompanyId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerForeName { get; set; }
        public string CustomerSurName { get; set; }
        public DateTime? CustomerDob { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStateProvince { get; set; }
        public string CustomerPostalCode { get; set; }
        public int? CustomerCountryId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTelephoneNumber { get; set; }
        public string CustomerMobileNumber { get; set; }
        public int? SecondCustomerId { get; set; }
        public string SecondCustomerForeName { get; set; }
        public string SecondCustomerSurName { get; set; }
        public DateTime? SecondCustomerDob { get; set; }
        public string SecondCustomerAddress { get; set; }
        public string SecondCustomerCity { get; set; }
        public string SecondCustomerStateProvince { get; set; }
        public string SecondCustomerPostalCode { get; set; }
        public int? SecondCustomerCountryId { get; set; }
        public string SecondCustomerEmail { get; set; }
        public string SecondCustomerTelephoneNumber { get; set; }
        public string SecondCustomerMobileNumber { get; set; }
        public int? ProductEventId { get; set; }
    }
}
