using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos.Vistas
{
    public class VEventoParroquial
    {
        public VEventoParroquial(int idEventoParroquial, string nombre, string descripcion, string fechaInicio, string fechaFin, string parroquia, string activo)
        {
            IdEventoParroquial = idEventoParroquial;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Parroquia = parroquia;
            Activo = activo;
        }

        public VEventoParroquial ()
        {

        }

        public int IdEventoParroquial { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Parroquia { get; set; }
        public string Activo { get; set; }
    }
}
