using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Comunidades
{
    public class CEB
    {
        public int IdCEB { get; set; }
        public string Nombre { get; set; }
        public int IdCapilla { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public CEB() { }

        public CEB(int idCEB, string nombre, int idCapilla, bool activo, DateTime fechaCreacion)
        {
            IdCEB = idCEB;
            Nombre = nombre;
            IdCapilla = idCapilla;
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }

        public CEB(string nombre, int idCapilla, bool activo, DateTime fechaCreacion)
        {
            Nombre = nombre;
            IdCapilla = idCapilla;
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }
    }
}
