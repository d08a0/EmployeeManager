using EmployeeManager.Validators;
using FluentValidation.Results;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Id { get; protected set; }
        public string LastName { get; protected set; }
        public int? Weight { get; protected set; }
        public int PositionId { get; protected set; }
        public Position Position { get; protected set; }

        protected Employee()
        {
        }
        protected Employee(string lastName, int? weight, int positionId)
        {
            LastName = lastName;
            Weight = weight;
            PositionId = positionId;
        }
        public static ValidationResult TryCreate(string lastName, int? weight, int positionId, out Employee emp)
        {
            var validator = new EmployeeValidator();
            var model = new Employee(lastName, weight, positionId);
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                emp = model;
            }
            else
            {
                emp = null;
            }
            return result;
        }
    }
}