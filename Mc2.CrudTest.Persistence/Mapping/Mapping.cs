using AutoMapper;
using Mc2.CrudTest.Domain.Customer;

namespace Mc2.CrudTest.Persistence.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, Entities.Customer>().ReverseMap();
        }
    }
}