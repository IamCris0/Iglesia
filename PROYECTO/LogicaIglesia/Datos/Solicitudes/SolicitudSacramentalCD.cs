using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Solicitudes
{
    public class SolicitudSacramentalCD
    {
        public static List<sp_SolicitudSacramental_ListarResult> Listar(string filtro)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_SolicitudSacramental_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar SolicitudSacramental", ex);
            }
        }

        public static sp_SolicitudSacramental_BuscarPorIdResult BuscarPorId(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_SolicitudSacramental_BuscarPorId(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al buscar SolicitudSacramental por Id", ex);
            }
        }

        public static void Insertar(Entidades.Solicitudes.SolicitudSacramental item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudSacramental_Insert(
                        item.IdLaico,
                        item.Sacramento,
                        item.FechaSolicitada,
                        item.FechaFinal,
                        item.Estado,
                        item.Observaciones
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar SolicitudSacramental", ex);
            }
        }

        public static void Modificar(Entidades.Solicitudes.SolicitudSacramental item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudSacramental_Update(
                        item.IdSolicitudSacramental,
                        item.Sacramento,
                        item.FechaSolicitada,
                        item.FechaFinal,
                        item.Estado,
                        item.Observaciones
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar SolicitudSacramental", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_SolicitudSacramental_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar SolicitudSacramental", ex);
            }
        }
    }
}
