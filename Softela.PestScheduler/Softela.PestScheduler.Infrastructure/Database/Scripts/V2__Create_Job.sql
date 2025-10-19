IF OBJECT_ID(N'dbo.usp_Job_Insert', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Job_Insert;
GO
CREATE PROCEDURE dbo.usp_Job_Insert
    @EventId INT = NULL,
    @EventSaleDate DATETIME = NULL,
    @EventCancelDate DATETIME = NULL,
    @EventAssignedTo INT = NULL,
    @EventRouteName NVARCHAR(50) = NULL,
    @WoEventId INT = NULL,
    @HeaderId INT = NULL,
    @BillAmount DECIMAL(18,2) = NULL,
    @ProdAmount DECIMAL(18,2) = NULL,
    @SaleAmount DECIMAL(18,2) = NULL,
    @TaxTypeId INT = NULL,
    @TaxTypeName NVARCHAR(50) = NULL,
    @FederalTaxAmount DECIMAL(18,2) = NULL,
    @StateTaxAmount DECIMAL(18,2) = NULL,
    @LocalTaxAmount DECIMAL(18,2) = NULL,
    @ScheduleDate DATETIME = NULL,
    @AssignedTo INT = NULL,
    @RouteName NVARCHAR(50) = NULL,
    @CompletedDate DATETIME = NULL,
    @CompletedAmount DECIMAL(18,2) = NULL,
    @WoType SMALLINT = NULL,
    @DeletedDate DATETIME = NULL,
    @CancelReasonId INT = NULL,
    @CancelReasonDesc NVARCHAR(MAX) = NULL,
    @SkippedDate DATETIME = NULL,
    @SkipReason NVARCHAR(MAX) = NULL,
    @JobInstructions NVARCHAR(MAX) = NULL,
    @ScheduleTime INT = NULL,
    @TimeRangeId INT = NULL,
    @TimeOptionDesc NVARCHAR(20) = NULL,
    @Duration INT = NULL,
    -- BaseEntity fields
    @CreatedBy UNIQUEIDENTIFIER = NULL,
    @CreatedAt DATETIME2 = NULL,
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Job (
        EventId, EventSaleDate, EventCancelDate, EventAssignedTo, EventRouteName,
        WoEventId, HeaderId,
        BillAmount, ProdAmount, SaleAmount,
        TaxTypeId, TaxTypeName,
        FederalTaxAmount, StateTaxAmount, LocalTaxAmount,
        ScheduleDate, AssignedTo, RouteName,
        CompletedDate, CompletedAmount,
        WoType, DeletedDate,
        CancelReasonId, CancelReasonDesc,
        SkippedDate, SkipReason, JobInstructions,
        ScheduleTime, TimeRangeId, TimeOptionDesc, Duration,
        CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    )
    VALUES (
        @EventId, @EventSaleDate, @EventCancelDate, @EventAssignedTo, @EventRouteName,
        @WoEventId, @HeaderId,
        @BillAmount, @ProdAmount, @SaleAmount,
        @TaxTypeId, @TaxTypeName,
        @FederalTaxAmount, @StateTaxAmount, @LocalTaxAmount,
        @ScheduleDate, @AssignedTo, @RouteName,
        @CompletedDate, @CompletedAmount,
        @WoType, @DeletedDate,
        @CancelReasonId, @CancelReasonDesc,
        @SkippedDate, @SkipReason, @JobInstructions,
        @ScheduleTime, @TimeRangeId, @TimeOptionDesc, @Duration,
        ISNULL(@CreatedBy, NEWID()), ISNULL(@CreatedAt, SYSUTCDATETIME()), ISNULL(@ModifiedBy, ISNULL(@CreatedBy, NEWID())), ISNULL(@ModifiedAt, ISNULL(@CreatedAt, SYSUTCDATETIME()))
    );

    SELECT CAST(SCOPE_IDENTITY() AS BIGINT) AS Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Job_Update', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Job_Update;
GO
CREATE PROCEDURE dbo.usp_Job_Update
    @Id BIGINT,
    @EventId INT = NULL,
    @EventSaleDate DATETIME = NULL,
    @EventCancelDate DATETIME = NULL,
    @EventAssignedTo INT = NULL,
    @EventRouteName NVARCHAR(50) = NULL,
    @WoEventId INT = NULL,
    @HeaderId INT = NULL,
    @BillAmount DECIMAL(18,2) = NULL,
    @ProdAmount DECIMAL(18,2) = NULL,
    @SaleAmount DECIMAL(18,2) = NULL,
    @TaxTypeId INT = NULL,
    @TaxTypeName NVARCHAR(50) = NULL,
    @FederalTaxAmount DECIMAL(18,2) = NULL,
    @StateTaxAmount DECIMAL(18,2) = NULL,
    @LocalTaxAmount DECIMAL(18,2) = NULL,
    @ScheduleDate DATETIME = NULL,
    @AssignedTo INT = NULL,
    @RouteName NVARCHAR(50) = NULL,
    @CompletedDate DATETIME = NULL,
    @CompletedAmount DECIMAL(18,2) = NULL,
    @WoType SMALLINT = NULL,
    @DeletedDate DATETIME = NULL,
    @CancelReasonId INT = NULL,
    @CancelReasonDesc NVARCHAR(MAX) = NULL,
    @SkippedDate DATETIME = NULL,
    @SkipReason NVARCHAR(MAX) = NULL,
    @JobInstructions NVARCHAR(MAX) = NULL,
    @ScheduleTime INT = NULL,
    @TimeRangeId INT = NULL,
    @TimeOptionDesc NVARCHAR(20) = NULL,
    @Duration INT = NULL,
    -- BaseEntity fields
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Job
    SET
        EventId = @EventId,
        EventSaleDate = @EventSaleDate,
        EventCancelDate = @EventCancelDate,
        EventAssignedTo = @EventAssignedTo,
        EventRouteName = @EventRouteName,
        WoEventId = @WoEventId,
        HeaderId = @HeaderId,
        BillAmount = @BillAmount,
        ProdAmount = @ProdAmount,
        SaleAmount = @SaleAmount,
        TaxTypeId = @TaxTypeId,
        TaxTypeName = @TaxTypeName,
        FederalTaxAmount = @FederalTaxAmount,
        StateTaxAmount = @StateTaxAmount,
        LocalTaxAmount = @LocalTaxAmount,
        ScheduleDate = @ScheduleDate,
        AssignedTo = @AssignedTo,
        RouteName = @RouteName,
        CompletedDate = @CompletedDate,
        CompletedAmount = @CompletedAmount,
        WoType = @WoType,
        DeletedDate = @DeletedDate,
        CancelReasonId = @CancelReasonId,
        CancelReasonDesc = @CancelReasonDesc,
        SkippedDate = @SkippedDate,
        SkipReason = @SkipReason,
        JobInstructions = @JobInstructions,
        ScheduleTime = @ScheduleTime,
        TimeRangeId = @TimeRangeId,
        TimeOptionDesc = @TimeOptionDesc,
        Duration = @Duration,
        ModifiedBy = ISNULL(@ModifiedBy, ModifiedBy),
        ModifiedAt = ISNULL(@ModifiedAt, SYSUTCDATETIME())
    WHERE Id = @Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Job_Upsert', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Job_Upsert;
GO
CREATE PROCEDURE dbo.usp_Job_Upsert
    @Id BIGINT = NULL,
    @EventId INT = NULL,
    @EventSaleDate DATETIME = NULL,
    @EventCancelDate DATETIME = NULL,
    @EventAssignedTo INT = NULL,
    @EventRouteName NVARCHAR(50) = NULL,
    @WoEventId INT = NULL,
    @HeaderId INT = NULL,
    @BillAmount DECIMAL(18,2) = NULL,
    @ProdAmount DECIMAL(18,2) = NULL,
    @SaleAmount DECIMAL(18,2) = NULL,
    @TaxTypeId INT = NULL,
    @TaxTypeName NVARCHAR(50) = NULL,
    @FederalTaxAmount DECIMAL(18,2) = NULL,
    @StateTaxAmount DECIMAL(18,2) = NULL,
    @LocalTaxAmount DECIMAL(18,2) = NULL,
    @ScheduleDate DATETIME = NULL,
    @AssignedTo INT = NULL,
    @RouteName NVARCHAR(50) = NULL,
    @CompletedDate DATETIME = NULL,
    @CompletedAmount DECIMAL(18,2) = NULL,
    @WoType SMALLINT = NULL,
    @DeletedDate DATETIME = NULL,
    @CancelReasonId INT = NULL,
    @CancelReasonDesc NVARCHAR(MAX) = NULL,
    @SkippedDate DATETIME = NULL,
    @SkipReason NVARCHAR(MAX) = NULL,
    @JobInstructions NVARCHAR(MAX) = NULL,
    @ScheduleTime INT = NULL,
    @TimeRangeId INT = NULL,
    @TimeOptionDesc NVARCHAR(20) = NULL,
    @Duration INT = NULL,
    -- BaseEntity fields
    @CreatedBy UNIQUEIDENTIFIER = NULL,
    @CreatedAt DATETIME2 = NULL,
    @ModifiedBy UNIQUEIDENTIFIER = NULL,
    @ModifiedAt DATETIME2 = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Job WHERE Id = @Id)
    BEGIN
        EXEC dbo.usp_Job_Update
            @Id = @Id,
            @EventId = @EventId,
            @EventSaleDate = @EventSaleDate,
            @EventCancelDate = @EventCancelDate,
            @EventAssignedTo = @EventAssignedTo,
            @EventRouteName = @EventRouteName,
            @WoEventId = @WoEventId,
            @HeaderId = @HeaderId,
            @BillAmount = @BillAmount,
            @ProdAmount = @ProdAmount,
            @SaleAmount = @SaleAmount,
            @TaxTypeId = @TaxTypeId,
            @TaxTypeName = @TaxTypeName,
            @FederalTaxAmount = @FederalTaxAmount,
            @StateTaxAmount = @StateTaxAmount,
            @LocalTaxAmount = @LocalTaxAmount,
            @ScheduleDate = @ScheduleDate,
            @AssignedTo = @AssignedTo,
            @RouteName = @RouteName,
            @CompletedDate = @CompletedDate,
            @CompletedAmount = @CompletedAmount,
            @WoType = @WoType,
            @DeletedDate = @DeletedDate,
            @CancelReasonId = @CancelReasonId,
            @CancelReasonDesc = @CancelReasonDesc,
            @SkippedDate = @SkippedDate,
            @SkipReason = @SkipReason,
            @JobInstructions = @JobInstructions,
            @ScheduleTime = @ScheduleTime,
            @TimeRangeId = @TimeRangeId,
            @TimeOptionDesc = @TimeOptionDesc,
            @Duration = @Duration,
            @ModifiedBy = @ModifiedBy,
            @ModifiedAt = @ModifiedAt;

        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        EXEC dbo.usp_Job_Insert
            @EventId = @EventId,
            @EventSaleDate = @EventSaleDate,
            @EventCancelDate = @EventCancelDate,
            @EventAssignedTo = @EventAssignedTo,
            @EventRouteName = @EventRouteName,
            @WoEventId = @WoEventId,
            @HeaderId = @HeaderId,
            @BillAmount = @BillAmount,
            @ProdAmount = @ProdAmount,
            @SaleAmount = @SaleAmount,
            @TaxTypeId = @TaxTypeId,
            @TaxTypeName = @TaxTypeName,
            @FederalTaxAmount = @FederalTaxAmount,
            @StateTaxAmount = @StateTaxAmount,
            @LocalTaxAmount = @LocalTaxAmount,
            @ScheduleDate = @ScheduleDate,
            @AssignedTo = @AssignedTo,
            @RouteName = @RouteName,
            @CompletedDate = @CompletedDate,
            @CompletedAmount = @CompletedAmount,
            @WoType = @WoType,
            @DeletedDate = @DeletedDate,
            @CancelReasonId = @CancelReasonId,
            @CancelReasonDesc = @CancelReasonDesc,
            @SkippedDate = @SkippedDate,
            @SkipReason = @SkipReason,
            @JobInstructions = @JobInstructions,
            @ScheduleTime = @ScheduleTime,
            @TimeRangeId = @TimeRangeId,
            @TimeOptionDesc = @TimeOptionDesc,
            @Duration = @Duration,
            @CreatedBy = @CreatedBy,
            @CreatedAt = @CreatedAt,
            @ModifiedBy = @ModifiedBy,
            @ModifiedAt = @ModifiedAt;
    END
END
GO

IF OBJECT_ID(N'dbo.usp_Job_GetById', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Job_GetById;
GO
CREATE PROCEDURE dbo.usp_Job_GetById
    @Id BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM dbo.Job
    WHERE Id = @Id;
END
GO

IF OBJECT_ID(N'dbo.usp_Job_Filter', N'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Job_Filter;
GO
CREATE PROCEDURE dbo.usp_Job_Filter
    @EventId INT = NULL,
    @AssignedTo INT = NULL,
    @ScheduleDateFrom DATETIME = NULL,
    @ScheduleDateTo DATETIME = NULL,
    @RouteName NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.Job j
    WHERE
        (@EventId IS NULL OR j.EventId = @EventId)
        AND (@AssignedTo IS NULL OR j.AssignedTo = @AssignedTo)
        AND (@RouteName IS NULL OR j.RouteName = @RouteName)
        AND (
            @ScheduleDateFrom IS NULL
            OR @ScheduleDateTo IS NULL
            OR (j.ScheduleDate BETWEEN @ScheduleDateFrom AND @ScheduleDateTo)
        );
END
GO