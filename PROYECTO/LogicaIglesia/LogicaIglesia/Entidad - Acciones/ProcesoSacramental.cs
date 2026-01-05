using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaIglesia.Entidad___Acciones
{
    public class ProcesoSacramental
    {
        public string TipoProceso { get; set; }

        // Lista de participantes. Puede ser una Persona (para Comunión) o una Pareja (para Matrimonio).
        public List<Persona> Participantes { get; set; } = new List<Persona>();

        public Persona Coordinador { get; set; } // ¿Quién está dando la charla o clase? (Catequista, Agente Pastoral, Sacerdote)
        public DateTime FechaInicio { get; set; }
        public bool Finalizado { get; private set; } = false;

        public ProcesoSacramental(string tipoProceso, Persona coordinador, List<Persona> participantes)
        {
            TipoProceso = tipoProceso;
            Coordinador = coordinador;
            Participantes = participantes;
            FechaInicio = DateTime.Now;
        }

        public void CompletarProceso()
        {
            Finalizado = true;
        }
    }
}
