using Datos.Solicitudes;
using Entidades.Solicitudes.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Solicitudes
{
    public class SolicitudAyudaLN
    {
        public List<Entidades.Solicitudes.Vistas.VSolicitudAyuda> Listar(string filtro)
        {
            List<Entidades.Solicitudes.Vistas.VSolicitudAyuda> lista = new List<VSolicitudAyuda>();

            try
            {
                var datos = SolicitudAyudaCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Solicitudes.Vistas.VSolicitudAyuda(
                        item.idSolicitudAyuda,
                        item.Laico,
                        item.Parroquia,
                        item.MontoSolicitado,
                        item.Motivo,
                        item.Fecha,
                        item.Estado
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Solicitudes", ex);
            }

            return lista;
        }

        public Entidades.Solicitudes.SolicitudAyuda ObtenerPorId(int id)
        {
            try
            {
                var item = SolicitudAyudaCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Solicitudes.SolicitudAyuda(
                        item.idSolicitudAyuda,
                        item.idLaico,
                        item.idParroquia,
                        item.MontoSolicitado,
                        item.Motivo,
                        item.Fecha,
                        item.Estado
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Solicitudes", ex);
            }
        }

        public bool Insertar(Entidades.Solicitudes.SolicitudAyuda oc)
        {
            try
            {
                SolicitudAyudaCD.Insertar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Solicitudes", ex);
            }
        }

        public bool Modificar(Entidades.Solicitudes.SolicitudAyuda oc)
        {
            try
            {
                SolicitudAyudaCD.Modificar(oc);
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
                SolicitudAyudaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Solicitudes", ex);
            }
        }
    }
}
