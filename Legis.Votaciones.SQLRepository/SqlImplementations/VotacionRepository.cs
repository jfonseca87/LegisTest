using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;
using Legis.Votaciones.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Legis.Votaciones.Repository.SqlImplementations
{
    public class VotacionRepository : IVotacionRepository
    {
        private readonly VotacionesdbContext _db;

        public VotacionRepository(VotacionesdbContext db)
        {
            _db = db;
        }

        public async Task<bool> GenerarVotacion(ResultadosElecciones votacion)
        {
            _db.ResultadosElecciones.Add(votacion);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Elecciones>> ObtenerEleccionesActivas()
        {
            return await _db.Elecciones
                .Where(x => x.Activa == true)
                .ToListAsync();
        }

        public async Task<Elecciones> ObtenerEleccionPorId(int votacionId)
        {
            return await _db.Elecciones.FirstOrDefaultAsync(x => x.EleccionId == votacionId);
        }

    }
}
