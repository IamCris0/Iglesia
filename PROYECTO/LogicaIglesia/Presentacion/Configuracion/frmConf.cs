using Logica.Eventos;
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

namespace Presentacion.Configuracion
{
    public partial class frmConf : Form
    {
        public frmConf()
        {
            InitializeComponent();
        }


        MisaLN fln = new MisaLN();
        Entidades.Eventos.Misa Misa = new Entidades.Eventos.Misa();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;



        public void Listar(string valor)
        {
            FormHelper.ListarGenerico(fln.Listar, dataGridView1, valor);
            FormatearAnchoFilas(dataGridView1);
            dataGridView1.Columns["IdMisa"].Visible = false;
            dataGridView1.Columns["Sacramento"].Visible = false;
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una Misa para eliminar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la Misa seleccionada?\n" +
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
        private void frmMisa_Load(object sender, EventArgs e)
        {
            Listar("");
        }

        private void GuardarNuevaMisa()
        {
            Misa = ConstruirMisa();
            fln.Insertar(Misa);


            FinalizarOperacion();
        }

        private Entidades.Eventos.Misa ConstruirMisa()
        {
            return new Entidades.Eventos.Misa(

            );
        }

        private Entidades.Eventos.Misa ConstruirMisaModificada()
        {
            return new
                Entidades.Eventos.Misa(
                

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
            Misa = ConstruirMisaModificada();
            fln.Modificar(Misa);


            FinalizarOperacion();
        }
        private void frmConf_Load(object sender, EventArgs e)
        {
            Listar("");
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
                GuardarNuevaMisa();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = comboBox1.Text;

            string men = valor.Substring(0, valor.Length - 1);

            if (valor == "TODAS")
                Listar("");
            else
                Listar(men);
        }
    }
}
