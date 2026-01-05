using Entidades.Personas.Vistas;
using Entidades.Roles;
using Entidades.Ubicaciones;
using Logica.Personas;
using Logica.Roles;
using Logica.Ubicaciones;
using Presentacion.ADMINISTRACION;
using Presentacion.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Ubicaciones
{
    public partial class frmAdminCapilla : Form
    {
        public frmAdminCapilla()
        {
            InitializeComponent();
        }

        CapillaLN cln = new CapillaLN();
        LaicoLN lln = new LaicoLN();
        LaicoRolFuncionalLN lrfln = new LaicoRolFuncionalLN();
        Capilla capilla = new Capilla();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;
        int IDCAPILLA = 0;



        public void Listar(string valor)
        {
            FormHelper.ListarGenerico(cln.Listar, dataGridView1, valor);
            FormatearAnchoFilas(dataGridView1);
            dataGridView1.Columns["Parroquia"].Visible = false;
            dataGridView1.Columns["IdCapilla"].Visible = false;
            label6.Text = "ADMIN CAPILLA";
        }

        public void Eliminar ()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una capilla para eliminar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la capilla seleccionada?\n" +
                    "Se eliminarán también sus dependencias.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    FormHelper.EliminarGenerico(dataGridView1, cln.Eliminar);
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
            comboBox1.DataSource = null;
        }

        public void AccionFrm(EstadoFormulario accion)
        {
            FormHelper.SetearEstadoFormulario(
            accion,
            btnInsertar,
            btnModificar,
            btnEliminar,
            btnGuardar,
            btnCancelar,
            label2, // opcional
            comboBox1 // opcional
            );
        }

        public void SetearTextos(bool enable)
        {
            textBox1.Enabled = enable;
            textBox2.Enabled = enable;
            comboBox1.Enabled = enable;
        }

        private void FormatearAnchoFilas(DataGridView dataGV)
        {
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void CargarLaicos(string valor)
        {
            List<VLaico> listaLaicos = lln
                .Listar(valor)
                .OrderBy(l => l.Nombres)
                .ToList();
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "NombreCompleto";
            comboBox1.ValueMember = "idLaico";
            comboBox1.DataSource = listaLaicos;
        }
        private void frmAdminCapilla_Load(object sender, EventArgs e)
        {
            Listar("");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAdminCapilla_SizeChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            capilla = cln.ObtenerPorId(id);

            textBox1.Text = capilla.Nombre;
            textBox2.Text = capilla.Direccion;

            CargarLaicos(capilla.Nombre);

            comboBox1.SelectedValue = capilla.IdLaicoCoordinador;
        }

       

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            estadoActual = EstadoFormulario.Insertando;
            AccionFrm(estadoActual);
            SetearTextos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoFormulario.Modificando)
                GuardarModificacion();
            else if (estadoActual == EstadoFormulario.Insertando)
                GuardarNuevaCapilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos(false);
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

        private void GuardarNuevaCapilla()
        {
            capilla = ConstruirCapilla();
            IDCAPILLA = cln.Insertar(capilla);

            AsignarCoordinador(capilla);

            FinalizarOperacion();
        }

        private Capilla ConstruirCapilla()
        {
            return new Capilla(
                textBox1.Text,
                textBox2.Text,
                1 // idParroquia
            );
        }

        private Capilla ConstruirCapillaModificada()
        {
            return new
                Capilla(
                FormHelper.ObtenerIdSeleccionado(dataGridView1),
                textBox1.Text,
                textBox2.Text,
                1,
                (int)comboBox1.SelectedValue
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
            capilla = ConstruirCapillaModificada();
            cln.Modificar(capilla);

            ActualizarCoordinador();

            FinalizarOperacion();
        }


        private void AsignarCoordinador(Capilla capilla)
        {
            using (frmLaico frm = new frmLaico(true))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int idCapilla = IDCAPILLA;
                    int idLaico = frm.IDLAICO;
                    cln.AsignarCoordinador(idCapilla, idLaico);

                }
            }
        }

        public void ActualizarCoordinador()
        {
            int idCapilla = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            int idCoordinador = (int)comboBox1.SelectedValue;

            cln.AsignarCoordinador(idCapilla, idCoordinador);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdmin.Regresar();
        }
    }
}
