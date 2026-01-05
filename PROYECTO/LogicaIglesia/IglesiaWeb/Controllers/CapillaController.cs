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
    /// Controlador para gestionar las Capillas del sistema
    /// </summary>
    public class CapillaController : Controller
    {
        private readonly SistemaParroquialContext _context;

        public CapillaController(SistemaParroquialContext context)
        {
            _context = context;
        }

        // GET: Capilla
        /// <summary>
        /// Lista todas las capillas con sus relaciones
        /// </summary>
        public async Task<IActionResult> Index(string filtro)
        {
            var capillas = _context.Capillas
                .Include(c => c.Parroquia)
                .Include(c => c.Coordinador)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
            {
                capillas = capillas.Where(c => c.Nombre.Contains(filtro) || 
                                              c.Direccion.Contains(filtro));
            }

            return View(await capillas.ToListAsync());
        }

        // GET: Capilla/Details/5
        /// <summary>
        /// Muestra los detalles de una capilla específica
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capilla = await _context.Capillas
                .Include(c => c.Parroquia)
                .Include(c => c.Coordinador)
                .Include(c => c.Misas)
                .Include(c => c.Eventos)
                .Include(c => c.HorariosMisa)
                .FirstOrDefaultAsync(m => m.IdCapilla == id);

            if (capilla == null)
            {
                return NotFound();
            }

            return View(capilla);
        }

        // GET: Capilla/Create
        /// <summary>
        /// Muestra el formulario para crear una nueva capilla
        /// </summary>
        public IActionResult Create()
        {
            CargarListasSeleccion();
            return View();
        }

        // POST: Capilla/Create
        /// <summary>
        /// Procesa la creación de una nueva capilla
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Direccion,IdParroquia,IdLaicoCoordinador")] Capilla capilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capilla);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Capilla creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            CargarListasSeleccion(capilla);
            return View(capilla);
        }

        // GET: Capilla/Edit/5
        /// <summary>
        /// Muestra el formulario para editar una capilla
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capilla = await _context.Capillas.FindAsync(id);
            if (capilla == null)
            {
                return NotFound();
            }
            CargarListasSeleccion(capilla);
            return View(capilla);
        }

        // POST: Capilla/Edit/5
        /// <summary>
        /// Procesa la edición de una capilla
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCapilla,Nombre,Direccion,IdParroquia,IdLaicoCoordinador")] Capilla capilla)
        {
            if (id != capilla.IdCapilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capilla);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Capilla actualizada exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapillaExists(capilla.IdCapilla))
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
            CargarListasSeleccion(capilla);
            return View(capilla);
        }

        // GET: Capilla/Delete/5
        /// <summary>
        /// Muestra la confirmación para eliminar una capilla
        /// </summary>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capilla = await _context.Capillas
                .Include(c => c.Parroquia)
                .Include(c => c.Coordinador)
                .FirstOrDefaultAsync(m => m.IdCapilla == id);

            if (capilla == null)
            {
                return NotFound();
            }

            return View(capilla);
        }

        // POST: Capilla/Delete/5
        /// <summary>
        /// Procesa la eliminación de una capilla
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capilla = await _context.Capillas.FindAsync(id);
            if (capilla != null)
            {
                _context.Capillas.Remove(capilla);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Capilla eliminada exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Verifica si existe una capilla con el ID dado
        /// </summary>
        private bool CapillaExists(int id)
        {
            return _context.Capillas.Any(e => e.IdCapilla == id);
        }

        /// <summary>
        /// Carga las listas de selección para los dropdowns
        /// </summary>
        private void CargarListasSeleccion(Capilla capilla = null)
        {
            ViewData["IdParroquia"] = new SelectList(_context.Parroquias, "IdParroquia", "Nombre", capilla?.IdParroquia);
            ViewData["IdLaicoCoordinador"] = new SelectList(
                _context.Laicos.Where(l => l.Activo).Select(l => new { l.IdLaico, NombreCompleto = l.Nombres + " " + l.Apellidos }),
                "IdLaico", 
                "NombreCompleto", 
                capilla?.IdLaicoCoordinador
            );
        }

        // GET: Capilla/AsignarCoordinador/5
        /// <summary>
        /// Muestra el formulario para asignar un coordinador a la capilla
        /// </summary>
        public async Task<IActionResult> AsignarCoordinador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capilla = await _context.Capillas
                .Include(c => c.Coordinador)
                .FirstOrDefaultAsync(c => c.IdCapilla == id);

            if (capilla == null)
            {
                return NotFound();
            }

            ViewBag.Laicos = new SelectList(
                _context.Laicos.Where(l => l.Activo).Select(l => new { l.IdLaico, NombreCompleto = l.Nombres + " " + l.Apellidos }),
                "IdLaico",
                "NombreCompleto"
            );

            return View(capilla);
        }

        // POST: Capilla/AsignarCoordinador/5
        /// <summary>
        /// Procesa la asignación de coordinador
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarCoordinador(int id, int idLaicoNuevo)
        {
            var capilla = await _context.Capillas.FindAsync(id);
            if (capilla == null)
            {
                return NotFound();
            }

            capilla.IdLaicoCoordinador = idLaicoNuevo;
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Coordinador asignado exitosamente.";
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
