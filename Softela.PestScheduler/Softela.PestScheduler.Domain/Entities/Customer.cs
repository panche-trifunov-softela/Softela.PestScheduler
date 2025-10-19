namespace Softela.PestScheduler.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public int AccountId { get; set; }
        public string AccountNum { get; set; }
        public short IsActive { get; set; }
        public int AccountType { get; set; }

        public string Instructions { get; set; }
        public string PrimaryNote { get; set; }
        public string SecondaryNote { get; set; }

        // Billing info
        public string BillingBranch { get; set; }
        public int BillingContactId { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingMiddleName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingBusinessName { get; set; }
        public string BillingPhoneNumber { get; set; }
        public int BillingAddressId { get; set; }
        public string BillingStreetNumber { get; set; }
        public string BillingStreetName { get; set; }
        public string BillingStreetSuffix { get; set; }
        public string BillingSecondaryAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public int BillingCountryId { get; set; }

        // Site info
        public int SiteId { get; set; }
        public string SiteReferenceNumber { get; set; }
        public string SiteInstructions { get; set; }
        public string SiteNotes { get; set; }
        public string SitePropertyTypeName { get; set; }
        public string SiteBranchName { get; set; }
        public int SiteContactId { get; set; }
        public string SiteFirstName { get; set; }
        public string SiteMiddleName { get; set; }
        public string SiteLastName { get; set; }
        public string SiteBusinessName { get; set; }
        public string SitePhoneNumber { get; set; }
        public int SiteAddressId { get; set; }
        public string SiteStreetNumber { get; set; }
        public string SiteStreetName { get; set; }
        public string SiteStreetSuffix { get; set; }
        public string SiteSecondaryAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string SitePostalCode { get; set; }
        public int SiteCountryId { get; set; }

        // Estimate / Program
        public int EstimateId { get; set; }
        public string EstimateName { get; set; }
        public string EstimateBranchName { get; set; }

        public int ProgramId { get; set; }
        public DateTime ProgramSaleDate { get; set; }
        public DateTime ProgramCancelDate { get; set; }
        public DateTime ProgramPendingCancelDate { get; set; }
        public string ProgramInstructions { get; set; }
        public string ProgramPurchaseOrder { get; set; }
        public DateTime ProgramPOExpirationDate { get; set; }
    }
}
