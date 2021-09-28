using System.Collections.Generic;

namespace EmployeeManager.Models
{
    public class Position
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public List<Employee> Employees { get; protected set; }
        protected Position()
        {
        }
        public Position(string name)
        {
            Name = name;
        }
    }
}