using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;

namespace Legis.Votaciones.Business.Interfaces
{
    public interface ICandidatoBusiness
    {
        Task<IEnumerable<Candidatos>> ObtenerCandidatosVotacion(int idVotacion);
    }
}
