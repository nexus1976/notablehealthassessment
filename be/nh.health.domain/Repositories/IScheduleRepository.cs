using nh.health.domain.Entities;

namespace nh.health.domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllByDateByDoctorAsync(DateTime scheduleDate, Guid doctorId, CancellationToken cancellationToken);
    }
}