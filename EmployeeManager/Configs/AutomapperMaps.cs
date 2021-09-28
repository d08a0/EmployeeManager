using AutoMapper;
using EmployeeManager.Models;
using EmployeeManager.Services;
using EmployeeManager.Specification;
using EmployeeManager.ViewModels;

namespace EmployeeManager.Configs
{
    public class AutomapperMaps : Profile
    {
        public AutomapperMaps()
        {
            CreateMap<BaseFilterDTO, BaseFilter>()
                .IncludeAllDerived().ReverseMap();
            CreateMap<EmployeeFilterDTO, EmployeeFilter>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();

            CreateMap<EmployeeVM, EmployeeDTO>().ReverseMap();
        }
    }
}