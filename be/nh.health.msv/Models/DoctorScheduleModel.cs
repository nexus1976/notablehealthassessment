namespace nh.health.msv.Models
{
    public class DoctorScheduleModel
    {
        public int AppointmentNumber { get; set; }
        public string? PatientName { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public domain.Entities.PatientAppointmentType? AppointmentType { get; set; }
    }
}
