using Softela.PestScheduler.Application.Commands.Job.CreateJob;
using Softela.PestScheduler.Application.Commands.Job.UpdateJob;
using Softela.PestScheduler.Domain.Entities;

namespace Softela.PestScheduler.Application.Mappers
{
    public static class JobMapper
    {
        /// <summary>
        /// Map CreateJobRequest -> Job (new entity).
        /// Sets CreatedBy/CreatedAt/ModifiedBy/ModifiedAt to provided values or defaults.
        /// </summary>
        public static Job ToEntity(this CreateJobRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new Job
            {
                EventId = request.EventId,
                EventSaleDate = request.EventSaleDate,
                EventCancelDate = request.EventCancelDate,
                EventAssignedTo = request.EventAssignedTo,
                EventRouteName = request.EventRouteName,
                WoEventId = request.WoEventId,
                HeaderId = request.HeaderId,
                BillAmount = request.BillAmount,
                ProdAmount = request.ProdAmount,
                SaleAmount = request.SaleAmount,
                TaxTypeId = request.TaxTypeId,
                TaxTypeName = request.TaxTypeName,
                FederalTaxAmount = request.FederalTaxAmount,
                StateTaxAmount = request.StateTaxAmount,
                LocalTaxAmount = request.LocalTaxAmount,
                ScheduleDate = request.ScheduleDate,
                AssignedTo = request.AssignedTo,
                RouteName = request.RouteName,
                CompletedDate = request.CompletedDate,
                CompletedAmount = request.CompletedAmount,
                WoType = request.WoType,
                DeletedDate = request.DeletedDate,
                CancelReasonId = request.CancelReasonId,
                CancelReasonDesc = request.CancelReasonDesc,
                SkippedDate = request.SkippedDate,
                SkipReason = request.SkipReason,
                JobInstructions = request.JobInstructions,
                ScheduleTime = request.ScheduleTime,
                TimeRangeId = request.TimeRangeId,
                TimeOptionDesc = request.TimeOptionDesc,
                Duration = request.Duration,

                // BaseEntity/audit
                CreatedBy = user,
                CreatedAt = now,
                ModifiedBy = user,
                ModifiedAt = now
            };
        }

        public static Job ToEntity(this UpdateJobRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new Job
            {
                EventId = request.EventId,
                EventSaleDate = request.EventSaleDate,
                EventCancelDate = request.EventCancelDate,
                EventAssignedTo = request.EventAssignedTo,
                EventRouteName = request.EventRouteName,
                WoEventId = request.WoEventId,
                HeaderId = request.HeaderId,
                BillAmount = request.BillAmount,
                ProdAmount = request.ProdAmount,
                SaleAmount = request.SaleAmount,
                TaxTypeId = request.TaxTypeId,
                TaxTypeName = request.TaxTypeName,
                FederalTaxAmount = request.FederalTaxAmount,
                StateTaxAmount = request.StateTaxAmount,
                LocalTaxAmount = request.LocalTaxAmount,
                ScheduleDate = request.ScheduleDate,
                AssignedTo = request.AssignedTo,
                RouteName = request.RouteName,
                CompletedDate = request.CompletedDate,
                CompletedAmount = request.CompletedAmount,
                WoType = request.WoType,
                DeletedDate = request.DeletedDate,
                CancelReasonId = request.CancelReasonId,
                CancelReasonDesc = request.CancelReasonDesc,
                SkippedDate = request.SkippedDate,
                SkipReason = request.SkipReason,
                JobInstructions = request.JobInstructions,
                ScheduleTime = request.ScheduleTime,
                TimeRangeId = request.TimeRangeId,
                TimeOptionDesc = request.TimeOptionDesc,
                Duration = request.Duration,

                // BaseEntity/audit
                CreatedBy = user,
                CreatedAt = now,
                ModifiedBy = user,
                ModifiedAt = now
            };
        }

        /// <summary>
        /// Apply values from UpdateJobRequest to an existing Job for update/upsert.
        /// Does not change Id. Updates ModifiedBy/ModifiedAt.
        /// </summary>
        public static void ApplyFrom(this Job entity, UpdateJobRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            entity.EventId = request.EventId;
            entity.EventSaleDate = request.EventSaleDate;
            entity.EventCancelDate = request.EventCancelDate;
            entity.EventAssignedTo = request.EventAssignedTo;
            entity.EventRouteName = request.EventRouteName;
            entity.WoEventId = request.WoEventId;
            entity.HeaderId = request.HeaderId;
            entity.BillAmount = request.BillAmount;
            entity.ProdAmount = request.ProdAmount;
            entity.SaleAmount = request.SaleAmount;
            entity.TaxTypeId = request.TaxTypeId;
            entity.TaxTypeName = request.TaxTypeName;
            entity.FederalTaxAmount = request.FederalTaxAmount;
            entity.StateTaxAmount = request.StateTaxAmount;
            entity.LocalTaxAmount = request.LocalTaxAmount;
            entity.ScheduleDate = request.ScheduleDate;
            entity.AssignedTo = request.AssignedTo;
            entity.RouteName = request.RouteName;
            entity.CompletedDate = request.CompletedDate;
            entity.CompletedAmount = request.CompletedAmount;
            entity.WoType = request.WoType;
            entity.DeletedDate = request.DeletedDate;
            entity.CancelReasonId = request.CancelReasonId;
            entity.CancelReasonDesc = request.CancelReasonDesc;
            entity.SkippedDate = request.SkippedDate;
            entity.SkipReason = request.SkipReason;
            entity.JobInstructions = request.JobInstructions;
            entity.ScheduleTime = request.ScheduleTime;
            entity.TimeRangeId = request.TimeRangeId;
            entity.TimeOptionDesc = request.TimeOptionDesc;
            entity.Duration = request.Duration;

            entity.ModifiedBy = user;
            entity.ModifiedAt = now;
        }
    }
}
