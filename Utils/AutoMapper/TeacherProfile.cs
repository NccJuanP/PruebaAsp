using AutoMapper;
using prueba.Models;
using prueba.Dtos;

namespace PruebaAsp.Utils.AutoMapper
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile(){
            CreateMap<TeacherDto, Teacher>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}