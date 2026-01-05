using Datos.LinqToSQL;
using Entidades.Formacion;
using Entidades.Personas.Vistas;
using Entidades.Ubicaciones.Vistas;
using Logica.Comunidades;
using Logica.Ubicaciones;
using Presentacion.ADMINISTRACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion.Comunidades
{
    public partial class frmAdminCEB : Form
    {
        public frmAdminCEB()
        {
            InitializeComponent();
        }

        CEBLN cebln = new CEBLN();
        Entidades.Comunidades.CEB ceb = new Entidades.Comunidades.CEB();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;
        CapillaLN cln = new CapillaLN();


        public void CargarCapillas (string valor)
        {
            List<VCapilla> lista = cln
                .Listar(valor)
                .OrderBy(l => l.Nombre)
                .ToList();
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "idCapilla";
            comboBox1.DataSource = lista;
        }


        public void Listar(string valor)
        {
            FormHelper.ListarGenerico(cebln.Listar, dataGridView1, valor);
            FormatearAnchoFilas(dataGridView1);
            dataGridView1.Columns["IdCEB"].Visible = false;
            dataGridView1.Columns["Activo"].Visible = false;
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una CEB para eliminar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la CEB seleccionada?\n",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    FormHelper.EliminarGenerico(dataGridView1, cebln.Eliminar);
                    Listar("");
                    SetearTextos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void SetearTextos()
        {
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        public void AccionFrm(EstadoFormulario accion)
        {
            FormHelper.SetearEstadoFormulario(
            accion,
            btnInsertar,
            btnModificar,
            btnEliminar,
            btnGuardar,
            btnCancelar
            );
        }

        public void SetearTextos(bool enable)
        {
            textBox1.Enabled = enable;
            comboBox1.Enabled = enable;
            dateTimePicker1.Enabled = enable;
            checkBox1.Enabled = enable;
        }

        private void FormatearAnchoFilas(DataGridView dataGV)
        {
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void frmAdminCEB_Load(object sender, EventArgs e)
        {
            Listar("");
            CargarCapillas("");
        }

        private void GuardarCEB()
        {
            ceb = ConstruirCEB();
            cebln.Insertar(ceb);


            FinalizarOperacion();
        }

        private Entidades.Comunidades.CEB ConstruirCEB()
        {
            return new Entidades.Comunidades.CEB(
                        textBox1.Text,
                        (int)comboBox1.SelectedValue,
                        true,
                        dateTimePicker1.Value
            );
        }

        private Entidades.Comunidades.CEB ConstruirCEBModificada()
        {
            return new
                Entidades.Comunidades.CEB(
                        FormHelper.ObtenerIdSeleccionado(dataGridView1),
                        textBox1.Text,
                        (int)comboBox1.SelectedValue,
                        checkBox1.Checked,
                        dateTimePicker1.Value
            );
        }

        private void FinalizarOperacion()
        {
            SetearTextos(false);
            estadoActual = EstadoFormulario.Listando;
            AccionFrm(estadoActual);
            Listar("");
        }


        private void GuardarModificacion()
        {
            ceb = ConstruirCEBModificada();
            cebln.Modificar(ceb);


            FinalizarOperacion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdmin.Regresar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            estadoActual = EstadoFormulario.Insertando;
            AccionFrm(estadoActual);
            SetearTextos(true);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estadoActual = EstadoFormulario.Modificando;
            AccionFrm(estadoActual);
            SetearTextos(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoFormulario.Modificando)
                GuardarModificacion();
            else if (estadoActual == EstadoFormulario.Insertando)
                GuardarCEB();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            ceb = cebln.ObtenerPorId(id);

            textBox1.Text = ceb.Nombre;
            comboBox1.SelectedValue = ceb.IdCapilla;
            checkBox1.Checked = ceb.Activo;
            dateTimePicker1.Value = ceb.FechaCreacion.ToLocalTime();
        }
    }
}
