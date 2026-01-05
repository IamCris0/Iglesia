using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class MiembroCEB
    {
        public int IdMiembroCEB { get; set; }
        public int IdLaico { get; set; }
        public int IdCEB { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaIngreso { get; set; }

        public MiembroCEB()
        {
        }

        public MiembroCEB(int idMiembroCEB, int idLaico, int idCEB, bool activo, DateTime fechaIngreso)
        {
            IdMiembroCEB = idMiembroCEB;
            IdLaico = idLaico;
            IdCEB = idCEB;
            Activo = activo;
            FechaIngreso = fechaIngreso;
        }
    }
}
