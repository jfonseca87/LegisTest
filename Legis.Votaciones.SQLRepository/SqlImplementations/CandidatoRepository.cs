using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;
using Legis.Votaciones.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Legis.Votaciones.Repository.SqlImplementations
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly VotacionesdbContext _db;

        public CandidatoRepository(VotacionesdbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Candidatos>> ObtenerCandidatosVotacion(int idVotacion)
        {
            return await (from c in _db.Candidatos
                          join ec in _db.EleccionesCandidatos on c.CandidatoId equals ec.CandidatoId
                          where ec.EleccionId == idVotacion
                          select c).ToListAsync();
        }
    }
}
