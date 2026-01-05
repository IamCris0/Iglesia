using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad
{
    public class RolSistema
    {
        private int idRolSistema;
        private string nombre;
        private string descripcion;

        public RolSistema(int idRolSistema, string nombre, string descripcion)
        {
            this.idRolSistema = idRolSistema;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int IdRolSistema { get => idRolSistema; set => idRolSistema = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
