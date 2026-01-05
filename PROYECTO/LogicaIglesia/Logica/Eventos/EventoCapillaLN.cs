using Datos.Conunidades;
using Datos.Eventos;
using Entidades.Eventos.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Eventos
{
    public class EventoCapillaLN
    {
        public List<Entidades.Eventos.Vistas.VEventoCapilla> Listar(string filtro)
        {
            List<Entidades.Eventos.Vistas.VEventoCapilla> lista = new List<VEventoCapilla>();

            try
            {
                var datos = EventoCapillaCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Eventos.Vistas.VEventoCapilla(
                        item.idEventoCapilla,
                        item.Evento,
                        item.Descripcion,
                        item.Inicio,
                        item.Fin,
                        item.Capilla,
                        item.Estado
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar EventoCapilla", ex);
            }

            return lista;
        }

        public Entidades.Eventos.EventoCapilla ObtenerPorId(int id)
        {
            try
            {
                var aux = EventoCapillaCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Eventos.EventoCapilla(
                    aux.idEventoCapilla,
                    aux.Nombre,
                    aux.Descripcion,
                    aux.FechaInicio,
                    (DateTime)aux.FechaFin,
                    aux.idCapilla,
                    aux.Activo
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener EventoCapilla", ex);
            }
        }

        public bool Insertar(Entidades.Eventos.EventoCapilla oc)
        {
            try
            {
                EventoCapillaCD.Insertar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar EventoCapilla", ex);
            }
        }

        public bool Modificar(Entidades.Eventos.EventoCapilla oc)
        {
            try
            {
                EventoCapillaCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar EventoCapilla", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                EventoCapillaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar EventoCapilla", ex);
            }
        }
    }
}
