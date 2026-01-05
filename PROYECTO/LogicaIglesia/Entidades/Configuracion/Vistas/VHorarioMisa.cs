using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Configuracion
{
    public class VHorarioMisa
    {
        public VHorarioMisa(int idHorarioMisa, string capilla, string diaSemana, TimeSpan hora, string  activo)
        {
            IdHorarioMisa = idHorarioMisa;
            Capilla = capilla;
            DiaSemana = diaSemana;
            Hora = hora;
            Activo = activo;
        }
        public VHorarioMisa() { }   

        public int IdHorarioMisa { get; set; }
        public string Capilla { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan Hora { get; set; }
        public string Activo { get; set; }
    }
}
