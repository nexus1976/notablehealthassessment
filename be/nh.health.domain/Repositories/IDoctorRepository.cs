using nh.health.domain.Entities;

namespace nh.health.domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync(CancellationToken cancellationToken);
    }
}