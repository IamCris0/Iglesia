using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using SistemaParroquial.Models;
using System.Security.Cryptography;
using System.Text;

namespace SistemaParroquial.Controllers
{
    /// <summary>
    /// Controlador para gestionar los Usuarios del sistema
    /// </summary>
    public class UsuarioController : Controller
    {
        private readonly SistemaParroquialContext _context;

        public UsuarioController(SistemaParroquialContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index(string filtro)
        {
            var usuarios = _context.Usuarios
                .Include(u => u.Laico)
                .Include(u => u.Sacerdote)
                .Include(u => u.Roles)
                    .ThenInclude(r => r.RolSistema)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
            {
                usuarios = usuarios.Where(u => u.Email.Contains(filtro));
            }

            return View(await usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios
                .Include(u => u.Laico)
                .Include(u => u.Sacerdote)
                .Include(u => u.Roles)
                    .ThenInclude(r => r.RolSistema)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            CargarListasSeleccion();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario, string password, List<int> rolesSeleccionados)
        {
            // Validar que solo tenga un tipo de usuario asignado
            if (usuario.IdLaico.HasValue && usuario.IdSacerdote.HasValue)
            {
                ModelState.AddModelError("", "Un usuario no puede ser Laico y Sacerdote al mismo tiempo");
            }

            if (ModelState.IsValid)
            {
                // Verificar que el email no exista
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                {
                    ModelState.AddModelError("Email", "Este email ya está registrado");
                    CargarListasSeleccion();
                    return View(usuario);
                }

                // Hashear la contraseña
                usuario.PasswordHash = HashPassword(password);

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                // Asignar roles
                if (rolesSeleccionados != null && rolesSeleccionados.Any())
                {
                    foreach (var idRol in rolesSeleccionados)
                    {
                        _context.UsuariosRoles.Add(new UsuarioRolSistema
                        {
                            IdUsuario = usuario.IdUsuario,
                            IdRolSistema = idRol
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                TempData["Mensaje"] = "Usuario creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            CargarListasSeleccion();
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (usuario == null) return NotFound();

            CargarListasSeleccion(usuario);
            ViewBag.RolesActuales = usuario.Roles.Select(r => r.IdRolSistema).ToList();

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario, string password, List<int> rolesSeleccionados)
        {
            if (id != usuario.IdUsuario) return NotFound();

            // Validar que solo tenga un tipo de usuario asignado
            if (usuario.IdLaico.HasValue && usuario.IdSacerdote.HasValue)
            {
                ModelState.AddModelError("", "Un usuario no puede ser Laico y Sacerdote al mismo tiempo");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioExistente = await _context.Usuarios.FindAsync(id);

                    // Verificar email duplicado
                    if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email && u.IdUsuario != id))
                    {
                        ModelState.AddModelError("Email", "Este email ya está registrado");
                        CargarListasSeleccion(usuario);
                        return View(usuario);
                    }

                    usuarioExistente.Email = usuario.Email;
                    usuarioExistente.IdLaico = usuario.IdLaico;
                    usuarioExistente.IdSacerdote = usuario.IdSacerdote;

                    // Si se proporciona nueva contraseña
                    if (!string.IsNullOrEmpty(password))
                    {
                        usuarioExistente.PasswordHash = HashPassword(password);
                    }

                    // Actualizar roles
                    var rolesActuales = _context.UsuariosRoles.Where(ur => ur.IdUsuario == id);
                    _context.UsuariosRoles.RemoveRange(rolesActuales);

                    if (rolesSeleccionados != null && rolesSeleccionados.Any())
                    {
                        foreach (var idRol in rolesSeleccionados)
                        {
                            _context.UsuariosRoles.Add(new UsuarioRolSistema
                            {
                                IdUsuario = id,
                                IdRolSistema = idRol
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Usuario actualizado exitosamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            CargarListasSeleccion(usuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios
                .Include(u => u.Laico)
                .Include(u => u.Sacerdote)
                .Include(u => u.Roles)
                    .ThenInclude(r => r.RolSistema)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                // Eliminar roles asociados
                var roles = _context.UsuariosRoles.Where(ur => ur.IdUsuario == id);
                _context.UsuariosRoles.RemoveRange(roles);

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Usuario eliminado exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuario/CambiarPassword/5
        public async Task<IActionResult> CambiarPassword(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // POST: Usuario/CambiarPassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarPassword(int id, string passwordActual, string passwordNuevo, string confirmarPassword)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            // Verificar contraseña actual
            if (HashPassword(passwordActual) != usuario.PasswordHash)
            {
                ModelState.AddModelError("", "La contraseña actual no es correcta");
                return View(usuario);
            }

            // Verificar que las contraseñas nuevas coincidan
            if (passwordNuevo != confirmarPassword)
            {
                ModelState.AddModelError("", "Las contraseñas nuevas no coinciden");
                return View(usuario);
            }

            // Actualizar contraseña
            usuario.PasswordHash = HashPassword(passwordNuevo);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Contraseña actualizada exitosamente.";
            return RedirectToAction(nameof(Details), new { id = id });
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

        private void CargarListasSeleccion(Usuario usuario = null)
        {
            ViewData["IdLaico"] = new SelectList(
                _context.Laicos
                    .Where(l => l.Activo)
                    .Select(l => new { l.IdLaico, NombreCompleto = l.Nombres + " " + l.Apellidos }),
                "IdLaico",
                "NombreCompleto",
                usuario?.IdLaico
            );

            ViewData["IdSacerdote"] = new SelectList(
                _context.Sacerdotes
                    .Select(s => new { s.IdSacerdote, NombreCompleto = s.Nombres + " " + s.Apellidos }),
                "IdSacerdote",
                "NombreCompleto",
                usuario?.IdSacerdote
            );

            ViewBag.Roles = _context.RolesSistema.ToList();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
