using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPCBusinessSolution.Api;
using OPCBusinessSolution.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OPCBusinessSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MonitorBucklandContext _context;
        private readonly ApiService _apiService;

        public HomeController(ILogger<HomeController> logger, MonitorBucklandContext context, ApiService apiService)
        {
            _logger = logger;
            _context = context;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(DateTime? FechaInicio, DateTime? FechaFin)
        {
            var mbPedimentos = await ApplyFilter(FechaInicio, FechaFin);
            // 1 = EXPO, 0 = IMPO
            return View(mbPedimentos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> AutoUpdate(bool AutoUpdateBit)
        {
            if (AutoUpdateBit)
            {
                // implement an auto update function

                ViewBag.AutoUpdate = true;
            }
            return View("Home");
        }

        private async Task<ICollection<Mbpedimento>> ApplyFilter(DateTime? FechaInicio, DateTime? FechaFin)
        {
            //if (FechaFin == null)
            //{
            //    //return (ICollection<Mbpedimento>)await _context.Mbpedimentos.Where(p => p.TiempoReciboBgts.Date == FechaInicio)
            //    //    .ToListAsync();
            //}
            //else
            //{
            //    ViewBag.FechaFin = FechaFin;
            //    //return (ICollection<Mbpedimento>)await _context.Mbpedimentos
            //    //    .Where(p => p.TiempoReciboBgts.Date >= FechaInicio 
            //    //        && p.TiempoReciboBgts.Date <= FechaFin)
            //    //    .ToListAsync();
            //}

            var queryParams = new Dictionary<string, string>();

            if (FechaInicio.HasValue)
            {
                ViewBag.FechaInicio = FechaInicio;
                queryParams.Add("FechaInicio", FechaInicio.Value.ToString("yyyy-MM-dd"));
            }

            if (FechaFin.HasValue)
            {
                ViewBag.FechaFin = FechaFin;
                queryParams.Add("FechaFin", FechaFin.Value.ToString("yyyy-MM-dd"));
            }

            var mbPedimento = await _apiService.GetAsync<ICollection<Mbpedimento>>("MocklandMonitor", queryParams);
            return mbPedimento;
        }
    }
}
