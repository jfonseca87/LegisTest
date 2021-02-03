using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legis.Votaciones.Business.Interfaces;
using Legis.Votaciones.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Legis.Votaciones.Client.Controllers
{
    public class VotacionController : Controller
    {
        private readonly IVotacionBusiness _votacionBusiness;
        private readonly ICandidatoBusiness _candidatoBusiness;

        public VotacionController(IVotacionBusiness votacionBusiness, ICandidatoBusiness candidatoBusiness)
        {
            _votacionBusiness = votacionBusiness;
            _candidatoBusiness = candidatoBusiness;
        }

        public async Task<IActionResult> Index() 
        {
            var votaciones = await _votacionBusiness.ObtenerEleccionesActivas();
            return View(votaciones);
        }

        public async Task<IActionResult> GenerarVotacion(int id)
        {
            ViewBag.Votacion = await _votacionBusiness.ObtenerEleccionPorId(id);
            ViewBag.Candidatos = await _candidatoBusiness.ObtenerCandidatosVotacion(id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerarVotacion(ResultadosElecciones votacion)
        {
            var result = await _votacionBusiness.GenerarVotacion(votacion);

            if (!result) 
               return View();

            return RedirectToAction("Index");
        }
    }
}
