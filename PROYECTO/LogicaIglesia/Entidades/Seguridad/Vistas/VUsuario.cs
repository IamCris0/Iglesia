using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad.Vistas
{
    public class VUsuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Persona { get; set; }
        public string Tipo { get; set; }

        public VUsuario(int idUsuario, string email, string persona, string tipo)
        {
            IdUsuario = idUsuario;
            Email = email;
            Persona = persona;
            Tipo = tipo;
        }

        public VUsuario() { }
    }
}
