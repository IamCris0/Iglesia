using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Comunidades.Vistas
{
    public class VCEB
    {
        public int IdCEB { get; set; }
        public string CEB { get; set; }
        public string Capilla { get; set; }
        public bool Activo { get; set; }
        public string Estado { get; set; }
        public string FechaCreacion { get; set; }

        public VCEB() { }

        public VCEB(int idCEB, string ceb, string capilla, bool activo, string estado, string fechaCreacion)
        {
            IdCEB = idCEB;
            CEB = ceb;
            Capilla = capilla;
            Activo = activo;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}
