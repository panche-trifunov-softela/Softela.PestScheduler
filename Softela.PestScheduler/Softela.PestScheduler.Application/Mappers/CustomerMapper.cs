using Softela.PestScheduler.Application.Commands.Customer.CreateCustomer;
using Softela.PestScheduler.Application.Commands.Customer.UpdateCustomer;
using Softela.PestScheduler.Domain.Entities;

namespace Softela.PestScheduler.Application.Mappers
{
    public static class CustomerMapper
    {
        /// <summary>
        /// Map CreateCustomerRequest -> Customer (new entity).
        /// Sets CreatedBy/CreatedAt/ModifiedBy/ModifiedAt to provided values or defaults.
        /// </summary>
        public static Customer ToEntity(this CreateCustomerRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new Customer
            {
                AccountId = request.AccountId,
                AccountNum = request.AccountNum,
                IsActive = request.IsActive,
                AccountType = request.AccountType,

                Instructions = request.Instructions,
                PrimaryNote = request.PrimaryNote,
                SecondaryNote = request.SecondaryNote,

                BillingBranch = request.BillingBranch,
                BillingContactId = request.BillingContactId,
                BillingFirstName = request.BillingFirstName,
                BillingMiddleName = request.BillingMiddleName,
                BillingLastName = request.BillingLastName,
                BillingBusinessName = request.BillingBusinessName,
                BillingPhoneNumber = request.BillingPhoneNumber,
                BillingAddressId = request.BillingAddressId,
                BillingStreetNumber = request.BillingStreetNumber,
                BillingStreetName = request.BillingStreetName,
                BillingStreetSuffix = request.BillingStreetSuffix,
                BillingSecondaryAddress = request.BillingSecondaryAddress,
                BillingCity = request.BillingCity,
                BillingState = request.BillingState,
                BillingPostalCode = request.BillingPostalCode,
                BillingCountryId = request.BillingCountryId,

                SiteId = request.SiteId,
                SiteReferenceNumber = request.SiteReferenceNumber,
                SiteInstructions = request.SiteInstructions,
                SiteNotes = request.SiteNotes,
                SitePropertyTypeName = request.SitePropertyTypeName,
                SiteBranchName = request.SiteBranchName,
                SiteContactId = request.SiteContactId,
                SiteFirstName = request.SiteFirstName,
                SiteMiddleName = request.SiteMiddleName,
                SiteLastName = request.SiteLastName,
                SiteBusinessName = request.SiteBusinessName,
                SitePhoneNumber = request.SitePhoneNumber,
                SiteAddressId = request.SiteAddressId,
                SiteStreetNumber = request.SiteStreetNumber,
                SiteStreetName = request.SiteStreetName,
                SiteStreetSuffix = request.SiteStreetSuffix,
                SiteSecondaryAddress = request.SiteSecondaryAddress,
                SiteCity = request.SiteCity,
                SiteState = request.SiteState,
                SitePostalCode = request.SitePostalCode,
                SiteCountryId = request.SiteCountryId,

                EstimateId = request.EstimateId,
                EstimateName = request.EstimateName,
                EstimateBranchName = request.EstimateBranchName,

                ProgramId = request.ProgramId,
                ProgramSaleDate = request.ProgramSaleDate,
                ProgramCancelDate = request.ProgramCancelDate,
                ProgramPendingCancelDate = request.ProgramPendingCancelDate,
                ProgramInstructions = request.ProgramInstructions,
                ProgramPurchaseOrder = request.ProgramPurchaseOrder,
                ProgramPOExpirationDate = request.ProgramPOExpirationDate,

                // BaseEntity/audit
                CreatedBy = user,
                CreatedAt = now,
                ModifiedBy = user,
                ModifiedAt = now
            };
        }

        /// <summary>
        /// Map UpdateCustomerRequest -> Customer (new entity).
        /// Sets CreatedBy/CreatedAt/ModifiedBy/ModifiedAt to provided values or defaults.
        /// </summary>
        public static Customer ToEntity(this UpdateCustomerRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            return new Customer
            {
                AccountId = request.AccountId,
                AccountNum = request.AccountNum,
                IsActive = request.IsActive,
                AccountType = request.AccountType,

                Instructions = request.Instructions,
                PrimaryNote = request.PrimaryNote,
                SecondaryNote = request.SecondaryNote,

                BillingBranch = request.BillingBranch,
                BillingContactId = request.BillingContactId,
                BillingFirstName = request.BillingFirstName,
                BillingMiddleName = request.BillingMiddleName,
                BillingLastName = request.BillingLastName,
                BillingBusinessName = request.BillingBusinessName,
                BillingPhoneNumber = request.BillingPhoneNumber,
                BillingAddressId = request.BillingAddressId,
                BillingStreetNumber = request.BillingStreetNumber,
                BillingStreetName = request.BillingStreetName,
                BillingStreetSuffix = request.BillingStreetSuffix,
                BillingSecondaryAddress = request.BillingSecondaryAddress,
                BillingCity = request.BillingCity,
                BillingState = request.BillingState,
                BillingPostalCode = request.BillingPostalCode,
                BillingCountryId = request.BillingCountryId,

                SiteId = request.SiteId,
                SiteReferenceNumber = request.SiteReferenceNumber,
                SiteInstructions = request.SiteInstructions,
                SiteNotes = request.SiteNotes,
                SitePropertyTypeName = request.SitePropertyTypeName,
                SiteBranchName = request.SiteBranchName,
                SiteContactId = request.SiteContactId,
                SiteFirstName = request.SiteFirstName,
                SiteMiddleName = request.SiteMiddleName,
                SiteLastName = request.SiteLastName,
                SiteBusinessName = request.SiteBusinessName,
                SitePhoneNumber = request.SitePhoneNumber,
                SiteAddressId = request.SiteAddressId,
                SiteStreetNumber = request.SiteStreetNumber,
                SiteStreetName = request.SiteStreetName,
                SiteStreetSuffix = request.SiteStreetSuffix,
                SiteSecondaryAddress = request.SiteSecondaryAddress,
                SiteCity = request.SiteCity,
                SiteState = request.SiteState,
                SitePostalCode = request.SitePostalCode,
                SiteCountryId = request.SiteCountryId,

                EstimateId = request.EstimateId,
                EstimateName = request.EstimateName,
                EstimateBranchName = request.EstimateBranchName,

                ProgramId = request.ProgramId,
                ProgramSaleDate = request.ProgramSaleDate,
                ProgramCancelDate = request.ProgramCancelDate,
                ProgramPendingCancelDate = request.ProgramPendingCancelDate,
                ProgramInstructions = request.ProgramInstructions,
                ProgramPurchaseOrder = request.ProgramPurchaseOrder,
                ProgramPOExpirationDate = request.ProgramPOExpirationDate,

                // BaseEntity/audit
                CreatedBy = user,
                CreatedAt = now,
                ModifiedBy = user,
                ModifiedAt = now
            };
        }

        /// <summary>
        /// Apply values from CreateCustomerRequest to an existing Customer for update/upsert.
        /// Does not change Id. Updates ModifiedBy/ModifiedAt.
        /// </summary>
        public static void ApplyFrom(this Customer entity, CreateCustomerRequest request, Guid? auditUser = null, DateTime? auditUtc = null)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            if (request is null) throw new ArgumentNullException(nameof(request));

            var now = auditUtc ?? DateTime.UtcNow;
            var user = auditUser ?? Guid.Empty;

            entity.AccountId = request.AccountId;
            entity.AccountNum = request.AccountNum;
            entity.IsActive = request.IsActive;
            entity.AccountType = request.AccountType;

            entity.Instructions = request.Instructions;
            entity.PrimaryNote = request.PrimaryNote;
            entity.SecondaryNote = request.SecondaryNote;

            entity.BillingBranch = request.BillingBranch;
            entity.BillingContactId = request.BillingContactId;
            entity.BillingFirstName = request.BillingFirstName;
            entity.BillingMiddleName = request.BillingMiddleName;
            entity.BillingLastName = request.BillingLastName;
            entity.BillingBusinessName = request.BillingBusinessName;
            entity.BillingPhoneNumber = request.BillingPhoneNumber;
            entity.BillingAddressId = request.BillingAddressId;
            entity.BillingStreetNumber = request.BillingStreetNumber;
            entity.BillingStreetName = request.BillingStreetName;
            entity.BillingStreetSuffix = request.BillingStreetSuffix;
            entity.BillingSecondaryAddress = request.BillingSecondaryAddress;
            entity.BillingCity = request.BillingCity;
            entity.BillingState = request.BillingState;
            entity.BillingPostalCode = request.BillingPostalCode;
            entity.BillingCountryId = request.BillingCountryId;

            entity.SiteId = request.SiteId;
            entity.SiteReferenceNumber = request.SiteReferenceNumber;
            entity.SiteInstructions = request.SiteInstructions;
            entity.SiteNotes = request.SiteNotes;
            entity.SitePropertyTypeName = request.SitePropertyTypeName;
            entity.SiteBranchName = request.SiteBranchName;
            entity.SiteContactId = request.SiteContactId;
            entity.SiteFirstName = request.SiteFirstName;
            entity.SiteMiddleName = request.SiteMiddleName;
            entity.SiteLastName = request.SiteLastName;
            entity.SiteBusinessName = request.SiteBusinessName;
            entity.SitePhoneNumber = request.SitePhoneNumber;
            entity.SiteAddressId = request.SiteAddressId;
            entity.SiteStreetNumber = request.SiteStreetNumber;
            entity.SiteStreetName = request.SiteStreetName;
            entity.SiteStreetSuffix = request.SiteStreetSuffix;
            entity.SiteSecondaryAddress = request.SiteSecondaryAddress;
            entity.SiteCity = request.SiteCity;
            entity.SiteState = request.SiteState;
            entity.SitePostalCode = request.SitePostalCode;
            entity.SiteCountryId = request.SiteCountryId;

            entity.EstimateId = request.EstimateId;
            entity.EstimateName = request.EstimateName;
            entity.EstimateBranchName = request.EstimateBranchName;

            entity.ProgramId = request.ProgramId;
            entity.ProgramSaleDate = request.ProgramSaleDate;
            entity.ProgramCancelDate = request.ProgramCancelDate;
            entity.ProgramPendingCancelDate = request.ProgramPendingCancelDate;
            entity.ProgramInstructions = request.ProgramInstructions;
            entity.ProgramPurchaseOrder = request.ProgramPurchaseOrder;
            entity.ProgramPOExpirationDate = request.ProgramPOExpirationDate;

            entity.ModifiedBy = user;
            entity.ModifiedAt = now;
        }
    }
}
