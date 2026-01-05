using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas.Vistas
{
    public class VMiembroCEB
    {
        public int IdMiembroCEB { get; set; }
        public string IdLaico { get; set; }
        public string CEB { get; set; }
        public bool Activo { get; set; }
        public string FechaIngreso { get; set; }


        public VMiembroCEB(int idMiembroCEB, string idLaico, string idCEB, bool activo, string fechaIngreso)
        {
            IdMiembroCEB = idMiembroCEB;
            IdLaico = idLaico;
            CEB = idCEB;
            Activo = activo;
            FechaIngreso = fechaIngreso;
        }

        public VMiembroCEB ()
        {

        }
    }
}
