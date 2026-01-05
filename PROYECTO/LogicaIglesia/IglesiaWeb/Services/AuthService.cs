using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SistemaParroquial.Data;
using SistemaParroquial.Models;

namespace SistemaParroquial.Services
{
    /// <summary>
    /// Servicio para gestionar la autenticación de usuarios
    /// </summary>
    public interface IAuthService
    {
        Task<Usuario> ValidarCredenciales(string email, string password);
        string HashPassword(string password);
        Task<bool> ExisteEmail(string email);
    }

    public class AuthService : IAuthService
    {
        private readonly SistemaParroquialContext _context;

        public AuthService(SistemaParroquialContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Valida las credenciales del usuario
        /// </summary>
        public async Task<Usuario> ValidarCredenciales(string email, string password)
        {
            var passwordHash = HashPassword(password);
            
            var usuario = await _context.Usuarios
                .Include(u => u.Laico)
                .Include(u => u.Sacerdote)
                .Include(u => u.Roles)
                    .ThenInclude(r => r.RolSistema)
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);

            return usuario;
        }

        /// <summary>
        /// Genera el hash SHA256 de una contraseña
        /// </summary>
        public string HashPassword(string password)
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

        /// <summary>
        /// Verifica si existe un email en la base de datos
        /// </summary>
        public async Task<bool> ExisteEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}
