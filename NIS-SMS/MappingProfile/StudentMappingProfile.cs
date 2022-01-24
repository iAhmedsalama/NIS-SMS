using AutoMapper;
using NIS.Models;
using NIS.ViewModel;

namespace NIS.MappingProfile
{
    public class StudentMappingProfile:Profile
    {
        public StudentMappingProfile()
        {
            //CreateMap<Trainee, StudentWithCrsResult>()
            //    .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.StudentDegree, opt => opt.MapFrom(src => src.Grade))
            //    .ReverseMap();

            //CreateMap<Course, StudentWithCrsResult>()
            //    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name))
            //    .ReverseMap();
        }


    }
}
