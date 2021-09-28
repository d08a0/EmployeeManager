namespace EmployeeManager.Services
{
    public class EmployeeFilterDTO : BaseFilterDTO
    {
        private int? positionId;

        public int? PositionId
        {
            get => positionId;
            set => positionId = value;
        }
    }
}