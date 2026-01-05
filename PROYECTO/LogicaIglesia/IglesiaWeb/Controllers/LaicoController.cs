using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using SistemaParroquial.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaParroquial.Controllers
{
    /// <summary>
    /// Controlador para gestionar los Laicos del sistema
    /// </summary>
    public class LaicoController : Controller
    {
        private readonly SistemaParroquialContext _context;

        public LaicoController(SistemaParroquialContext context)
        {
            _context = context;
        }

        // GET: Laico
        /// <summary>
        /// Lista todos los laicos
        /// </summary>
        public async Task<IActionResult> Index(string filtro, bool? activo)
        {
            var laicos = _context.Laicos
                .Include(l => l.Capilla)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
            {
                laicos = laicos.Where(l => l.Nombres.Contains(filtro) || 
                                          l.Apellidos.Contains(filtro) ||
                                          l.Telefono.Contains(filtro));
            }

            if (activo.HasValue)
            {
                laicos = laicos.Where(l => l.Activo == activo.Value);
            }

            return View(await laicos.ToListAsync());
        }

        // GET: Laico/Details/5
        /// <summary>
        /// Muestra los detalles de un laico específico
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laico = await _context.Laicos
                .Include(l => l.Capilla)
                .Include(l => l.SolicitudesSacramentales)
                .Include(l => l.SolicitudesAyuda)
                .Include(l => l.Formaciones)
                .Include(l => l.MembresiaCEB)
                .FirstOrDefaultAsync(m => m.IdLaico == id);

            if (laico == null)
            {
                return NotFound();
            }

            return View(laico);
        }

        // GET: Laico/Create
        /// <summary>
        /// Muestra el formulario para crear un nuevo laico
        /// </summary>
        public IActionResult Create()
        {
            CargarListasSeleccion();
            return View();
        }

        // POST: Laico/Create
        /// <summary>
        /// Procesa la creación de un nuevo laico
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombres,Apellidos,Telefono,IdCapilla,Activo")] Laico laico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laico);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Laico creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            CargarListasSeleccion(laico);
            return View(laico);
        }

        // GET: Laico/Edit/5
        /// <summary>
        /// Muestra el formulario para editar un laico
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laico = await _context.Laicos.FindAsync(id);
            if (laico == null)
            {
                return NotFound();
            }
            CargarListasSeleccion(laico);
            return View(laico);
        }

        // POST: Laico/Edit/5
        /// <summary>
        /// Procesa la edición de un laico
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLaico,Nombres,Apellidos,Telefono,IdCapilla,Activo")] Laico laico)
        {
            if (id != laico.IdLaico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laico);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Laico actualizado exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaicoExists(laico.IdLaico))
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
            CargarListasSeleccion(laico);
            return View(laico);
        }

        // GET: Laico/Delete/5
        /// <summary>
        /// Muestra la confirmación para eliminar un laico
        /// </summary>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laico = await _context.Laicos
                .Include(l => l.Capilla)
                .FirstOrDefaultAsync(m => m.IdLaico == id);

            if (laico == null)
            {
                return NotFound();
            }

            return View(laico);
        }

        // POST: Laico/Delete/5
        /// <summary>
        /// Procesa la eliminación de un laico
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laico = await _context.Laicos.FindAsync(id);
            if (laico != null)
            {
                _context.Laicos.Remove(laico);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Laico eliminado exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Laico/CambiarEstado/5
        /// <summary>
        /// Cambia el estado activo/inactivo de un laico
        /// </summary>
        public async Task<IActionResult> CambiarEstado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laico = await _context.Laicos.FindAsync(id);
            if (laico == null)
            {
                return NotFound();
            }

            laico.Activo = !laico.Activo;
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = $"Laico {(laico.Activo ? "activado" : "desactivado")} exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Verifica si existe un laico con el ID dado
        /// </summary>
        private bool LaicoExists(int id)
        {
            return _context.Laicos.Any(e => e.IdLaico == id);
        }

        /// <summary>
        /// Carga las listas de selección para los dropdowns
        /// </summary>
        private void CargarListasSeleccion(Laico laico = null)
        {
            ViewData["IdCapilla"] = new SelectList(_context.Capillas, "IdCapilla", "Nombre", laico?.IdCapilla);
        }
    }
}
