using EmployeeManager.ViewModels;
using FluentValidation;

namespace EmployeeManager.Validators
{
    public class EmployeeVMValidator : AbstractValidator<EmployeeVM>
    {
        public EmployeeVMValidator()
        {
            RuleFor(emp => emp.Id)
                .GreaterThan(0)
                .When(vm => vm.Edit);

            RuleFor(vm => vm.Id)
                .Empty()
                .When(vm => !vm.Edit);

            RuleFor(vm => vm.LastName)
                .NotEmpty()
                .WithMessage("Укажите имя");

            RuleFor(vm => vm.Weight)
                .ExclusiveBetween(20, 400)
                .WithMessage("Вес вне рамок")
                .When(vm => vm.Weight != 0);

            RuleFor(vm => vm.PositionId)
                .NotEmpty()
                .WithMessage("Укажите должность");

        }
    }
}