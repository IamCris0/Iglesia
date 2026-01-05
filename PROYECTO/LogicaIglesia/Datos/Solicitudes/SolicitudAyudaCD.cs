using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Solicitudes
{
    public class SolicitudAyudaCD
    {
        public static List<sp_SolicitudAyuda_ListarResult> Listar(string filtro)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_SolicitudAyuda_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar SolicitudAyuda", ex);
            }
        }

        public static sp_SolicitudAyuda_BuscarPorIdResult BuscarPorId(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_SolicitudAyuda_BuscarPorId(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al buscar SolicitudAyuda por Id", ex);
            }
        }

        public static void Insertar(Entidades.Solicitudes.SolicitudAyuda item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudAyuda_Insert(
                        item.IdLaico,
                        item.IdParroquia,
                        item.MontoSolicitado,
                        item.Motivo,
                        item.Fecha,
                        item.Estado
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar SolicitudAyuda", ex);
            }
        }

        public static void Modificar(Entidades.Solicitudes.SolicitudAyuda item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudAyuda_Update(
                        item.IdSolicitudAyuda,
                        item.IdLaico,
                        item.IdParroquia,
                        item.MontoSolicitado,
                        item.Motivo,
                        item.Fecha,
                        item.Estado
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar SolicitudAyuda", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudAyuda_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar SolicitudAyuda", ex);
            }
        }
    }
}
