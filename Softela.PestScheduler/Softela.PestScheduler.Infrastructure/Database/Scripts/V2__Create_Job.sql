IF OBJECT_ID(N'dbo.Job', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Job
    (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,

        EventId INT NULL,
        EventSaleDate DATETIME NULL,
        EventCancelDate DATETIME NULL,
        EventAssignedTo INT NULL,
        EventRouteName NVARCHAR(50) NULL,

        WoEventId INT NULL,
        HeaderId INT NULL,

        BillAmount DECIMAL(18,2) NULL,
        ProdAmount DECIMAL(18,2) NULL,
        SaleAmount DECIMAL(18,2) NULL,

        TaxTypeId INT NULL,
        TaxTypeName NVARCHAR(50) NULL,

        FederalTaxAmount DECIMAL(18,2) NULL,
        StateTaxAmount DECIMAL(18,2) NULL,
        LocalTaxAmount DECIMAL(18,2) NULL,

        ScheduleDate DATETIME NULL,
        AssignedTo INT NULL,
        RouteName NVARCHAR(50) NULL,

        CompletedDate DATETIME NULL,
        CompletedAmount DECIMAL(18,2) NULL,

        WoType SMALLINT NULL,
        DeletedDate DATETIME NULL,

        CancelReasonId INT NULL,
        CancelReasonDesc NVARCHAR(MAX) NULL,

        SkippedDate DATETIME NULL,
        SkipReason NVARCHAR(MAX) NULL,

        JobInstructions NVARCHAR(MAX) NULL,

        ScheduleTime INT NULL,
        TimeRangeId INT NULL,
        TimeOptionDesc NVARCHAR(20) NULL,
        Duration INT NULL,

         -- Base fields
        CreatedBy NVARCHAR(50) NULL,
        CreatedAt DATETIME NULL,
        ModifiedBy NVARCHAR(50) NULL,
        ModifiedAt DATETIME NULL
    );
END