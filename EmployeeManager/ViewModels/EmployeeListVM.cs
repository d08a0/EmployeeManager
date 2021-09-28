using System.Collections.Generic;
using EmployeeManager.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.ViewModels
{

    public class EmployeeListVM
    {
        public List<EmployeeDTO> Employees { get; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public SelectList Positions { get; }
        public int PositionId { get; set; } = -1;
        public int MaxPage { get; set; }


        public EmployeeListVM(List<EmployeeDTO> employees, SelectList positions, int maxPage)
        {
            Employees = employees;
            Positions = positions;
            MaxPage = maxPage;
        }
    }

}