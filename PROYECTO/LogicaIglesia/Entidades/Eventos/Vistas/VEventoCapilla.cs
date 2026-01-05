using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos.Vistas
{
    public class VEventoCapilla
    {
        public int IdEventoCapilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Capilla { get; set; }
        public string Activo { get; set; }

        public VEventoCapilla() { }

        public VEventoCapilla(int idEventoCapilla, string nombre, string descripcion, string fechaInicio, string fechaFin, string idCapilla, string activo)
        {
            IdEventoCapilla = idEventoCapilla;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Capilla = idCapilla;
            Activo = activo;
        }
    }
}
