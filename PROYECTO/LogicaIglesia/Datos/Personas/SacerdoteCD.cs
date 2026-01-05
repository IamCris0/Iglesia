using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Personas
{
    public class SacerdoteCD
    {
        public static List<sp_Sacerdote_ListarResult> Listar()
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Sacerdote_Listar().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Sacerdotes", ex);
            }
        }

        public static sp_Sacerdote_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Sacerdote_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Personas.Sacerdote item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    var result = db.sp_Sacerdote_Insert(
                        item.Nombres,
                        item.Apellidos,
                        item.Apodo
                    );
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Sacerdote", ex);
            }
        }

        public static void Modificar(Entidades.Personas.Sacerdote item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Sacerdote_Update(
                        item.IdSacerdote,
                        item.Nombres,
                        item.Apellidos,
                        item.Apodo
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Sacerdote", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Sacerdote_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Sacerdote", ex);
            }
        }
    }
}
