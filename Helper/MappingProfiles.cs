using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Model;

namespace EastCoastEducation.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
