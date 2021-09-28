namespace EmployeeManager.Services
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public int? Weight { get; set; }
        public int PositionId { get; set; }
    }
}