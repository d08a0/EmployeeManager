using EmployeeManager.Models;
using FluentValidation;

namespace EmployeeManager.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.PositionId).NotEmpty();
        }
    }

}