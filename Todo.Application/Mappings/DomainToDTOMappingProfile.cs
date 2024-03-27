using AutoMapper;
using Todo.Application.DTOs;
using Todo.Domain.Entities;

namespace Todo.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User,UserDTO>().ReverseMap();
        CreateMap<Card,CardDTO>().ReverseMap();
    }
}
