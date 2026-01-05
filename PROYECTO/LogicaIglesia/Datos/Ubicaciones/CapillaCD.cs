using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ubicaciones
{
    public class CapillaCD
    {
        public static List<sp_Capilla_ListarResult> Listar(string filtro)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Capilla_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Capilla", ex);
            }
        }

        public static sp_Capilla_BuscarPorIdResult BuscarPorId(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Capilla_BuscarPorId(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al buscar Capilla por Id", ex);
            }
        }

        public static int Insertar(Entidades.Ubicaciones.Capilla oc)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    var result = db.sp_Capilla_Insert(
                        oc.Nombre,
                        oc.Direccion,
                        oc.IdParroquia
                    );
                    
                    return (int)result.Single().IdCapilla;
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Capilla", ex);
            }
        }

        public static void Modificar(Entidades.Ubicaciones.Capilla oc)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Capilla_Update(
                        oc.IdCapilla,
                        oc.Nombre,
                        oc.Direccion,
                        oc.IdParroquia,
                        oc.IdLaicoCoordinador
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Capilla", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Capilla_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Capilla", ex);
            }
        }

        public static bool AsignarCoordinador(int idCapilla, int idLaicoNuevo)
        {

            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Capilla_AsignarCoordinador(idCapilla, idLaicoNuevo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al buscar Capilla por Id", ex);
            }
        }
    }
}
