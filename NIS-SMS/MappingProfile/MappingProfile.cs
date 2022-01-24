using AutoMapper;
using NIS.Models;
using NIS.ViewModel;

namespace NIS.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentNameWithDeptNameVM>()
                    .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.Name))
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                    .ReverseMap();

        }
    }
}
