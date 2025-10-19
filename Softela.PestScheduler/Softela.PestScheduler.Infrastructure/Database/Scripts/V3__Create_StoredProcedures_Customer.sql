IF OBJECT_ID(N'dbo.usp_Customer_Insert', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Customer_Insert;
GO
CREATE PROCEDURE dbo.usp_Customer_Insert
    @AccountId INT,
    @AccountNum NVARCHAR(50) = NULL,
    @IsActive SMALLINT,
    @AccountType INT,
    @Instructions NVARCHAR(900) = NULL,
    @PrimaryNote NVARCHAR(200) = NULL,
    @SecondaryNote NVARCHAR(200) = NULL,
    @BillingBranch NVARCHAR(255) = NULL,
    @BillingContactId INT = NULL,
    @BillingFirstName NVARCHAR(50) = NULL,
    @BillingMiddleName NVARCHAR(50) = NULL,
    @BillingLastName NVARCHAR(50) = NULL,
    @BillingBusinessName NVARCHAR(100) = NULL,
    @BillingPhoneNumber NVARCHAR(50) = NULL,
    @BillingAddressId INT = NULL,
    @BillingStreetNumber NVARCHAR(50) = NULL,
    @BillingStreetName NVARCHAR(50) = NULL,
    @BillingStreetSuffix NVARCHAR(50) = NULL,
    @BillingSecondaryAddress NVARCHAR(50) = NULL,
    @BillingCity NVARCHAR(50) = NULL,
    @BillingState NVARCHAR(50) = NULL,
    @BillingPostalCode NVARCHAR(50) = NULL,
    @BillingCountryId INT = NULL,
    @SiteId INT = NULL,
    @SiteReferenceNumber NVARCHAR(50) = NULL,
    @SiteInstructions NVARCHAR(900) = NULL,
    @SiteNotes NVARCHAR(MAX) = NULL,
    @SitePropertyTypeName NVARCHAR(100) = NULL,
    @SiteBranchName NVARCHAR(255) = NULL,
    @SiteContactId INT = NULL,
    @SiteFirstName NVARCHAR(50) = NULL,
    @SiteMiddleName NVARCHAR(50) = NULL,
    @SiteLastName NVARCHAR(50) = NULL,
    @SiteBusinessName NVARCHAR(100) = NULL,
    @SitePhoneNumber NVARCHAR(50) = NULL,
    @SiteAddressId INT = NULL,
    @SiteStreetNumber NVARCHAR(50) = NULL,
    @SiteStreetName NVARCHAR(50) = NULL,
    @SiteStreetSuffix NVARCHAR(50) = NULL,
    @SiteSecondaryAddress NVARCHAR(50) = NULL,
    @SiteCity NVARCHAR(50) = NULL,
    @SiteState NVARCHAR(50) = NULL,
    @SitePostalCode NVARCHAR(50) = NULL,
    @SiteCountryId INT = NULL,
    @EstimateId INT = NULL,
    @EstimateName NVARCHAR(75) = NULL,
    @EstimateBranchName NVARCHAR(50) = NULL,
    @ProgramId INT = NULL,
    @ProgramSaleDate DATETIME = NULL,
    @ProgramCancelDate DATETIME = NULL,
    @ProgramPendingCancelDate DATETIME = NULL,
    @ProgramInstructions NVARCHAR(4000) = NULL,
    @ProgramPurchaseOrder NVARCHAR(50) = NULL,
    @ProgramPOExpirationDate DATETIME = NULL,
    @AddressId INT = NULL,
    @ContactId INT = NULL,
    @SalespersonId INT = NULL,
    -- BaseEntity fields
    @CreatedBy UNIQUEIDENTIFIER = NULL,
    @CreatedAt DATETIME2 = NULL,
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Customer (
        AccountId, AccountNum, IsActive, AccountType,
        Instructions, PrimaryNote, SecondaryNote,
        BillingBranch, BillingContactId, BillingFirstName, BillingMiddleName, BillingLastName, BillingBusinessName, BillingPhoneNumber, BillingAddressId,
        BillingStreetNumber, BillingStreetName, BillingStreetSuffix, BillingSecondaryAddress, BillingCity, BillingState, BillingPostalCode, BillingCountryId,
        SiteId, SiteReferenceNumber, SiteInstructions, SiteNotes, SitePropertyTypeName, SiteBranchName, SiteContactId, SiteFirstName, SiteMiddleName, SiteLastName, SiteBusinessName, SitePhoneNumber, SiteAddressId,
        SiteStreetNumber, SiteStreetName, SiteStreetSuffix, SiteSecondaryAddress, SiteCity, SiteState, SitePostalCode, SiteCountryId,
        EstimateId, EstimateName, EstimateBranchName,
        ProgramId, ProgramSaleDate, ProgramCancelDate, ProgramPendingCancelDate, ProgramInstructions, ProgramPurchaseOrder, ProgramPOExpirationDate,
        AddressId, ContactId, SalespersonId,
        CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    )
    VALUES (
        @AccountId, @AccountNum, @IsActive, @AccountType,
        @Instructions, @PrimaryNote, @SecondaryNote,
        @BillingBranch, @BillingContactId, @BillingFirstName, @BillingMiddleName, @BillingLastName, @BillingBusinessName, @BillingPhoneNumber, @BillingAddressId,
        @BillingStreetNumber, @BillingStreetName, @BillingStreetSuffix, @BillingSecondaryAddress, @BillingCity, @BillingState, @BillingPostalCode, @BillingCountryId,
        @SiteId, @SiteReferenceNumber, @SiteInstructions, @SiteNotes, @SitePropertyTypeName, @SiteBranchName, @SiteContactId, @SiteFirstName, @SiteMiddleName, @SiteLastName, @SiteBusinessName, @SitePhoneNumber, @SiteAddressId,
        @SiteStreetNumber, @SiteStreetName, @SiteStreetSuffix, @SiteSecondaryAddress, @SiteCity, @SiteState, @SitePostalCode, @SiteCountryId,
        @EstimateId, @EstimateName, @EstimateBranchName,
        @ProgramId, @ProgramSaleDate, @ProgramCancelDate, @ProgramPendingCancelDate, @ProgramInstructions, @ProgramPurchaseOrder, @ProgramPOExpirationDate,
        @AddressId, @ContactId, @SalespersonId,
        ISNULL(@CreatedBy, NEWID()), ISNULL(@CreatedAt, SYSUTCDATETIME()), ISNULL(@ModifiedBy, ISNULL(@CreatedBy, NEWID())), ISNULL(@ModifiedAt, ISNULL(@CreatedAt, SYSUTCDATETIME()))
    );

    SELECT CAST(SCOPE_IDENTITY() AS BIGINT) AS Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Customer_Update', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Customer_Update;
GO
CREATE PROCEDURE dbo.usp_Customer_Update
    @Id BIGINT,
    @AccountId INT,
    @AccountNum NVARCHAR(50) = NULL,
    @IsActive SMALLINT,
    @AccountType INT,
    @Instructions NVARCHAR(900) = NULL,
    @PrimaryNote NVARCHAR(200) = NULL,
    @SecondaryNote NVARCHAR(200) = NULL,
    @BillingBranch NVARCHAR(255) = NULL,
    @BillingContactId INT = NULL,
    @BillingFirstName NVARCHAR(50) = NULL,
    @BillingMiddleName NVARCHAR(50) = NULL,
    @BillingLastName NVARCHAR(50) = NULL,
    @BillingBusinessName NVARCHAR(100) = NULL,
    @BillingPhoneNumber NVARCHAR(50) = NULL,
    @BillingAddressId INT = NULL,
    @BillingStreetNumber NVARCHAR(50) = NULL,
    @BillingStreetName NVARCHAR(50) = NULL,
    @BillingStreetSuffix NVARCHAR(50) = NULL,
    @BillingSecondaryAddress NVARCHAR(50) = NULL,
    @BillingCity NVARCHAR(50) = NULL,
    @BillingState NVARCHAR(50) = NULL,
    @BillingPostalCode NVARCHAR(50) = NULL,
    @BillingCountryId INT = NULL,
    @SiteId INT = NULL,
    @SiteReferenceNumber NVARCHAR(50) = NULL,
    @SiteInstructions NVARCHAR(900) = NULL,
    @SiteNotes NVARCHAR(MAX) = NULL,
    @SitePropertyTypeName NVARCHAR(100) = NULL,
    @SiteBranchName NVARCHAR(255) = NULL,
    @SiteContactId INT = NULL,
    @SiteFirstName NVARCHAR(50) = NULL,
    @SiteMiddleName NVARCHAR(50) = NULL,
    @SiteLastName NVARCHAR(50) = NULL,
    @SiteBusinessName NVARCHAR(100) = NULL,
    @SitePhoneNumber NVARCHAR(50) = NULL,
    @SiteAddressId INT = NULL,
    @SiteStreetNumber NVARCHAR(50) = NULL,
    @SiteStreetName NVARCHAR(50) = NULL,
    @SiteStreetSuffix NVARCHAR(50) = NULL,
    @SiteSecondaryAddress NVARCHAR(50) = NULL,
    @SiteCity NVARCHAR(50) = NULL,
    @SiteState NVARCHAR(50) = NULL,
    @SitePostalCode NVARCHAR(50) = NULL,
    @SiteCountryId INT = NULL,
    @EstimateId INT = NULL,
    @EstimateName NVARCHAR(75) = NULL,
    @EstimateBranchName NVARCHAR(50) = NULL,
    @ProgramId INT = NULL,
    @ProgramSaleDate DATETIME = NULL,
    @ProgramCancelDate DATETIME = NULL,
    @ProgramPendingCancelDate DATETIME = NULL,
    @ProgramInstructions NVARCHAR(4000) = NULL,
    @ProgramPurchaseOrder NVARCHAR(50) = NULL,
    @ProgramPOExpirationDate DATETIME = NULL,
    @AddressId INT = NULL,
    @ContactId INT = NULL,
    @SalespersonId INT = NULL,
    -- BaseEntity fields
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Customer
    SET
        AccountId = @AccountId,
        AccountNum = @AccountNum,
        IsActive = @IsActive,
        AccountType = @AccountType,
        Instructions = @Instructions,
        PrimaryNote = @PrimaryNote,
        SecondaryNote = @SecondaryNote,
        BillingBranch = @BillingBranch,
        BillingContactId = @BillingContactId,
        BillingFirstName = @BillingFirstName,
        BillingMiddleName = @BillingMiddleName,
        BillingLastName = @BillingLastName,
        BillingBusinessName = @BillingBusinessName,
        BillingPhoneNumber = @BillingPhoneNumber,
        BillingAddressId = @BillingAddressId,
        BillingStreetNumber = @BillingStreetNumber,
        BillingStreetName = @BillingStreetName,
        BillingStreetSuffix = @BillingStreetSuffix,
        BillingSecondaryAddress = @BillingSecondaryAddress,
        BillingCity = @BillingCity,
        BillingState = @BillingState,
        BillingPostalCode = @BillingPostalCode,
        BillingCountryId = @BillingCountryId,
        SiteId = @SiteId,
        SiteReferenceNumber = @SiteReferenceNumber,
        SiteInstructions = @SiteInstructions,
        SiteNotes = @SiteNotes,
        SitePropertyTypeName = @SitePropertyTypeName,
        SiteBranchName = @SiteBranchName,
        SiteContactId = @SiteContactId,
        SiteFirstName = @SiteFirstName,
        SiteMiddleName = @SiteMiddleName,
        SiteLastName = @SiteLastName,
        SiteBusinessName = @SiteBusinessName,
        SitePhoneNumber = @SitePhoneNumber,
        SiteAddressId = @SiteAddressId,
        SiteStreetNumber = @SiteStreetNumber,
        SiteStreetName = @SiteStreetName,
        SiteStreetSuffix = @SiteStreetSuffix,
        SiteSecondaryAddress = @SiteSecondaryAddress,
        SiteCity = @SiteCity,
        SiteState = @SiteState,
        SitePostalCode = @SitePostalCode,
        SiteCountryId = @SiteCountryId,
        EstimateId = @EstimateId,
        EstimateName = @EstimateName,
        EstimateBranchName = @EstimateBranchName,
        ProgramId = @ProgramId,
        ProgramSaleDate = @ProgramSaleDate,
        ProgramCancelDate = @ProgramCancelDate,
        ProgramPendingCancelDate = @ProgramPendingCancelDate,
        ProgramInstructions = @ProgramInstructions,
        ProgramPurchaseOrder = @ProgramPurchaseOrder,
        ProgramPOExpirationDate = @ProgramPOExpirationDate,
        AddressId = @AddressId,
        ContactId = @ContactId,
        SalespersonId = @SalespersonId,
        ModifiedBy = ISNULL(@ModifiedBy, ModifiedBy),
        ModifiedAt = ISNULL(@ModifiedAt, SYSUTCDATETIME())
    WHERE Id = @Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Customer_Upsert', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Customer_Upsert;
GO
CREATE PROCEDURE dbo.usp_Customer_Upsert
    @Id BIGINT = NULL,
    @AccountId INT,
    @AccountNum NVARCHAR(50) = NULL,
    @IsActive SMALLINT,
    @AccountType INT,
    @Instructions NVARCHAR(900) = NULL,
    @PrimaryNote NVARCHAR(200) = NULL,
    @SecondaryNote NVARCHAR(200) = NULL,
    @BillingBranch NVARCHAR(255) = NULL,
    @BillingContactId INT = NULL,
    @BillingFirstName NVARCHAR(50) = NULL,
    @BillingMiddleName NVARCHAR(50) = NULL,
    @BillingLastName NVARCHAR(50) = NULL,
    @BillingBusinessName NVARCHAR(100) = NULL,
    @BillingPhoneNumber NVARCHAR(50) = NULL,
    @BillingAddressId INT = NULL,
    @BillingStreetNumber NVARCHAR(50) = NULL,
    @BillingStreetName NVARCHAR(50) = NULL,
    @BillingStreetSuffix NVARCHAR(50) = NULL,
    @BillingSecondaryAddress NVARCHAR(50) = NULL,
    @BillingCity NVARCHAR(50) = NULL,
    @BillingState NVARCHAR(50) = NULL,
    @BillingPostalCode NVARCHAR(50) = NULL,
    @BillingCountryId INT = NULL,
    @SiteId INT = NULL,
    @SiteReferenceNumber NVARCHAR(50) = NULL,
    @SiteInstructions NVARCHAR(900) = NULL,
    @SiteNotes NVARCHAR(MAX) = NULL,
    @SitePropertyTypeName NVARCHAR(100) = NULL,
    @SiteBranchName NVARCHAR(255) = NULL,
    @SiteContactId INT = NULL,
    @SiteFirstName NVARCHAR(50) = NULL,
    @SiteMiddleName NVARCHAR(50) = NULL,
    @SiteLastName NVARCHAR(50) = NULL,
    @SiteBusinessName NVARCHAR(100) = NULL,
    @SitePhoneNumber NVARCHAR(50) = NULL,
    @SiteAddressId INT = NULL,
    @SiteStreetNumber NVARCHAR(50) = NULL,
    @SiteStreetName NVARCHAR(50) = NULL,
    @SiteStreetSuffix NVARCHAR(50) = NULL,
    @SiteSecondaryAddress NVARCHAR(50) = NULL,
    @SiteCity NVARCHAR(50) = NULL,
    @SiteState NVARCHAR(50) = NULL,
    @SitePostalCode NVARCHAR(50) = NULL,
    @SiteCountryId INT = NULL,
    @EstimateId INT = NULL,
    @EstimateName NVARCHAR(75) = NULL,
    @EstimateBranchName NVARCHAR(50) = NULL,
    @ProgramId INT = NULL,
    @ProgramSaleDate DATETIME = NULL,
    @ProgramCancelDate DATETIME = NULL,
    @ProgramPendingCancelDate DATETIME = NULL,
    @ProgramInstructions NVARCHAR(4000) = NULL,
    @ProgramPurchaseOrder NVARCHAR(50) = NULL,
    @ProgramPOExpirationDate DATETIME = NULL,
    @AddressId INT = NULL,
    @ContactId INT = NULL,
    @SalespersonId INT = NULL,
    -- BaseEntity fields
    @CreatedBy UNIQUEIDENTIFIER = NULL,
    @CreatedAt DATETIME2 = NULL,
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Customer WHERE Id = @Id)
    BEGIN
        EXEC dbo.usp_Customer_Update
            @Id = @Id,
            @AccountId = @AccountId,
            @AccountNum = @AccountNum,
            @IsActive = @IsActive,
            @AccountType = @AccountType,
            @Instructions = @Instructions,
            @PrimaryNote = @PrimaryNote,
            @SecondaryNote = @SecondaryNote,
            @BillingBranch = @BillingBranch,
            @BillingContactId = @BillingContactId,
            @BillingFirstName = @BillingFirstName,
            @BillingMiddleName = @BillingMiddleName,
            @BillingLastName = @BillingLastName,
            @BillingBusinessName = @BillingBusinessName,
            @BillingPhoneNumber = @BillingPhoneNumber,
            @BillingAddressId = @BillingAddressId,
            @BillingStreetNumber = @BillingStreetNumber,
            @BillingStreetName = @BillingStreetName,
            @BillingStreetSuffix = @BillingStreetSuffix,
            @BillingSecondaryAddress = @BillingSecondaryAddress,
            @BillingCity = @BillingCity,
            @BillingState = @BillingState,
            @BillingPostalCode = @BillingPostalCode,
            @BillingCountryId = @BillingCountryId,
            @SiteId = @SiteId,
            @SiteReferenceNumber = @SiteReferenceNumber,
            @SiteInstructions = @SiteInstructions,
            @SiteNotes = @SiteNotes,
            @SitePropertyTypeName = @SitePropertyTypeName,
            @SiteBranchName = @SiteBranchName,
            @SiteContactId = @SiteContactId,
            @SiteFirstName = @SiteFirstName,
            @SiteMiddleName = @SiteMiddleName,
            @SiteLastName = @SiteLastName,
            @SiteBusinessName = @SiteBusinessName,
            @SitePhoneNumber = @SitePhoneNumber,
            @SiteAddressId = @SiteAddressId,
            @SiteStreetNumber = @SiteStreetNumber,
            @SiteStreetName = @SiteStreetName,
            @SiteStreetSuffix = @SiteStreetSuffix,
            @SiteSecondaryAddress = @SiteSecondaryAddress,
            @SiteCity = @SiteCity,
            @SiteState = @SiteState,
            @SitePostalCode = @SitePostalCode,
            @SiteCountryId = @SiteCountryId,
            @EstimateId = @EstimateId,
            @EstimateName = @EstimateName,
            @EstimateBranchName = @EstimateBranchName,
            @ProgramId = @ProgramId,
            @ProgramSaleDate = @ProgramSaleDate,
            @ProgramCancelDate = @ProgramCancelDate,
            @ProgramPendingCancelDate = @ProgramPendingCancelDate,
            @ProgramInstructions = @ProgramInstructions,
            @ProgramPurchaseOrder = @ProgramPurchaseOrder,
            @ProgramPOExpirationDate = @ProgramPOExpirationDate,
            @AddressId = @AddressId,
            @ContactId = @ContactId,
            @SalespersonId = @SalespersonId,
            @ModifiedBy = @ModifiedBy,
            @ModifiedAt = @ModifiedAt;
        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        EXEC dbo.usp_Customer_Insert
            @AccountId = @AccountId,
            @AccountNum = @AccountNum,
            @IsActive = @IsActive,
            @AccountType = @AccountType,
            @Instructions = @Instructions,
            @PrimaryNote = @PrimaryNote,
            @SecondaryNote = @SecondaryNote,
            @BillingBranch = @BillingBranch,
            @BillingContactId = @BillingContactId,
            @BillingFirstName = @BillingFirstName,
            @BillingMiddleName = @BillingMiddleName,
            @BillingLastName = @BillingLastName,
            @BillingBusinessName = @BillingBusinessName,
            @BillingPhoneNumber = @BillingPhoneNumber,
            @BillingAddressId = @BillingAddressId,
            @BillingStreetNumber = @BillingStreetNumber,
            @BillingStreetName = @BillingStreetName,
            @BillingStreetSuffix = @BillingStreetSuffix,
            @BillingSecondaryAddress = @BillingSecondaryAddress,
            @BillingCity = @BillingCity,
            @BillingState = @BillingState,
            @BillingPostalCode = @BillingPostalCode,
            @BillingCountryId = @BillingCountryId,
            @SiteId = @SiteId,
            @SiteReferenceNumber = @SiteReferenceNumber,
            @SiteInstructions = @SiteInstructions,
            @SiteNotes = @SiteNotes,
            @SitePropertyTypeName = @SitePropertyTypeName,
            @SiteBranchName = @SiteBranchName,
            @SiteContactId = @SiteContactId,
            @SiteFirstName = @SiteFirstName,
            @SiteMiddleName = @SiteMiddleName,
            @SiteLastName = @SiteLastName,
            @SiteBusinessName = @SiteBusinessName,
            @SitePhoneNumber = @SitePhoneNumber,
            @SiteAddressId = @SiteAddressId,
            @SiteStreetNumber = @SiteStreetNumber,
            @SiteStreetName = @SiteStreetName,
            @SiteStreetSuffix = @SiteStreetSuffix,
            @SiteSecondaryAddress = @SiteSecondaryAddress,
            @SiteCity = @SiteCity,
            @SiteState = @SiteState,
            @SitePostalCode = @SitePostalCode,
            @SiteCountryId = @SiteCountryId,
            @EstimateId = @EstimateId,
            @EstimateName = @EstimateName,
            @EstimateBranchName = @EstimateBranchName,
            @ProgramId = @ProgramId,
            @ProgramSaleDate = @ProgramSaleDate,
            @ProgramCancelDate = @ProgramCancelDate,
            @ProgramPendingCancelDate = @ProgramPendingCancelDate,
            @ProgramInstructions = @ProgramInstructions,
            @ProgramPurchaseOrder = @ProgramPurchaseOrder,
            @ProgramPOExpirationDate = @ProgramPOExpirationDate,
            @AddressId = @AddressId,
            @ContactId = @ContactId,
            @SalespersonId = @SalespersonId,
            @CreatedBy = @CreatedBy,
            @CreatedAt = @CreatedAt,
            @ModifiedBy = @ModifiedBy,
            @ModifiedAt = @ModifiedAt;
    END
END
GO

IF OBJECT_ID(N'dbo.usp_Customer_GetById', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Customer_GetById;
GO
CREATE PROCEDURE dbo.usp_Customer_GetById
    @Id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM dbo.Customer
    WHERE Id = @Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Customer_Filter', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Customer_Filter;
GO
CREATE PROCEDURE dbo.usp_Customer_Filter
    @AccountId INT = NULL,
    @AccountNum NVARCHAR(50) = NULL,
    @IsActive SMALLINT = NULL,
    @SiteId INT = NULL,
    @BillingPhoneNumber NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.Customer c
    WHERE
        (@AccountId IS NULL OR c.AccountId = @AccountId)
        AND (@AccountNum IS NULL OR c.AccountNum = @AccountNum)
        AND (@IsActive IS NULL OR c.IsActive = @IsActive)
        AND (@SiteId IS NULL OR c.SiteId = @SiteId)
        AND (@BillingPhoneNumber IS NULL OR c.BillingPhoneNumber = @BillingPhoneNumber);
END
GO