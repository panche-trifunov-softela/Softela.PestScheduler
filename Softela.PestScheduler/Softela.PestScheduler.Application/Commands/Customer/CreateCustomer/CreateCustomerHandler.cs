using MediatR;
using Softela.PestScheduler.Application.Repositories;

namespace Softela.PestScheduler.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer
            {
                Id = 0,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid()
            };

            await _customerRepository.UpsertAsync(customer);
            return true;
        }
    }
}
