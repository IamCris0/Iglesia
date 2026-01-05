using Datos.Eventos;
using Entidades.Eventos.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Eventos
{
    public class MisaLN
    {
        public List<Entidades.Eventos.Vistas.VMisa> Listar(string filtro)
        {
            List<Entidades.Eventos.Vistas.VMisa> lista = new List<VMisa>();

            try
            {
                var datos = MisaCD.Listar(filtro);

                var datosOrdenados = datos.OrderBy(x => x.Fecha).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Eventos.Vistas.VMisa(
                        item.idMisa,
                        item.Capilla,
                        item.Sacerdote,
                        item.Fecha,
                        item.MontoRecaudado ?? 0m,
                        item.Estado,
                        item.Sacramento ?? "NO"
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Misa", ex);
            }

            return lista;
        }

        public Entidades.Eventos.Misa ObtenerPorId(int id)
        {
            try
            {
                var item = MisaCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Eventos.Misa(
                    item.idMisa,
                    item.idCapilla,
                    item.idSacerdote,
                    item.Fecha,
                    item.MontoRecaudado ?? 0m, // 👈 Evita el error aquí también
                    item.Estado,
                    item.idSolicitudSacramental
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Misa", ex);
            }
        }

        public void Insertar(Entidades.Eventos.Misa oc)
        {
            try
            {
                 MisaCD.Insertar(oc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Misa", ex);
            }
        }

        public bool Modificar(Entidades.Eventos.Misa oc)
        {
            try
            {
                MisaCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Misa", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                MisaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Misa", ex);
            }
        }

        public void GenerarAutomatico(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                MisaCD.GenerarAutomatico(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al generar misas automáticamente", ex);
            }
        }
    }
}
