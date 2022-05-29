using Microsoft.EntityFrameworkCore;
using nh.health.infrastructure.dal.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nh.health.domain.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ICommandContext _commandContext;

        public PatientRepository(ICommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public async Task<IEnumerable<Entities.Patient>> GetAllAsync(CancellationToken cancellationToken)
        {
            var patients = await (from d in _commandContext.Patients.AsNoTracking()
                                  where d.IsDeactivated == false
                                  orderby d.LastName
                                  select new Entities.Patient
                                  {
                                      LastName = d.LastName,
                                      Email = d.Email,
                                      FirstName = d.FirstName,
                                      Id = d.Id,
                                  }).ToListAsync(cancellationToken).ConfigureAwait(false);
            return patients;
        }

        public async Task<Entities.Patient?> GetAsync(Guid patientId, CancellationToken cancellationToken)
        {
            var patient = await (from d in _commandContext.Patients.AsNoTracking()
                                 where d.IsDeactivated == false && d.Id == patientId
                                 select new Entities.Patient
                                 {
                                     LastName = d.LastName,
                                     Email = d.Email,
                                     FirstName = d.FirstName,
                                     Id = d.Id,
                                 }).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            return patient;
        }
    }
}
