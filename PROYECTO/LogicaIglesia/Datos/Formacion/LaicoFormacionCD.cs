using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Formacion
{
    public class LaicoFormacionCD
    {
        public static List<sp_LaicoFormacion_ListarResult> Listar(string valor)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_LaicoFormacion_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar LaicoFormacion", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_LaicoFormacion_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_LaicoFormacion_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Formacion.LaicoFormacion lf)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoFormacion_Insert(
                        lf.IdLaico,
                        lf.IdFormacion,
                        lf.Estado,
                        lf.FechaInicio,
                        lf.FechaFin
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar LaicoFormacion", ex);
            }
        }

        public static void Modificar(Entidades.Formacion.LaicoFormacion lf)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoFormacion_Update(
                        lf.IdLaicoFormacion,
                        lf.Estado,
                        lf.FechaInicio,
                        lf.FechaFin
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar LaicoFormacion", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoFormacion_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar LaicoFormacion", ex);
            }
        }
    }
}
