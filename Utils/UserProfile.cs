using AutoMapper;
using prueba.Models;
using prueba.Dtos;
namespace prueba.Utils
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<StudentDto, Student>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}