using AutoMapper;
using Mc2.CrudTest.Application.Dtos.Customer;
using Mc2.CrudTest.Domain.Aggregates.Customer;
using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands.Customer.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerWriteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerWriteRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.Email);

            var bankAccountNumber = BankAccountNumber.Create(request.BankAccountNumber);

            // Checking if a customer with the email address already exists.
            if (await _repository.ExistsByEmailAsync(email))
                throw new Exception("The provided email address is already in use.");

            var customer = new Domain.Aggregates.Customer.Customer(request.FirstName, request.LastName
                , request.PhoneNumber, bankAccountNumber, email, request.DateOfBirth);

            await _repository.AddAsync(customer);

            // Saving changes to the database and triggering events.
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
