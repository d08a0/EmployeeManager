using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.Configs;
using EmployeeManager.Models;
using EmployeeManager.Repository;
using EmployeeManager.Specification;
using EmployeeManager.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace EmployeeManager.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<Employee> _employeesRepository;
        protected readonly IRepository<Position> _positionsRepository;
        protected readonly AbstractValidator<Employee> _validator;
        public EmployeeService(IMapper mapper, IRepository<Employee> employeesRepository,
        IRepository<Position> positionsRepository, ValidationConfig config)
        {
            _mapper = mapper;
            _employeesRepository = employeesRepository;
            _positionsRepository = positionsRepository;
            if (config.Enabled)
            {
                _validator = new EmployeeValidator();
            }
            else _validator = new NoopValidator<Employee>();
        }


        public async Task<(ValidationResult, EmployeeDTO)> CreateEmployee(EmployeeDTO employeeDTO, CancellationToken token = default)
        {
            var output = await WithValidation(employeeDTO,
                async e => await _employeesRepository.AddAsync(e, token));
            return (output.Item1, _mapper.Map<EmployeeDTO>(output.Item2));
        }

        public async Task<ValidationResult> DeleteEmployee(EmployeeDTO employeeDTO, CancellationToken token = default)
        {
            var output = await WithValidation(employeeDTO,
                async e => await _employeesRepository.DeleteAsync(e, token));
            return output;
        }
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _employeesRepository
                .GetBySpecAsync(new EmployeeByIdSpecification(id));
            return _mapper.Map<EmployeeDTO>(employee);
        }
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeesRepository.ListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees(EmployeeFilterDTO filterDTO)
        {
            filterDTO = filterDTO ?? new EmployeeFilterDTO();
            var spec = new EmployeeSpecification(_mapper.Map<EmployeeFilter>(filterDTO));
            var employees = await _employeesRepository.ListAsync(spec);
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<List<PositionDTO>> GetAllPositions()
        {
            var positions = await _positionsRepository.ListAsync();
            return _mapper.Map<List<PositionDTO>>(positions);
        }

        public async Task<ValidationResult> UpdateEmployee(EmployeeDTO employeeDTO, CancellationToken token = default)
        {
            var output = await WithValidation(employeeDTO,
                async e => await _employeesRepository.UpdateAsync(e, token));
            return output;
        }
        public async Task<int> MaxDisplayable(CancellationToken token = default)
        {
            return await _employeesRepository.CountAsync(token);
        }
        public async Task<int> MaxDisplayable(EmployeeFilterDTO filterDTO, CancellationToken token = default)
        {
            filterDTO = filterDTO ?? new EmployeeFilterDTO();
            var spec = new EmployeeSpecification(_mapper.Map<EmployeeFilter>(filterDTO));

            return await _employeesRepository.CountAsync(spec, token);
        }
        private async Task<(ValidationResult, TResult)> WithValidation<TResult>
            (EmployeeDTO dto, Func<Employee, Task<TResult>> func)
        {
            var model = _mapper.Map<Employee>(dto);
            var output = await Validator.ValidateAsync
                (_validator, model, func);
            return output;
        }
        private async Task<ValidationResult> WithValidation(EmployeeDTO dto, Func<Employee, Task> func)
        {
            var model = _mapper.Map<Employee>(dto);
            var output = await Validator.ValidateAsync
                (_validator, model, func);
            return output;
        }
    }
    class NoopValidator<T> : AbstractValidator<T>
    {
        public NoopValidator()
        {
        }
    }
}