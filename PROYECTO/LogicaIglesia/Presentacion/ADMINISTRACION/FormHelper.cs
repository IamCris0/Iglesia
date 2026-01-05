using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.ADMINISTRACION
{
    public static class FormHelper
    {
        public static int ObtenerIdSeleccionado(DataGridView dgv)
        {
            if (dgv == null || dgv.CurrentRow == null)
                throw new Exception("No hay fila seleccionada");

            return Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
        }

        public static void ListarGenerico<T>(
        Func<string, List<T>> metodoListar,
        DataGridView dgv,
        string filtro)
            {
                dgv.DataSource = null;
                dgv.AutoGenerateColumns = true;
                dgv.DataSource = metodoListar(filtro);
            }


        public static bool EliminarGenerico(
        DataGridView dgv,
        Func<int, bool> metodoEliminar)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dgv);
            return metodoEliminar(id);
        }

        public static T BuscarPorIdGenerico<T>(
        DataGridView dgv,
        Func<int, T> metodoBuscar)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dgv);
            return metodoBuscar(id);
        }

        public static void SetearEstadoFormulario(
        EstadoFormulario estado,
        Button btnInsertar,
        Button btnModificar,
        Button btnEliminar,
        Button btnGuardar,
        Button btnCancelar,
        params Control[] controlesEdicion
)
        {
            bool enEdicion = estado != EstadoFormulario.Listando;

            // Botones principales
            btnInsertar.Enabled = !enEdicion;
            btnModificar.Enabled = !enEdicion;
            btnEliminar.Enabled = !enEdicion;

            // Botones de acción
            btnGuardar.Visible = enEdicion;
            btnCancelar.Visible = enEdicion;

            // Colores
            Color colorActivo = Color.FromArgb(255, 152, 0);
            Color colorInactivo = Color.White;

            btnInsertar.BackColor = enEdicion ? colorInactivo : colorActivo;
            btnModificar.BackColor = enEdicion ? colorInactivo : colorActivo;
            btnEliminar.BackColor = enEdicion ? colorInactivo : colorActivo;

            // Controles de edición (labels, combos, textbox, etc.)
            foreach (var control in controlesEdicion)
            {
                if ((int)estado != 2) 
                control.Visible = !enEdicion;
                control.Enabled = enEdicion;
            }
        }
    }
}
