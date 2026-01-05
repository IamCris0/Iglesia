using LogicaIglesia.Entidad___Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia
{
    public class CoordinadorPastoral : MiembroComunidad
    {
        public CoordinadorPastoral(string cedula, string nombres, string apellidos, DateTime fechaNacimiento, List<string> rol, CentroPastoral centroPastoral, string estadoSacramental, ProcesoSacramental procesoActivo) : base(cedula, nombres, apellidos, fechaNacimiento, rol, centroPastoral, estadoSacramental, procesoActivo)
        {
        }
    }
}
