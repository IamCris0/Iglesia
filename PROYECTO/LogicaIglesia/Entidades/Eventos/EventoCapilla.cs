using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos
{
    public class EventoCapilla
    {
        public int IdEventoCapilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdCapilla { get; set; }
        public string Activo { get; set; }

        public EventoCapilla() { }

        public EventoCapilla(int idEventoCapilla, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, int idCapilla, string activo)
        {
            IdEventoCapilla = idEventoCapilla;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            IdCapilla = idCapilla;
            Activo = activo;
        }
    }
}
