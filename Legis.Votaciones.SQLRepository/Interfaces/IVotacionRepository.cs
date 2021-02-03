using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;

namespace Legis.Votaciones.Repository.Interfaces
{
    public interface IVotacionRepository
    {
        Task<IEnumerable<Elecciones>> ObtenerEleccionesActivas();
        Task<Elecciones> ObtenerEleccionPorId(int votacionId);
        Task<bool> GenerarVotacion(ResultadosElecciones votacion);
    }
}
