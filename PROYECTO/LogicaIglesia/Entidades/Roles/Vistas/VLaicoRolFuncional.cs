using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Roles.Vistas
{
    public class VLaicoRolFuncional
    {
        public int IdLaicoRolFuncional { get; set; }
        public string Laico { get; set; }
        public string Rol { get; set; }

        public VLaicoRolFuncional() { }

        public VLaicoRolFuncional(int idLaicoRolFuncional, string laico, string rol)
        {
            IdLaicoRolFuncional = idLaicoRolFuncional;
            Laico = laico;
            Rol = rol;
        }
    }
}
