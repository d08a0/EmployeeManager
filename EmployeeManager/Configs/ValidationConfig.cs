namespace EmployeeManager.Configs
{
    public class ValidationConfig
    {
        public ValidationConfig()
        {
            Enabled = true;
        }

        public ValidationConfig(bool enabled)
        {
            Enabled = enabled;
        }


        public bool Enabled { get; set; }
    }
}