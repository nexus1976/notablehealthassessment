namespace nh.health.domain.Aggregates
{
    public interface IDoctorScheduleAggregateContext
    {
        Task<IEnumerable<DoctorScheduleAggregate>> GetDoctorScheduleAggregatesAsync(DateTime appointmentDate, Guid doctorId, CancellationToken cancellationToken);
    }
}