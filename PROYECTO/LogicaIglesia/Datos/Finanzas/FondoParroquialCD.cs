using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Finanzas
{
    public class FondoParroquialCD
    {
        public static List<sp_FondoParroquial_ListarResult> Listar(string filtro)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_FondoParroquial_Listar(filtro).ToList();
            }
        }

        public static sp_FondoParroquial_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_FondoParroquial_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Finanzas.FondoParroquial fc)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoParroquial_Insert(
                    fc.Nombre,
                    fc.Descripcion,
                    fc.IdParroquia,
                    fc.Saldo
                );
            }
        }

        public static void Modificar(Entidades.Finanzas.FondoParroquial fc)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoParroquial_Update(
                    fc.IdFondoParroquial,
                    fc.Nombre,
                    fc.Descripcion,
                    fc.IdParroquia,
                    fc.Saldo
                );
            }
        }

        public static void Eliminar(int id)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoParroquial_Delete(id);
            }
        }

    }
}
