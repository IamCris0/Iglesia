using Entidades.Formacion;
using Entidades.Personas.Vistas;
using Logica.Formacion;
using Logica.Personas;
using Logica.Roles;
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

namespace Presentacion.Formacion
{
    public partial class frmFormacion : Form
    {
        public frmFormacion()
        {
            InitializeComponent();
        }


        FormacionLN fln = new FormacionLN();
        Entidades.Formacion.Formacion formacion = new Entidades.Formacion.Formacion();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;



        public void Listar(string valor)
        {
            FormHelper.ListarGenerico(fln.Listar, dataGridView1, valor);
            FormatearAnchoFilas(dataGridView1);
            dataGridView1.Columns["IdFormacion"].Visible = false;
            label6.Text = "ADMIN FORMACION";
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una Formacion para eliminar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la Formacion seleccionada?\n" +
                    "Se eliminarán también sus dependencias.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    FormHelper.EliminarGenerico(dataGridView1, fln.Eliminar);
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
            textBox2.Clear();
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
            textBox2.Enabled = enable;
        }

        private void FormatearAnchoFilas(DataGridView dataGV)
        {
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void frmFormacion_Load(object sender, EventArgs e)
        {
            Listar("");
        }

        private void GuardarNuevaFormacion()
        {
            formacion = ConstruirFormacion();
            fln.Insertar(formacion);


            FinalizarOperacion();
        }

        private Entidades.Formacion.Formacion ConstruirFormacion()
        {
            return new Entidades.Formacion.Formacion(
                        textBox1.Text,
                        textBox2.Text
            );
        }

        private Entidades.Formacion.Formacion ConstruirFormacionModificada()
        {
            return new
                Entidades.Formacion.Formacion(
                        FormHelper.ObtenerIdSeleccionado(dataGridView1),
                        textBox1.Text,
                        textBox2.Text
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
            formacion = ConstruirFormacionModificada();
            fln.Modificar(formacion);


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
                GuardarNuevaFormacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            formacion = fln.ObtenerPorId(id);

            textBox1.Text = formacion.Nombre;
            textBox2.Text = formacion.Descripcion;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
