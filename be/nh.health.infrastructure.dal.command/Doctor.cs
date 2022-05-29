namespace nh.health.infrastructure.dal.command
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string? FullTitle { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
