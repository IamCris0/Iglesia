using Datos.Finanzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Finanzas
{
    public class MovimientoCEBLN
    {
        public List<Entidades.Finanzas.Vistas.VMovimientoCEB> Listar(String dato)
        {
            List<Entidades.Finanzas.Vistas.VMovimientoCEB> lista =
                new List<Entidades.Finanzas.Vistas.VMovimientoCEB>();

            try
            {
                var datos = MovimientoCEBCD.Listar(dato);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Finanzas.Vistas.VMovimientoCEB(
                        item.idMovimientoCEB,
                        item.CEB,
                        item.FondoCapilla,
                        item.EventoCapilla,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar MovimientoCEB", ex);
            }

            return lista;
        }

        public void Insertar(Entidades.Finanzas.MovimientoCEB fc)
        {
            try
            {
                MovimientoCEBCD.Insertar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar MovimientoCEB", ex);
            }
        }

        public void Modificar(Entidades.Finanzas.MovimientoCEB fc)
        {
            try
            {
                MovimientoCEBCD.Modificar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar MovimientoCEB", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                MovimientoCEBCD.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar MovimientoCEB", ex);
            }
        }

        public Entidades.Finanzas.MovimientoCEB ObtenerPorId(int id)
        {
            try
            {
                var item = MovimientoCEBCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Finanzas.MovimientoCEB(
                        item.idMovimientoCEB,
                        item.idCEB,
                        (int)item.idFondoCapilla,
                        (int)item.idEventoCapilla,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener MovimientoCEB", ex);
            }
        }
    }
}
