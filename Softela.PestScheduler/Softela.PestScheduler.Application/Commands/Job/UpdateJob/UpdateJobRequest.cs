using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestScheduler.Application.Commands.Job.UpdateJob
{
    public class UpdateJobRequest : IRequest<bool>
    {
        public int EventId { get; set; }
        public DateTime EventSaleDate { get; set; }
        public DateTime EventCancelDate { get; set; }
        public int EventAssignedTo { get; set; }
        public string EventRouteName { get; set; }
        public int WoEventId { get; set; }
        public int HeaderId { get; set; }
        public decimal BillAmount { get; set; }
        public decimal ProdAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public int TaxTypeId { get; set; }
        public string TaxTypeName { get; set; }
        public decimal FederalTaxAmount { get; set; }
        public decimal StateTaxAmount { get; set; }
        public decimal LocalTaxAmount { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int AssignedTo { get; set; }
        public string RouteName { get; set; }
        public DateTime CompletedDate { get; set; }
        public decimal CompletedAmount { get; set; }
        public short WoType { get; set; }
        public DateTime DeletedDate { get; set; }
        public int CancelReasonId { get; set; }
        public string CancelReasonDesc { get; set; }
        public DateTime SkippedDate { get; set; }
        public string SkipReason { get; set; }
        public string JobInstructions { get; set; }
        public int ScheduleTime { get; set; }
        public int TimeRangeId { get; set; }
        public string TimeOptionDesc { get; set; }
        public int Duration { get; set; }
    }
}
