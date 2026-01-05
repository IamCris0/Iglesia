using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Roles
{
    public class LaicoRolFuncionalCD
    {
        public static List<sp_LaicoRolFuncional_ListarResult> Listar(string filtro)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_LaicoRolFuncional_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar LaicoRolFuncional", ex);
            }
        }

        public static sp_LaicoRolFuncional_BuscarPorIdResult BuscarPorId(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_LaicoRolFuncional_BuscarPorId(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al buscar LaicoRolFuncional por Id", ex);
            }
        }

        public static void Insertar(Entidades.Roles.LaicoRolFuncional oc)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoRolFuncional_Insert(
                        oc.IdLaico,
                        oc.IdRolFuncional);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar LaicoRolFuncional", ex);
            }
        }

        public static void Modificar(Entidades.Roles.LaicoRolFuncional oc)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoRolFuncional_Update(
                        oc.IdLaicoRolFuncional,
                        oc.IdLaico,
                        oc.IdRolFuncional);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar LaicoRolFuncional", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_LaicoRolFuncional_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar LaicoRolFuncional", ex);
            }
        }
    }
}
