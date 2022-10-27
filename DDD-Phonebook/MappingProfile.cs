using ApplicationCore.Entities.ContacAggregate;
using AutoMapper;
using DDD_Phonebook.Dtos;

namespace DDD_Phonebook;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDto>();
        
        CreateMap<Phone, PhoneDto>().ForMember(dest => dest.Lable, src => src.MapFrom(p => p.Lable.ToString()));
        
        CreateMap<Contact, ContactDto>();
    }
}
