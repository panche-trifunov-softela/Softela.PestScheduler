using MediatR;

namespace Softela.PestScheduler.Application.Commands.Customer.CreateCustomer
{
    public sealed record CreateCustomerRequest : IRequest<bool>
    {
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
