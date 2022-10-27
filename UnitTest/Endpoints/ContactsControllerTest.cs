using ApplicationCore.Entities.ContacAggregate;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using AutoMapper;
using DDD_Phonebook;
using DDD_Phonebook.Controllers;
using DDD_Phonebook.Dtos;
using FluentAssertions;
using Moq;

namespace UnitTest.Endpoints;

public class ContactsControllerTest
{
    private readonly Mock<IContactService> _contactService;
    private readonly IMapper _mapper;

    public ContactsControllerTest()
    {
        _contactService = new Mock<IContactService>();
        _mapper = GetAutoMapper();
    }

    public static Mapper GetAutoMapper()
    {
        var mappingProfiles = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfiles));
        return new Mapper(configuration);
    }

    [Fact]
    public async Task GetAllContacts()
    {
        //arrange
        var contactlist = GetContactsData();
        var contactDtolist = GetContactDtosList();
        _contactService.Setup(x => x.GetAllContactsAsync(default)).ReturnsAsync(contactlist);
        var contactController = new ContactsController(_contactService.Object, GetAutoMapper());

        //act
        var response = await contactController.GetAllContactsAsync(default);
        var apiResult = response.Data;
        
        //assert
        apiResult.Should().NotBeNull();
        apiResult.Should().BeEquivalentTo(contactDtolist);
    }
    private List<ContactDto> GetContactDtosList()
    {
        var contacts = GetContactsData();
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    private List<Contact> GetContactsData()
    {
        var birthdate = new DateTime(1998, 1, 27);
        List<Contact> contacts = new()
        {
            new Contact("mohammad","dallalizad",null,"mdallalizad@gmail.com",birthdate,new Address("Iran","Tehran","Boostan","14235678"),new List<Phone>{new Phone("09123456213", (PhoneLable)1),new Phone("0912452875", (PhoneLable)1) }),

            new Contact("alireza","dallalizad",null,"alireza@gmail.com",birthdate,new Address("Iran","Tehran","sadeqie","987654312"),new List<Phone>{new Phone("09135678341", (PhoneLable)1),new Phone("02199086316", (PhoneLable)2) }),

            new Contact("yaser","gholami",null,"gholami@gmail.com",birthdate,new Address("spain","madrid","123-ad","98624"),new List<Phone>{new Phone("0319863343", (PhoneLable)1),new Phone("0216543734", (PhoneLable)1) }),
        };

        return contacts;
    }
}
