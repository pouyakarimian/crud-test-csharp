using AutoMapper;
using Mc2.CrudTest.Application.Dtos.Customer;

namespace Mc2.CrudTest.Application.Features.Commands.Customer
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Domain.Aggregates.Customer.Customer, CustomerDto>().ReverseMap();
        }
    }
}
