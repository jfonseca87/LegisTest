using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Business.Interfaces;
using Legis.Votaciones.Domain.Models;
using Legis.Votaciones.Repository.Interfaces;

namespace Legis.Votaciones.Business.Implementations
{
    public class VotacionBusiness : IVotacionBusiness
    {
        private readonly IVotacionRepository _votacionRepository;

        public VotacionBusiness(IVotacionRepository votacionRepository)
        {
            _votacionRepository = votacionRepository;
        }

        public async Task<bool> GenerarVotacion(ResultadosElecciones votacion)
        {
            return await _votacionRepository.GenerarVotacion(votacion);
        }

        public async Task<IEnumerable<Elecciones>> ObtenerEleccionesActivas()
        {
            return await _votacionRepository.ObtenerEleccionesActivas();
        }

        public async Task<Elecciones> ObtenerEleccionPorId(int votacionId)
        {
            return await _votacionRepository.ObtenerEleccionPorId(votacionId);
        }
    }
}
