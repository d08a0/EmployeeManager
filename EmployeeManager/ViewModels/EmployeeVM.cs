using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public int? Weight { get; set; }

        public int PositionId { get; set; }
        public bool Edit { get; set; }
        public SelectList Positions { get; set; }
    }

}