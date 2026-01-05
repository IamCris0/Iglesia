using Datos.LinqToSQL;
using Entidades.Comunidades.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Conunidades
{
    public class CEBCD
    {
        public static List<sp_CEB_ListarResult> Listar(string valor)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_CEB_Listar(valor).ToList();
                }   
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar CEB", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_CEB_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_CEB_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Comunidades.CEB of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_CEB_Insert(
                        of.Nombre,
                        of.IdCapilla,
                        of.Activo,
                        of.FechaCreacion
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar CEB", ex);
            }
        }

        public static void Modificar(Entidades.Comunidades.CEB of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_CEB_Update(
                       of.IdCEB,
                       of.Nombre,
                       of.IdCapilla,
                       of.Activo,
                       of.FechaCreacion
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar CEB", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_CEB_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar CEB", ex);
            }
        }
    }
}
