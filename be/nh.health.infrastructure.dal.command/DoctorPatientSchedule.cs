namespace nh.health.infrastructure.dal.command
{
    public class DoctorPatientSchedule
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public short PatientType { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
