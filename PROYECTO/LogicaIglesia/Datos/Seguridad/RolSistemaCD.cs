using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Seguridad
{
    public class RolSistemaCD
    {
        public static List<sp_RolSistema_ListarResult> Listar()
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_RolSistema_Listar().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar RolSistema", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_RolSistema_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_RolSistema_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Seguridad.RolSistema of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_RolSistema_Insert(
                        of.Nombre,
                        of.Descripcion
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar RolSistema", ex);
            }
        }

        public static void Modificar(Entidades.Seguridad.RolSistema of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_RolSistema_Update(
                        of.IdRolSistema,
                        of.Nombre,
                        of.Descripcion);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar RolSistema", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_RolSistema_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar RolSistema", ex);
            }
        }
    }
}
