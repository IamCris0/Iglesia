using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos.Vistas
{
    public class VMisa
    {
        public VMisa(int idMisa, string capilla, string sacerdote, string fecha, decimal montoRecaudado, string estado, string sacramento)
        {
            IdMisa = idMisa;
            Capilla = capilla;
            Sacerdote = sacerdote;
            Fecha = fecha;
            MontoRecaudado = montoRecaudado;
            Estado = estado;
            Sacramento = sacramento;
        }

        public VMisa ()
        {

        }

        public int IdMisa { get; set; }
        public string Capilla { get; set; }
        public string Sacerdote { get; set; }
        public string Fecha { get; set; }
        public decimal MontoRecaudado { get; set; }
        public string Estado { get; set; }
        public string Sacramento { get; set; }


    }
}
