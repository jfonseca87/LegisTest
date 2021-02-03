using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Business.Interfaces;
using Legis.Votaciones.Domain.Models;
using Legis.Votaciones.Repository.Interfaces;

namespace Legis.Votaciones.Business.Implementations
{
    public class CandidatoBusiness : ICandidatoBusiness
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoBusiness(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<IEnumerable<Candidatos>> ObtenerCandidatosVotacion(int idVotacion)
        {
            return await _candidatoRepository.ObtenerCandidatosVotacion(idVotacion);
        }
    }
}
