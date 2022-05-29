using Microsoft.EntityFrameworkCore;
using nh.health.infrastructure.dal.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nh.health.domain.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ICommandContext _commandContext;

        public DoctorRepository(ICommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public async Task<IEnumerable<Entities.Doctor>> GetAllAsync(CancellationToken cancellationToken)
        {
            var doctors = await (from d in _commandContext.Doctors.AsNoTracking()
                                 where d.IsDeactivated == false
                                 orderby d.LastName
                                 select new Entities.Doctor
                                 {
                                     LastName = d.LastName,
                                     Email = d.Email,
                                     FirstName = d.FirstName,
                                     FullTitle = d.FullTitle,
                                     Id = d.Id,
                                     OfficePhone = d.OfficePhone
                                 }).ToListAsync(cancellationToken).ConfigureAwait(false);
            return doctors;
        }
    }
}
