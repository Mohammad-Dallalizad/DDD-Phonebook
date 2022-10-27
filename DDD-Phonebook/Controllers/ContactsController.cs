using ApplicationCore.Entities.ContacAggregate;
using ApplicationCore.Enums;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using AutoMapper;
using DDD_Phonebook.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DDD_Phonebook.Controllers;

public class ContactsController : BaseController
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;


    public ContactsController(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    [HttpGet("/GetAllContacts")]
    public async Task<ApiResponse<IList<ContactDto>>> GetAllContactsAsync(CancellationToken cancellationToken)
    {
        var contacts = await _contactService.GetAllContactsAsync(cancellationToken);
        var contactdtos = _mapper.Map<IList<ContactDto>>(contacts);
        return new ApiResponse<IList<ContactDto>>(true, ApiResultBodyCode.Success, contactdtos);
    }

    [HttpGet("/GetContactsByName")]
    public async Task<ApiResponse<ContactDto>> GetContactsByNameAsync([FromQuery, BindRequired] string name,CancellationToken cancellationToken)
    {
        var contact = await _contactService.GetContactByNameAsync(name,cancellationToken);
        var contactDto = _mapper.Map<ContactDto>(contact);
        return new ApiResponse<ContactDto>(true, ApiResultBodyCode.Success, contactDto);
    }

    [HttpPost]
    public async Task<ApiResponse> CreateContactAsync(ContactCreateOrUpdateDto contactDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();

            throw new BadRequestException("Model validation errors occured.", errors);
        }


        Address address = new(contactDto.Address.Country, contactDto.Address.City, contactDto.Address.Street, contactDto.Address.PostalCode);
        var phones = contactDto.Phones.Select(p =>
        {
            var phone = new Phone(p.PhoneNumber, p.Lable);
            return phone;
        }).ToList();

        await _contactService.CreateContactAsync(contactDto.Firstname, contactDto.Lastname, contactDto.Companyname, contactDto.Email, contactDto.Birthdate, address, phones, cancellationToken);

        return new ApiResponse(true, ApiResultBodyCode.Success);
    }

    [HttpDelete("{contactId:int:min(1)}")]
    public async Task<ApiResponse> DeleteContactAsync(int contactId, CancellationToken cancellationToken)
    {
        await _contactService.DeleteContactAsync(contactId, cancellationToken);
        return new ApiResponse(true, ApiResultBodyCode.Success);
    }

    [HttpPut("{contactId:int:min(1)}")]
    public async Task<ApiResponse> UpdateContactAsync(int contactId, ContactCreateOrUpdateDto contactDto, CancellationToken cancellationToken)
    {
        Address address = new(contactDto.Address.Country, contactDto.Address.City, contactDto.Address.Street, contactDto.Address.PostalCode);
        var phones = contactDto.Phones.Select(p =>
        {
            var phone = new Phone(p.PhoneNumber, p.Lable);
            return phone;
        }).ToList();

        await _contactService.UpdateContactAsync(contactId, contactDto.Firstname, contactDto.Lastname, contactDto.Companyname, contactDto.Email, contactDto.Birthdate, address, phones, cancellationToken);
            
        return new ApiResponse(true, ApiResultBodyCode.Success);
    }

}
