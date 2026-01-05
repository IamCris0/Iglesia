using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas.Vistas
{
    public class VLaico
    {
        public VLaico()
        {
        }

        public VLaico(int idLaico, string nombres, string apellidos, string capilla, string telefono, bool activo)
        {
            this.idLaico = idLaico;
            Nombres = nombres;
            Apellidos = apellidos;
            Capilla = capilla;
            Telefono = telefono;
            Activo = activo;
        }

        public int idLaico { get; set; }
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public string Capilla { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public string NombreCompleto
        {
            get { return $"{Nombres} {Apellidos}"; }
        }
    }
}
