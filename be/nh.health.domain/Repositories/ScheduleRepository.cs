using Microsoft.EntityFrameworkCore;
using nh.health.infrastructure.dal.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nh.health.domain.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ICommandContext _commandContext;

        public ScheduleRepository(ICommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public async Task<IEnumerable<Entities.Schedule>> GetAllByDateByDoctorAsync(DateTime scheduleDate, Guid doctorId, CancellationToken cancellationToken)
        {
            var schedules = await (from s in _commandContext.DoctorPatientSchedules.AsNoTracking()
                                   where s.DoctorId == doctorId 
                                    && s.AppointmentDateTime.Year == scheduleDate.Year && s.AppointmentDateTime.Month == scheduleDate.Month 
                                    && s.AppointmentDateTime.Day == scheduleDate.Day
                                   orderby s.AppointmentDateTime
                                   select new Entities.Schedule
                                   {
                                       Id = s.Id,
                                       AppointmentDateTime = s.AppointmentDateTime,
                                       DoctorId = s.DoctorId,
                                       PatientId = s.PatientId,
                                       AppointmentType = s.PatientType == 1 ? Entities.PatientAppointmentType.NewPatient : Entities.PatientAppointmentType.FollowUp
                                   }).ToListAsync(cancellationToken).ConfigureAwait(false);
            return schedules;
        }
    }
}
