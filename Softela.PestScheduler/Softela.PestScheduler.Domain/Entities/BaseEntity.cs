
namespace Softela.PestScheduler.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
