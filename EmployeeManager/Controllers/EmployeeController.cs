using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.Services;
using EmployeeManager.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index
        ([FromQuery] EmployeeFilterDTO filter)
        {
            filter ??= new EmployeeFilterDTO();
            var positionId = filter.PositionId ?? -1;
            if (filter.PositionId == -1)
            {
                filter.PositionId = null;
            }
            var employees = await _employeeService.GetAllEmployees(filter);
            var positions = await _employeeService.GetAllPositions();
            positions = positions.Prepend(new PositionDTO() { Id = -1, Name = "Не выбрано" }).ToList();
            var positionsList = new SelectList(positions, nameof(PositionDTO.Id),
                nameof(PositionDTO.Name), filter.PositionId);
            var totalItem = await _employeeService.MaxDisplayable(filter);
            var maxPage = (int)Math.Ceiling((float)totalItem / filter.PageSize);
            var model = new EmployeeListVM(employees, positionsList, maxPage)
            {
                PageSize = filter.PageSize,
                Page = filter.Page,
                PositionId = positionId

            };
            return View(model: model);

        }
        [HttpGet("upsert/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            EmployeeVM vm;
            if (id == null)
            {
                vm = new EmployeeVM()
                {
                    Edit = false
                };
            }
            else
            {
                var employee = await _employeeService.GetEmployee((int)id);
                if (employee == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                vm = _mapper.Map<EmployeeVM>(employee);
                vm.Edit = true;
            }
            vm.Positions = new SelectList(await _employeeService.GetAllPositions(),
            nameof(PositionDTO.Id), nameof(PositionDTO.Name), vm.PositionId);
            return View(model: vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM vm)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<EmployeeDTO>(vm);
                ValidationResult validation;
                if (vm.Edit == false)
                {
                    (validation, employee) = await _employeeService.CreateEmployee(employee);
                }
                else
                {
                    validation = await _employeeService.UpdateEmployee(employee);
                }
                if (validation == null)
                {
                    return RedirectToAction(nameof(Edit), new { id = employee.Id });
                }
            }

            vm.Positions = new SelectList(await _employeeService.GetAllPositions(),
                nameof(PositionDTO.Id), nameof(PositionDTO.Name));
            return View(nameof(Edit), model: vm);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var employee = await _employeeService.GetEmployee(id);
                await _employeeService.DeleteEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }

}

