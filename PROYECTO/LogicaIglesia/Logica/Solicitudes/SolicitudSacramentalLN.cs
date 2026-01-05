using Datos.Solicitudes;
using Entidades.Solicitudes.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Solicitudes
{
    public class SolicitudSacramentalLN
    {
            public List<Entidades.Solicitudes.Vistas.VSolicitudSacramental> Listar(string filtro)
            {
                List<Entidades.Solicitudes.Vistas.VSolicitudSacramental> lista = new List<VSolicitudSacramental>();

                try
                {
                    var datos = SolicitudSacramentalCD.Listar(filtro);

                    foreach (var item in datos)
                    {
                        lista.Add(new Entidades.Solicitudes.Vistas.VSolicitudSacramental(
                        item.idSolicitudSacramental,
                        item.Laico,
                        item.Sacramento,
                        item.FechaSolicitada,
                        item.FechaFinal,
                        item.Estado,
                        item.Observaciones
                        ));
                    }
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al listar Solicitudes", ex);
                }

                return lista;
            }

            public Entidades.Solicitudes.SolicitudSacramental ObtenerPorId(int id)
            {
                try
                {
                    var item = SolicitudSacramentalCD.BuscarPorId(id);
                    if (item == null) return null;

                    return new Entidades.Solicitudes.SolicitudSacramental(
                        item.idSolicitudSacramental,
                        item.idLaico,
                        item.Sacramento,
                        (DateTime)item.FechaSolicitada,
                        item.FechaFinal,
                        item.Estado,
                        item.Observaciones
                    );
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al obtener Solicitudes", ex);
                }
            }

            public bool Insertar(Entidades.Solicitudes.SolicitudSacramental oc)
            {
                try
                {
                    SolicitudSacramentalCD.Insertar(oc);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al insertar Solicitudes", ex);
                }
            }

            public bool Modificar(Entidades.Solicitudes.SolicitudSacramental oc)
            {
                try
                {
                    SolicitudSacramentalCD.Modificar(oc);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al modificar Solicitudes", ex);
                }
            }

        public bool Eliminar(int id)
        {
            try
            {
                SolicitudSacramentalCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Solicitudes", ex);
            }
        }        
    }
}
