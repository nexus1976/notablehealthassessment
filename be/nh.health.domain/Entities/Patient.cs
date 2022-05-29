namespace nh.health.domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public override string ToString()
        {
            var fullName = ((FirstName ?? string.Empty).Trim() + " " + (LastName ?? string.Empty).Trim()).Trim();
            return fullName;
        }
    }
}
