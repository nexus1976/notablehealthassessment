using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace nh.health.infrastructure.dal.command
{
    public interface ICommandContext: IDisposable, IAsyncDisposable
    {
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<DoctorPatientSchedule> DoctorPatientSchedules { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}