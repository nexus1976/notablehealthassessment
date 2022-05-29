using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nh.health.domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public PatientAppointmentType AppointmentType { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
