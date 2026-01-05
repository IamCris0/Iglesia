using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia
{
    public class CentroPastoral
    {
        public CentroPastoral(string nombre, string direccion, CoordinadorPastoral coordinador, List<Comunidad> comunidades, List<Laico> servidores, double fondoGeneral)
        {
            Nombre = nombre;
            Direccion = direccion;
            Coordinador = coordinador;
            Comunidades = comunidades;
            Servidores = servidores;
            FondoGeneral = fondoGeneral;
        }

        public string Nombre {  get; set; }
        public string Direccion { get; set; }
        public CoordinadorPastoral Coordinador { get; set; }
        public List<Comunidad> Comunidades { get; set; }
        public List<Laico> Servidores { get; set; } // Personas que sirven a la iglesia pero que no pertenecen a una comunidad.
        public double FondoGeneral { get; set; }

    }
}
