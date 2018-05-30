using System;

namespace Querying.Referrals.Services.ApiModels.ReferralsService.RequestModels
{
    public class ReferralsSupportDataRequest
    {
        //Estate Planning Data
        public bool HealthAndWelfareLpa { get; set; }
        public string EplpaYourObjective { get; set; }
        public bool? EpConsentToPassDetails { get; set; }
        public string EpSingleCouple { get; set; }
        public string EpSingleCoupleHw { get; set; }
        public string LegalWillObjective { get; set; }
        public string LegalWillJointSingle { get; set; }
        public int? LpaType { get; set; }

        //Mortgage Data
        public DateTime? MortgageCreationDate { get; set; }
        public int? AdvisorId { get; set; }
        public decimal? C1Salary { get; set; }
        public decimal C1PensionState { get; set; }
        public decimal? C1PensionPrivate { get; set; }
        public decimal? C1Benefits { get; set; }
        public decimal? C1Investments { get; set; }
        public decimal? C1TotalIncome { get; set; }
        public decimal? C2Salary { get; set; }
        public decimal? C2PensionState { get; set; }
        public decimal? C2PensionPrivate { get; set; }
        public decimal? C2Benefits { get; set; }
        public decimal? C2Investments { get; set; }
        public decimal? C2TotalIncome { get; set; }
        public decimal? ExistingMortgageBalance { get; set; }
        public decimal? SecondChargeBalance { get; set; }
        public decimal? CurrentPropertyValue { get; set; }
        public decimal? PlannedRetirementAge { get; set; }
        public string AdditionalInformation { get; set; }
        public decimal? AmountIncludingExistingMortgageBalance { get; set; }
        public decimal? AmountLendable { get; set; }
        public string Objectives { get; set; }
        public bool? IsShoppingAroundForMortgage { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool? HasCCJDCefaultOrBankruptcy { get; set; }
        public bool? CurrentlyInDebtManagementPlan { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool? IVAOrRegisteredIntoBankruptcyOrTrustDeed { get; set; }
        public bool? ArrearsOnMortgage { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool? CCJsOrDefaultsRegistered { get; set; }
        public bool? InDebtManagementPlan { get; set; }
        public decimal? AnnualIncome { get; set; }
        public DateTime? DocumentDueDate { get; set; }
        // ReSharper disable once InconsistentNaming
        public int? RefCustomerID { get; set; }
    }
}
