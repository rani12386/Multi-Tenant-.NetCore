using AutoMapper;
using MT.Models;
using MT_Data.Entities;

namespace MT.Profiles;
public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeViewModel, Employee>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        //.ForPath(dest => dest.DepartmentName,
        //   opt => opt.MapFrom(src => src.Department.Name)); //here the dest is represents viewmodel and the src represents entity.
    }
}
