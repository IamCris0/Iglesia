using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using SistemaParroquial.Models;
using System.Security.Cryptography;
using System.Text;

namespace SistemaParroquial.Controllers
{
    /// <summary>
    /// Controlador para gestionar la autenticación
    /// </summary>
    public class AuthController : Controller
    {
        private readonly SistemaParroquialContext _context;

        public AuthController(SistemaParroquialContext context)
        {
            _context = context;
        }

        // GET: Auth/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Si ya está autenticado, redirigir al home
            if (HttpContext.Session.GetInt32("UsuarioId").HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email y contraseña son obligatorios");
                return View();
            }

            // Hashear la contraseña
            var passwordHash = HashPassword(password);

            // Buscar usuario
            var usuario = await _context.Usuarios
                .Include(u => u.Laico)
                .Include(u => u.Sacerdote)
                .Include(u => u.Roles)
                    .ThenInclude(r => r.RolSistema)
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);

            if (usuario != null)
            {
                // Guardar información en la sesión
                HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);
                HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
                HttpContext.Session.SetString("UsuarioTipo", usuario.TipoUsuario);

                if (usuario.Laico != null)
                {
                    HttpContext.Session.SetString("UsuarioNombre", usuario.Laico.NombreCompleto);
                    HttpContext.Session.SetInt32("IdLaico", usuario.Laico.IdLaico);
                }
                else if (usuario.Sacerdote != null)
                {
                    HttpContext.Session.SetString("UsuarioNombre", usuario.Sacerdote.NombreCompleto);
                    HttpContext.Session.SetInt32("IdSacerdote", usuario.Sacerdote.IdSacerdote);
                }
                else
                {
                    HttpContext.Session.SetString("UsuarioNombre", usuario.Email);
                }

                // Guardar roles
                var roles = string.Join(",", usuario.Roles.Select(r => r.RolSistema.Nombre));
                HttpContext.Session.SetString("UsuarioRoles", roles);

                TempData["Mensaje"] = $"¡Bienvenido {HttpContext.Session.GetString("UsuarioNombre")}!";

                // Redirigir a la URL de retorno o al home
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email o contraseña incorrectos");
            }

            return View();
        }

        // GET: Auth/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Mensaje"] = "Sesión cerrada exitosamente";
            return RedirectToAction("Login");
        }

        // GET: Auth/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Auth/Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Laicos = _context.Laicos.Where(l => l.Activo).ToList();
            ViewBag.Sacerdotes = _context.Sacerdotes.ToList();
            return View();
        }

        // POST: Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string email, string password, string confirmarPassword, int? idLaico, int? idSacerdote)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email y contraseña son obligatorios");
                ViewBag.Laicos = _context.Laicos.Where(l => l.Activo).ToList();
                ViewBag.Sacerdotes = _context.Sacerdotes.ToList();
                return View();
            }

            if (password != confirmarPassword)
            {
                ModelState.AddModelError("", "Las contraseñas no coinciden");
                ViewBag.Laicos = _context.Laicos.Where(l => l.Activo).ToList();
                ViewBag.Sacerdotes = _context.Sacerdotes.ToList();
                return View();
            }

            // Verificar que el email no exista
            if (await _context.Usuarios.AnyAsync(u => u.Email == email))
            {
                ModelState.AddModelError("", "Este email ya está registrado");
                ViewBag.Laicos = _context.Laicos.Where(l => l.Activo).ToList();
                ViewBag.Sacerdotes = _context.Sacerdotes.ToList();
                return View();
            }

            // Crear usuario
            var usuario = new Usuario
            {
                Email = email,
                PasswordHash = HashPassword(password),
                IdLaico = idLaico,
                IdSacerdote = idSacerdote
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Usuario registrado exitosamente. Por favor inicie sesión.";
            return RedirectToAction("Login");
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
