using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Legis.Votaciones.Domain.Models;

namespace Legis.Votaciones.Business.Interfaces
{
    public interface IVotacionBusiness
    {
        Task<IEnumerable<Elecciones>> ObtenerEleccionesActivas();
        Task<bool> GenerarVotacion(ResultadosElecciones votacion);
        Task<Elecciones> ObtenerEleccionPorId(int votacionId);
    }
}
