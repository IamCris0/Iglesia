using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia
{
    public class Persona
    {
        public Persona(string cedula, string nombres, string apellidos, DateTime fechaNacimiento)
        {
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
        }

        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int CalcularEdad()
        {
            DateTime hoy = DateTime.Today;

            int edad = hoy.Year - FechaNacimiento.Year;

            DateTime fechaCumpleanosEsteAnio = new DateTime(hoy.Year, FechaNacimiento.Month, FechaNacimiento.Day);

            if (hoy < fechaCumpleanosEsteAnio)
            {
                edad--;
            }

            return edad;
        }

    }
}
