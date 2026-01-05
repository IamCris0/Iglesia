using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Formacion
{
    public class FormacionCD
    {
        public static List<sp_Formacion_ListarResult> Listar(string filtro)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_Formacion_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Formacion", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_Formacion_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Formacion_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Formacion.Formacion of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Formacion_Insert(
                        of.Nombre,
                        of.Descripcion
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Formacion", ex);
            }
        }

        public static void Modificar(Entidades.Formacion.Formacion of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Formacion_Update(
                        of.IdFormacion,
                        of.Nombre,
                        of.Descripcion                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Formacion", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Formacion_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Formacion", ex);
            }
        }
    }
}
