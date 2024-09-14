using AutoMapper;
using MSTCore.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MSTAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //new
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
