using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nh.health.domain.Repositories;
using nh.health.domain.Aggregates;
using nh.health.domain.Entities;
using nh.health.msv.Models;

namespace nh.health.msv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorScheduleAggregateContext _doctorScheduleAggregateContext;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorRepository doctorRepository, IDoctorScheduleAggregateContext doctorScheduleAggregateContext)
        {
            this.logger = logger;
            _doctorRepository = doctorRepository;
            _doctorScheduleAggregateContext = doctorScheduleAggregateContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync(cancellationToken);
            return Ok(doctors);
        }

        [HttpGet("{id}/schedule/{appointmentDate}")]
        public async Task<IActionResult> GetSchedulesAsync([FromRoute] Guid id, [FromRoute] DateTime appointmentDate, CancellationToken cancellationToken)
        {
            var scheduleAggregates = await _doctorScheduleAggregateContext.GetDoctorScheduleAggregatesAsync(appointmentDate, id, cancellationToken);
            List<DoctorScheduleModel> doctorScheduleAggregates = new();
            if (scheduleAggregates?.Any() ?? false)
            {
                int i = 1;
                foreach (var item in scheduleAggregates)
                {
                    doctorScheduleAggregates.Add(new DoctorScheduleModel
                    {
                        AppointmentDateTime = item.Schedule?.AppointmentDateTime,
                        AppointmentNumber = i++,
                        AppointmentType = item.Schedule?.AppointmentType,
                        PatientName = item.Patient?.ToString()
                    });
                }
            }
            return Ok(doctorScheduleAggregates);
        }
    }
}
