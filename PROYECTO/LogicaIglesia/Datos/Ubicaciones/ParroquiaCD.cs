using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ubicaciones
{
    public class ParroquiaCD
    {
        public static List<sp_Parroquia_ListarResult> Listar()
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Parroquia_Listar().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar parroquias", ex);
            }
        }

        public static sp_Parroquia_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Parroquia_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Ubicaciones.Parroquia p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Parroquia_Insert(p.Nombre, p.Zona);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar parroquia", ex);
            }
        }

        public static void Modificar(Entidades.Ubicaciones.Parroquia p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Parroquia_Update(p.IdParroquia, p.Nombre, p.Zona);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar parroquia", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Parroquia_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar parroquia", ex);
            }
        }
    }
}
