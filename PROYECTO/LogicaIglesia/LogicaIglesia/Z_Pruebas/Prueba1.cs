using LogicaIglesia.Referencias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaIglesia.Z_Pruebas
{
    public class Prueba1
    {
        public static void Imprimir()
        {
            List<string> ricardo = new List<string> { RolesLaicos.CoordinadorCentro, RolesLaicos.CatequistaComunion};

            List<string> roberto = new List<string> { RolesLaicos.Coro_Guitarrista, RolesLaicos.CatequistaComunion};


            CoordinadorPastoral coordinador = new CoordinadorPastoral("0731234234", "Ricardo", "Correa", new DateTime(19 / 05 / 2000), ricardo, null, EstadosSacramentales.Confirmacion, null);

            CentroPastoral centro = new CentroPastoral("Virgen del Rosario", "Barrio 12 Noviembre", coordinador, new List<Comunidad>(), new List<Laico>(), 200);

            coordinador.CentroPastoral = centro;

            MiembroComunidad laico = new MiembroComunidad("0750625857", "Roberto", "Loayza", new DateTime(29 / 03 / 2005), roberto, centro, EstadosSacramentales.Confirmacion, null);

            Comunidad comunidad = new Comunidad("Virgen de Narcisa", new List<MiembroComunidad> { coordinador, laico }, 100);

            centro.Comunidades.Add(comunidad);

            MessageBox.Show($"La comunidad {centro.Comunidades[0].Nombre} posee un fondo de :{centro.Comunidades[0].Fondo.ToString("C")}");

            ImprimirMiembros(comunidad);
        }

        public static void ImprimirMiembros (Comunidad comunidad)
        {
            string mensaje = "";

            foreach(MiembroComunidad op in comunidad.Miembros)
            {
                mensaje += $"{op.Nombres} {op.Apellidos}:\n";

                for (int i = 0; i < op.Rol.Count; i ++)
                {
                    mensaje += $" - {op.Rol[i]}";
                }

                mensaje += "\n";
            }

            MessageBox.Show(mensaje);
        }
    }
}
