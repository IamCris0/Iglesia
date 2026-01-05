using LogicaIglesia.Entidad___Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia
{
    public class Laico : Persona
    {
        public Laico(string cedula, string nombres, string apellidos, DateTime fechaNacimiento, List<string> rol, CentroPastoral centroPastoral, string estadoSacramental, ProcesoSacramental procesoActivo) : base(cedula, nombres, apellidos, fechaNacimiento)
        {
            Rol = rol;
            CentroPastoral = centroPastoral;
            EstadoSacramental = estadoSacramental;
            ProcesoActivo = procesoActivo;
        }

        public List<string> Rol { get; set; }
        public CentroPastoral CentroPastoral { get; set; } // Centro Pastoral al que Asiste / Pertenece
        public string EstadoSacramental { get; set; }
        public ProcesoSacramental ProcesoActivo { get; private set; }
    }
}
