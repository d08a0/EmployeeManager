using System;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace EmployeeManager.Validators
{
    public static class Validator
    {

        public static async Task<(ValidationResult, TReturn)> ValidateAsync<TModel, TReturn>
        (AbstractValidator<TModel> validator, TModel model, Func<TModel, Task<TReturn>> operation)
        {
            var ex = validator.Validate(model);
            if (!ex.IsValid)
            {
                return (ex, default(TReturn));
            }
            else
            {
                return (null, await operation(model));
            }
        }
        public static async Task<ValidationResult> ValidateAsync<TModel>
        (AbstractValidator<TModel> validator, TModel model, Func<TModel, Task> operation)
        {
            var ex = validator.Validate(model);
            if (!ex.IsValid)
            {
                return ex;
            }
            else
            {
                await operation(model);
                return ex;
            }
        }

    }
}