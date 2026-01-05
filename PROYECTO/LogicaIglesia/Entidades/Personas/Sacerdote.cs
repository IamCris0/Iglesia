using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Sacerdote
    {
        public Sacerdote()
        {
        }

        public Sacerdote(int idSacerdote, string nombres, string apellidos, string apodo)
        {
            IdSacerdote = idSacerdote;
            Nombres = nombres;
            Apellidos = apellidos;
            Apodo = apodo;
        }

        public int IdSacerdote { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Apodo { get; set; }

    }
}
