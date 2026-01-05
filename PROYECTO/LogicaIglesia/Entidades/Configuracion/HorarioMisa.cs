using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Configuracion
{
    public class HorarioMisa
    {
        public int IdHorarioMisa { get; set; }
        public int IdCapilla { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan Hora { get; set; }
        public string Activo { get; set; }

        public HorarioMisa() { }

        public HorarioMisa(int idHorarioMisa, int idCapilla, int diaSemana, TimeSpan hora, string activo)
        {
            IdHorarioMisa = idHorarioMisa;
            IdCapilla = idCapilla;
            DiaSemana = diaSemana;
            Hora = hora;
            Activo = activo;
        }

        public HorarioMisa(int idCapilla, int diaSemana, TimeSpan hora)
        {
            IdCapilla = idCapilla;
            DiaSemana = diaSemana;
            Hora = hora;
        }
    }
}
