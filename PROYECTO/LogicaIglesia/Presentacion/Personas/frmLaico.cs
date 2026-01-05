using Datos.LinqToSQL;
using Entidades.Personas;
using Entidades.Personas.Vistas;
using Entidades.Ubicaciones;
using Entidades.Ubicaciones.Vistas;
using Logica.Personas;
using Logica.Ubicaciones;
using Presentacion.ADMINISTRACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Personas
{
    public partial class frmLaico : Form
    {
        public frmLaico(bool coordinador)
        {
            InitializeComponent();
            asignar = coordinador;
        }

        
        LaicoLN lln = new LaicoLN();
        CapillaLN cln = new CapillaLN();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;
        private bool asignar = false;
        public Entidades.Personas.Laico laicoop = new Entidades.Personas.Laico();
        public int IDLAICO = 0;

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
            btnCancelar
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

        public void Listar (string valor)
        {
            FormHelper.ListarGenerico(lln.Listar, dataGridView1, valor);
        }

        public void Delete ()
        {
            FormHelper.EliminarGenerico(dataGridView1, lln.Eliminar);
        }

        public Entidades.Personas.Laico CrearLaico()
        {
            return new Entidades.Personas.Laico
            {
                Nombres = textBox1.Text,
                Apellidos = textBox2.Text,
                Telefono = textBox3.Text,
                idCapilla = asignar ? (int)comboBox1.SelectedValue : 0,
                Activo = true
            };
        }

        public void GuardarNuevo()
        {
            laicoop = CrearLaico();
            IDLAICO = lln.Insertar(laicoop);

            if (asignar)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            FinalizarOperacion();
        }

        public void GuardarModificacion()
        {
            laicoop = CrearLaico();
            laico.idLaico = FormHelper.ObtenerIdSeleccionado(dataGridView1);

            lln.Modificar(laico);
            FinalizarOperacion();
        }

        private void FinalizarOperacion()
        {
            SetearTextos(false);
            estadoActual = EstadoFormulario.Listando;
            AccionFrm(estadoActual);
            Listar("");
        }

        private void frmLaico_Load(object sender, EventArgs e)
        {
            Listar("");
            FormatearAnchoFilas(dataGridView1);
            if (asignar)
            CargarCapillas("");
        }


        public void CargarCapillas(string valor)
        {
            List<VCapilla> listaCapilla = cln
            .Listar(valor)
            .OrderBy(l => l.Nombre)
            .ToList();
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCapilla";
            comboBox1.DataSource = listaCapilla;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            estadoActual = EstadoFormulario.Insertando;
            AccionFrm(estadoActual);
            SetearTextos(true);
        }

        public Entidades.Personas.Laico laico;

        private void button5_Click(object sender, EventArgs e)
        {
            if (estadoActual == EstadoFormulario.Modificando)
                    GuardarModificacion();
                else if (estadoActual == EstadoFormulario.Insertando)
                    GuardarNuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estadoActual = EstadoFormulario.Modificando;
            AccionFrm(estadoActual);
            SetearTextos(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            laico = lln.ObtenerPorId(id);
        }
    }
}
