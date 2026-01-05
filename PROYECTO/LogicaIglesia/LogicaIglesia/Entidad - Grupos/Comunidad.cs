using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia
{
    public class Comunidad
    {
        public Comunidad(string nombre, List<MiembroComunidad> miembros, double fondo)
        {
            Nombre = nombre;
            Miembros = miembros;
            Fondo = fondo;
        }

        public string Nombre { get; set; }
        public List<MiembroComunidad> Miembros {  get; set; }
        public double Fondo { get; set; }

    }
}
