using nh.health.domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nh.health.domain.Aggregates
{
    public class DoctorScheduleAggregateContext : IDoctorScheduleAggregateContext
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IPatientRepository _patientRepository;

        public DoctorScheduleAggregateContext(IScheduleRepository scheduleRepository, IPatientRepository patientRepository)
        {
            _scheduleRepository = scheduleRepository;
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<DoctorScheduleAggregate>> GetDoctorScheduleAggregatesAsync(DateTime appointmentDate, Guid doctorId, CancellationToken cancellationToken)
        {
            List<DoctorScheduleAggregate> doctorScheduleAggregates = new();
            var schedules = await _scheduleRepository.GetAllByDateByDoctorAsync(appointmentDate, doctorId, cancellationToken);
            if (schedules?.Any() ?? false)
            {
                foreach (var schedule in schedules)
                {
                    var scheduleAggregate = new DoctorScheduleAggregate
                    {
                        Schedule = schedule,
                        Patient = await _patientRepository.GetAsync(schedule.PatientId, cancellationToken)
                    };
                    doctorScheduleAggregates.Add(scheduleAggregate);
                }
            }
            return doctorScheduleAggregates;
        }
    }
}
