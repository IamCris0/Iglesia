using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Solicitudes.Vistas
{
    public class VSolicitudAyuda
    {
        public VSolicitudAyuda()
        {
        }

        public VSolicitudAyuda(int idSolicitudAyuda, string idLaico, string idParroquia, decimal montoSolicitado, string motivo, string fecha, string estado)
        {
            IdSolicitudAyuda = idSolicitudAyuda;
            Laico = idLaico;
            Parroquia = idParroquia;
            MontoSolicitado = montoSolicitado;
            Motivo = motivo;
            Fecha = fecha;
            Estado = estado;
        }

        public int IdSolicitudAyuda { get; set; }
        public string Laico { get; set; }
        public string Parroquia { get; set; }
        public decimal MontoSolicitado { get; set; }
        public string Motivo { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
    }
}
