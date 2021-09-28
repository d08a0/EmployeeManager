using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace EmployeeManager.Services
{
    public interface IEmployeeService
    {
        public Task<EmployeeDTO> GetEmployee(int id);
        public Task<List<EmployeeDTO>> GetAllEmployees();
        public Task<List<EmployeeDTO>> GetAllEmployees(EmployeeFilterDTO filterDTO);
        public Task<List<PositionDTO>> GetAllPositions();
        public Task<(ValidationResult, EmployeeDTO)> CreateEmployee(EmployeeDTO employeeDTO, CancellationToken token = default);
        public Task<ValidationResult> UpdateEmployee(EmployeeDTO employeeDTO, CancellationToken token = default);
        public Task<ValidationResult> DeleteEmployee(EmployeeDTO employeeDTO, CancellationToken token = default);
        public Task<int> MaxDisplayable(CancellationToken token = default);
        public Task<int> MaxDisplayable(EmployeeFilterDTO filterDTO, CancellationToken token = default);
    }
}