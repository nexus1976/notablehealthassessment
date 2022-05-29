using nh.health.domain.Entities;

namespace nh.health.domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken);
        Task<Patient?> GetAsync(Guid patientId, CancellationToken cancellationToken);
    }
}