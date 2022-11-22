using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

namespace UP_TAP_LicenciasConducir.Infrastructure.Repositories
{
    public class MedicalRevisionRepository : BaseRepository<MedicalRevision>, IMedicalRevisionRepository
    {
        public MedicalRevisionRepository(LicenciasConducirDataContext context) : base(context)
        {
        }

        public IEnumerable<MedicalRevision> GetAllPending()
        {
            return _entities.Include(x=> x.MedicalShift).Where(x=> x.IsPassed == null && x.MedicalShift.StartDate >= DateTime.Today).AsEnumerable();
        }

    }
}

