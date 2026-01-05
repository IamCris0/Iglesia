using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? IdLaico { get; set; }
        public int? IdSacerdote { get; set; }

        public Usuario() { }

        public Usuario(int idUsuario, string email, string passwordHash, int? idLaico, int? idSacerdote)
        {
            IdUsuario = idUsuario;
            Email = email;
            PasswordHash = passwordHash;
            IdLaico = idLaico;
            IdSacerdote = idSacerdote;
        }
    }
}
