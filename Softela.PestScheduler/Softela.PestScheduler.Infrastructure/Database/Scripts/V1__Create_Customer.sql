IF OBJECT_ID(N'dbo.Customer', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Customer
    (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,

        -- Account
        AccountId INT NOT NULL,
        AccountNum NVARCHAR(50) NULL,
        IsActive SMALLINT NOT NULL,
        AccountType INT NOT NULL,

        -- Notes / instructions
        Instructions NVARCHAR(900) NULL,
        PrimaryNote NVARCHAR(200) NULL,
        SecondaryNote NVARCHAR(200) NULL,

        -- Billing info
        BillingBranch NVARCHAR(255) NULL,
        BillingContactId INT NULL,
        BillingFirstName NVARCHAR(50) NULL,
        BillingMiddleName NVARCHAR(50) NULL,
        BillingLastName NVARCHAR(50) NULL,
        BillingBusinessName NVARCHAR(100) NULL,
        BillingPhoneNumber NVARCHAR(50) NULL,
        BillingAddressId INT NULL,
        BillingStreetNumber NVARCHAR(50) NULL,
        BillingStreetName NVARCHAR(50) NULL,
        BillingStreetSuffix NVARCHAR(50) NULL,
        BillingSecondaryAddress NVARCHAR(50) NULL,
        BillingCity NVARCHAR(50) NULL,
        BillingState NVARCHAR(50) NULL,
        BillingPostalCode NVARCHAR(50) NULL,
        BillingCountryId INT NULL,

        -- Site info
        SiteId INT NULL,
        SiteReferenceNumber NVARCHAR(50) NULL,
        SiteInstructions NVARCHAR(900) NULL,
        SiteNotes NVARCHAR(MAX) NULL,
        SitePropertyTypeName NVARCHAR(100) NULL,
        SiteBranchName NVARCHAR(255) NULL,
        SiteContactId INT NULL,
        SiteFirstName NVARCHAR(50) NULL,
        SiteMiddleName NVARCHAR(50) NULL,
        SiteLastName NVARCHAR(50) NULL,
        SiteBusinessName NVARCHAR(100) NULL,
        SitePhoneNumber NVARCHAR(50) NULL,
        SiteAddressId INT NULL,
        SiteStreetNumber NVARCHAR(50) NULL,
        SiteStreetName NVARCHAR(50) NULL,
        SiteStreetSuffix NVARCHAR(50) NULL,
        SiteSecondaryAddress NVARCHAR(50) NULL,
        SiteCity NVARCHAR(50) NULL,
        SiteState NVARCHAR(50) NULL,
        SitePostalCode NVARCHAR(50) NULL,
        SiteCountryId INT NULL,

        -- Estimate / Program
        EstimateId INT NULL,
        EstimateName NVARCHAR(75) NULL,
        EstimateBranchName NVARCHAR(50) NULL,

        ProgramId INT NULL,
        ProgramSaleDate DATETIME NULL,
        ProgramCancelDate DATETIME NULL,
        ProgramPendingCancelDate DATETIME NULL,
        ProgramInstructions NVARCHAR(4000) NULL,
        ProgramPurchaseOrder NVARCHAR(50) NULL,
        ProgramPOExpirationDate DATETIME NULL,

        -- Base fields
        CreatedBy NVARCHAR(50) NULL,
        CreatedAt DATETIME NULL,
        ModifiedBy NVARCHAR(50) NULL,
        ModifiedAt DATETIME NULL
    );
END