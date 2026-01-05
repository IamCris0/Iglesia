using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using SistemaParroquial.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaParroquial.Controllers
{
    /// <summary>
    /// Controlador para gestionar las Misas del sistema
    /// </summary>
    public class MisaController : Controller
    {
        private readonly SistemaParroquialContext _context;

        public MisaController(SistemaParroquialContext context)
        {
            _context = context;
        }

        // GET: Misa
        /// <summary>
        /// Lista todas las misas ordenadas por fecha
        /// </summary>
        public async Task<IActionResult> Index(string filtro, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var misas = _context.Misas
                .Include(m => m.Capilla)
                .Include(m => m.Sacerdote)
                .Include(m => m.SolicitudSacramental)
                .AsQueryable();

            // Filtro por texto
            if (!string.IsNullOrEmpty(filtro))
            {
                misas = misas.Where(m => m.Capilla.Nombre.Contains(filtro) || 
                                        m.Estado.Contains(filtro));
            }

            // Filtro por rango de fechas
            if (fechaInicio.HasValue)
            {
                misas = misas.Where(m => m.Fecha >= fechaInicio.Value);
            }

            if (fechaFin.HasValue)
            {
                misas = misas.Where(m => m.Fecha <= fechaFin.Value);
            }

            // Ordenar por fecha descendente
            misas = misas.OrderByDescending(m => m.Fecha);

            return View(await misas.ToListAsync());
        }

        // GET: Misa/Details/5
        /// <summary>
        /// Muestra los detalles de una misa específica
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misa = await _context.Misas
                .Include(m => m.Capilla)
                .Include(m => m.Sacerdote)
                .Include(m => m.SolicitudSacramental)
                    .ThenInclude(s => s.Laico)
                .FirstOrDefaultAsync(m => m.IdMisa == id);

            if (misa == null)
            {
                return NotFound();
            }

            return View(misa);
        }

        // GET: Misa/Create
        /// <summary>
        /// Muestra el formulario para crear una nueva misa
        /// </summary>
        public IActionResult Create()
        {
            CargarListasSeleccion();
            return View(new Misa { Fecha = DateTime.Now });
        }

        // POST: Misa/Create
        /// <summary>
        /// Procesa la creación de una nueva misa
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCapilla,IdSacerdote,Fecha,MontoRecaudado,Estado,IdSolicitudSacramental")] Misa misa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(misa);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Misa creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            CargarListasSeleccion(misa);
            return View(misa);
        }

        // GET: Misa/Edit/5
        /// <summary>
        /// Muestra el formulario para editar una misa
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misa = await _context.Misas.FindAsync(id);
            if (misa == null)
            {
                return NotFound();
            }
            CargarListasSeleccion(misa);
            return View(misa);
        }

        // POST: Misa/Edit/5
        /// <summary>
        /// Procesa la edición de una misa
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMisa,IdCapilla,IdSacerdote,Fecha,MontoRecaudado,Estado,IdSolicitudSacramental")] Misa misa)
        {
            if (id != misa.IdMisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(misa);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Misa actualizada exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MisaExists(misa.IdMisa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CargarListasSeleccion(misa);
            return View(misa);
        }

        // GET: Misa/Delete/5
        /// <summary>
        /// Muestra la confirmación para eliminar una misa
        /// </summary>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misa = await _context.Misas
                .Include(m => m.Capilla)
                .Include(m => m.Sacerdote)
                .FirstOrDefaultAsync(m => m.IdMisa == id);

            if (misa == null)
            {
                return NotFound();
            }

            return View(misa);
        }

        // POST: Misa/Delete/5
        /// <summary>
        /// Procesa la eliminación de una misa
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var misa = await _context.Misas.FindAsync(id);
            if (misa != null)
            {
                _context.Misas.Remove(misa);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Misa eliminada exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Misa/RegistrarRecaudacion/5
        /// <summary>
        /// Muestra el formulario para registrar la recaudación de una misa
        /// </summary>
        public async Task<IActionResult> RegistrarRecaudacion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misa = await _context.Misas
                .Include(m => m.Capilla)
                .FirstOrDefaultAsync(m => m.IdMisa == id);

            if (misa == null)
            {
                return NotFound();
            }

            return View(misa);
        }

        // POST: Misa/RegistrarRecaudacion/5
        /// <summary>
        /// Procesa el registro de recaudación
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarRecaudacion(int id, decimal montoRecaudado)
        {
            var misa = await _context.Misas.FindAsync(id);
            if (misa == null)
            {
                return NotFound();
            }

            if (montoRecaudado < 0)
            {
                ModelState.AddModelError("", "El monto debe ser positivo");
                return View(misa);
            }

            misa.MontoRecaudado = montoRecaudado;
            misa.Estado = EstadoMisa.Realizada;
            
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Recaudación registrada exitosamente.";
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // GET: Misa/GenerarAutomatico
        /// <summary>
        /// Muestra el formulario para generar misas automáticamente
        /// </summary>
        public IActionResult GenerarAutomatico()
        {
            return View();
        }

        // POST: Misa/GenerarAutomatico
        /// <summary>
        /// Genera misas automáticamente basado en los horarios configurados
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerarAutomatico(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                ModelState.AddModelError("", "La fecha de inicio debe ser anterior a la fecha de fin");
                return View();
            }

            try
            {
                // Obtener todos los horarios activos
                var horarios = await _context.HorariosMisa
                    .Where(h => h.Activo == "SI")
                    .Include(h => h.Capilla)
                    .ToListAsync();

                int misasCreadas = 0;
                DateTime fechaActual = fechaInicio.Date;

                while (fechaActual <= fechaFin.Date)
                {
                    int diaSemana = (int)fechaActual.DayOfWeek;

                    // Buscar horarios para este día
                    var horariosDelDia = horarios.Where(h => h.DiaSemana == diaSemana);

                    foreach (var horario in horariosDelDia)
                    {
                        // Combinar fecha y hora
                        DateTime fechaHoraMisa = fechaActual.Date.Add(horario.Hora);

                        // Verificar si ya existe una misa para esta capilla en esta fecha/hora
                        bool existeMisa = await _context.Misas
                            .AnyAsync(m => m.IdCapilla == horario.IdCapilla && m.Fecha == fechaHoraMisa);

                        if (!existeMisa)
                        {
                            var nuevaMisa = new Misa
                            {
                                IdCapilla = horario.IdCapilla,
                                Fecha = fechaHoraMisa,
                                Estado = EstadoMisa.Programada
                            };

                            _context.Misas.Add(nuevaMisa);
                            misasCreadas++;
                        }
                    }

                    fechaActual = fechaActual.AddDays(1);
                }

                await _context.SaveChangesAsync();

                TempData["Mensaje"] = $"Se generaron {misasCreadas} misas exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al generar misas: {ex.Message}");
                return View();
            }
        }

        /// <summary>
        /// Verifica si existe una misa con el ID dado
        /// </summary>
        private bool MisaExists(int id)
        {
            return _context.Misas.Any(e => e.IdMisa == id);
        }

        /// <summary>
        /// Carga las listas de selección para los dropdowns
        /// </summary>
        private void CargarListasSeleccion(Misa misa = null)
        {
            ViewData["IdCapilla"] = new SelectList(_context.Capillas, "IdCapilla", "Nombre", misa?.IdCapilla);
            
            ViewData["IdSacerdote"] = new SelectList(
                _context.Sacerdotes.Select(s => new { s.IdSacerdote, NombreCompleto = s.Nombres + " " + s.Apellidos }),
                "IdSacerdote",
                "NombreCompleto",
                misa?.IdSacerdote
            );

            ViewData["IdSolicitudSacramental"] = new SelectList(
                _context.SolicitudesSacramentales
                    .Include(s => s.Laico)
                    .Where(s => s.Estado == "Aprobada")
                    .Select(s => new { s.IdSolicitudSacramental, Descripcion = s.Sacramento + " - " + s.Laico.Nombres }),
                "IdSolicitudSacramental",
                "Descripcion",
                misa?.IdSolicitudSacramental
            );

            ViewData["Estados"] = new SelectList(new[] { 
                EstadoMisa.Programada, 
                EstadoMisa.Realizada, 
                EstadoMisa.Cancelada 
            });
        }
    }
}
