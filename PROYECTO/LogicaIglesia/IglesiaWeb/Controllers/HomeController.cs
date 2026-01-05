using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using IglesiaWeb.Models;
using System.Diagnostics;

namespace IglesiaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SistemaParroquialContext _context;

        public HomeController(ILogger<HomeController> logger, SistemaParroquialContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Verificar si el usuario está autenticado
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (!usuarioId.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Obtener estadísticas para el dashboard
            var totalCapillas = await _context.Capillas.CountAsync();
            var totalLaicos = await _context.Laicos.CountAsync(l => l.Activo);
            var totalMisasProximas = await _context.Misas
                .CountAsync(m => m.Estado == "Programada" && m.Fecha >= DateTime.Now);
            var totalRecaudadoMes = await _context.Misas
                .Where(m => m.Fecha.Month == DateTime.Now.Month && 
                           m.Fecha.Year == DateTime.Now.Year && 
                           m.MontoRecaudado.HasValue)
                .SumAsync(m => m.MontoRecaudado.Value);

            // Próximas misas
            var proximasMisas = await _context.Misas
                .Include(m => m.Capilla)
                .Include(m => m.Sacerdote)
                .Where(m => m.Estado == "Programada" && m.Fecha >= DateTime.Now)
                .OrderBy(m => m.Fecha)
                .Take(5)
                .ToListAsync();

            // Últimas solicitudes sacramentales
            var solicitudesPendientes = await _context.SolicitudesSacramentales
                .Include(s => s.Laico)
                .Where(s => s.Estado == "Pendiente")
                .OrderByDescending(s => s.FechaSolicitada)
                .Take(5)
                .ToListAsync();

            ViewBag.TotalCapillas = totalCapillas;
            ViewBag.TotalLaicos = totalLaicos;
            ViewBag.TotalMisasProximas = totalMisasProximas;
            ViewBag.TotalRecaudadoMes = totalRecaudadoMes;
            ViewBag.ProximasMisas = proximasMisas;
            ViewBag.SolicitudesPendientes = solicitudesPendientes;

            return View();
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
    }
}
