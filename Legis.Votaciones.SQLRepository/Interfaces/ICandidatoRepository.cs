using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;

namespace Legis.Votaciones.Repository.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidatos>> ObtenerCandidatosVotacion(int idVotacion);
    }
}
