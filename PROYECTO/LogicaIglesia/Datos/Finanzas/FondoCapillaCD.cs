using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Finanzas
{
    public class FondoCapillaCD
    {
        public static List<sp_FondoCapilla_ListarResult> Listar(string filtro)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_FondoCapilla_Listar(filtro).ToList();
            }
        }

        public static sp_FondoCapilla_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_FondoCapilla_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(FondoCapilla fc)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoCapilla_Insert(
                    fc.idFondoCapilla,
                    fc.Nombre,
                    fc.Descripcion,
                    fc.idCapilla,
                    fc.Saldo
                );
            }
        }

        public static void Modificar(FondoCapilla fc)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoCapilla_Update(
                    fc.idFondoCapilla,
                    fc.Nombre,
                    fc.Descripcion,
                    fc.idCapilla,
                    fc.Saldo
                );
            }
        }

        public static void Eliminar(int id)
        {
            using (var db = new DControlDataContext())
            {
                db.sp_FondoCapilla_Delete(id);
            }
        }

        public static void Insertar(Entidades.Finanzas.FondoCapilla fc)
        {
            throw new NotImplementedException();
        }

        public static void Modificar(Entidades.Finanzas.FondoCapilla fc)
        {
            throw new NotImplementedException();
        }
    }
}
