using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Laico
    {
        public int idLaico { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int idCapilla { get; set; }
        public bool Activo { get; set; }

        public Laico() { }

        public Laico(int idLaico, string nombres, string apellidos,
                     string telefono, int idCapilla, bool activo)
        {
            this.idLaico = idLaico;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            this.idCapilla = idCapilla;
            Activo = activo;
        }
    }
}
