using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Roles
{
    public class RolFuncional
    {
        private int idRolFuncional;
        private string nombre;
        private string descripcion;

        public RolFuncional(int idRolFuncional, string nombre, string descripcion)
        {
            this.IdRolFuncional = idRolFuncional;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int IdRolFuncional { get => idRolFuncional; set => idRolFuncional = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
