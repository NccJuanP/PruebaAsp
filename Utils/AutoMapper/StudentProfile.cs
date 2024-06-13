using AutoMapper;
using prueba.Models;
using prueba.Dtos;
namespace prueba.Utils.AutoMapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDto, Student>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}