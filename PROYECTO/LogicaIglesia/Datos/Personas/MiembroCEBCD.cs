using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Personas
{
    public class MiembroCEBCD
    {
        public static List<sp_MiembroCEB_ListarResult> Listar(string valor)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_MiembroCEB_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar MiembroCEBs", ex);
            }
        }

        public static sp_MiembroCEB_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_MiembroCEB_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Personas.MiembroCEB p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    var result = db.sp_MiembroCEB_Insert(
                            p.IdLaico,
                            p.IdCEB,
                            p.Activo,
                            p.FechaIngreso
                    );
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar MiembroCEB", ex);
            }
        }

        public static void Modificar(Entidades.Personas.MiembroCEB p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MiembroCEB_Update(
                             p.IdMiembroCEB,
                             p.IdLaico,
                             p.IdCEB,
                             p.Activo,
                             p.FechaIngreso
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar MiembroCEB", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MiembroCEB_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar MiembroCEB", ex);
            }
        }
    }
}
