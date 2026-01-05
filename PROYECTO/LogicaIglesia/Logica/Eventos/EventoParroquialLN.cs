using Datos.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Eventos
{
    public class EventoParroquialLN
    {
        public List<Entidades.Eventos.Vistas.VEventoParroquial> Listar(String valor)
        {
            List<Entidades.Eventos.Vistas.VEventoParroquial> lista =
                new List<Entidades.Eventos.Vistas.VEventoParroquial>();

            try
            {
                var datos = EventoParroquialCD.Listar(valor);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Eventos.Vistas.VEventoParroquial(
                        item.idEventoParroquial,
                        item.Nombre,
                        item.Descripcion,
                        item.FechaInicio,
                        item.FechaFin,
                        item.Parroquia,
                        item.Activo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Evento Parroquial", ex);
            }

            return lista;
        }

        public void Insertar(Entidades.Eventos.EventoParroquial e)
        {
            try
            {
                EventoParroquialCD.Insertar(e);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Evento Parroquial", ex);
            }
        }

        public void Modificar(Entidades.Eventos.EventoParroquial e)
        {
            try
            {
                EventoParroquialCD.Modificar(e);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Evento Parroquial", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                EventoParroquialCD.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Evento Parroquial", ex);
            }
        }
    }
}
