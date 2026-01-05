using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Solicitudes
{
    public class SolicitudAyuda
    {
        public SolicitudAyuda()
        {
        }
        public SolicitudAyuda(int idSolicitudAyuda, int idLaico, int idParroquia, decimal montoSolicitado, string motivo, DateTime fecha, string estado)
        {
            IdSolicitudAyuda = idSolicitudAyuda;
            IdLaico = idLaico;
            IdParroquia = idParroquia;
            MontoSolicitado = montoSolicitado;
            Motivo = motivo;
            Fecha = fecha;
            Estado = estado;
        }
        public int IdSolicitudAyuda { get; set; }
        public int IdLaico { get; set; }
        public int IdParroquia { get; set; }
        public decimal MontoSolicitado { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
