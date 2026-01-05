using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos
{
    public class EventoParroquial
    {
        public int IdEventoParroquial { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdParroquia { get; set; }
        public string Activo { get; set; }

        public EventoParroquial() { }




        public EventoParroquial(int idEventoParroquial, string nombre, string descripcion, DateTime fechaInicio, DateTime? fechaFin, int idParroquia, string activo)
        {
            IdEventoParroquial = idEventoParroquial;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            IdParroquia = idParroquia;
            Activo = activo;
        }
    }
}
