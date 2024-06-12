using AutoMapper;
using prueba.Models;
using prueba.Dtos;
namespace prueba.Extras
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<StudentDto, Student>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}