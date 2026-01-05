using Datos.LinqToSQL;
using Entidades.Ubicaciones.Vistas;
using Logica.Configuracion;
using Logica.Eventos;
using Logica.Ubicaciones;
using Presentacion.ADMINISTRACION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion.Eventos
{
    public partial class frmAdminMisa : Form
    {
        public frmAdminMisa()
        {
            InitializeComponent();
        }


        HorarioMisaLN fln = new HorarioMisaLN();
        CapillaLN cln = new CapillaLN();
        MisaLN mln = new MisaLN();
        Entidades.Configuracion.HorarioMisa horarioMisa = new Entidades.Configuracion.HorarioMisa();
        private EstadoFormulario estadoActual = EstadoFormulario.Listando;



        public void bloquear ()
        {
            comboBox5.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            checkBox1.Enabled = false;
        }

        public void Listar(string valor)
        {
            FormHelper.ListarGenerico(fln.Listar, dataGridView1, valor);
            FormatearAnchoFilas(dataGridView1);
            dataGridView1.Columns["IdHorarioMisa"].Visible = false;
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una HorarioMisa para eliminar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la HorarioMisa seleccionada?\n" +
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
            checkBox1.Checked = false;
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
            comboBox1.Enabled = enable;
            comboBox5.Enabled = enable;
            checkBox1 .Enabled = enable;    
            comboBox2.Enabled = enable;
        }

        private void FormatearAnchoFilas(DataGridView dataGV)
        {
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void GuardarMisa()
        {
            horarioMisa = ConstruirHorarioMisa();
            fln.Insertar(horarioMisa);


            FinalizarOperacion();
        }

        private Entidades.Configuracion.HorarioMisa ConstruirHorarioMisa()
        {
            return new Entidades.Configuracion.HorarioMisa(
                (int)comboBox1.SelectedValue,
                comboBox5.SelectedIndex + 1,
                (TimeSpan)comboBox2.SelectedItem
            );
        }

        private Entidades.Configuracion.HorarioMisa ConstruirHorarioMisaModificada()
        {
            string activo = checkBox1.Checked ? "SI": "NO" ;
            return new
                Entidades.Configuracion.HorarioMisa(
                FormHelper.ObtenerIdSeleccionado(dataGridView1),
                (int)comboBox1.SelectedValue,
                comboBox5.SelectedIndex + 1,
                (TimeSpan)comboBox2.SelectedItem,
                activo
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
            horarioMisa = ConstruirHorarioMisaModificada();
            fln.Modificar(horarioMisa);
            FinalizarOperacion();
        }


        public void CargarCapillas(string valor)
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

        private void frmAdminMisa_Load(object sender, EventArgs e)
        {
            Listar("");
            bloquear();
            CargarCapillas("");
            CargarHorarios();
        }

        private void CargarHorarios()
        {
            comboBox2.Items.Clear();

            comboBox2.Items.Add(new TimeSpan(8, 0, 0));
            comboBox2.Items.Add(new TimeSpan(9, 0, 0));
            comboBox2.Items.Add(new TimeSpan(10, 0, 0));
            comboBox2.Items.Add(new TimeSpan(17, 0, 0));
            comboBox2.Items.Add(new TimeSpan(18, 0, 0));
            comboBox2.Items.Add(new TimeSpan(19, 0, 0));
            comboBox2.Format += (s, e) =>
            {
                e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm");
            };
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
                GuardarMisa();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AccionFrm(EstadoFormulario.Listando);
            SetearTextos(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = FormHelper.ObtenerIdSeleccionado(dataGridView1);
            horarioMisa = fln.ObtenerPorId(id);
            comboBox1.SelectedValue = horarioMisa.IdCapilla;
            comboBox5.SelectedIndex = horarioMisa.DiaSemana - 1;
            comboBox2.SelectedValue = horarioMisa.Hora;
            checkBox1.Checked = horarioMisa.Activo.Equals("SI");
            dateTimePicker1.Value = DateTime.Today.Add(horarioMisa.Hora);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label8.Visible = true;
            label9.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MisasAutomaticas("Semanales");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MisasAutomaticas("Mensuales");
        }

        public void MisasAutomaticas (string valor)
        {
            var r = MessageBox.Show(
            "¿Desea generar las misas " + valor + " automáticamente?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (r != DialogResult.Yes)
                return;

            if (valor.Equals("Semanales"))
            {
                DateTime fechaInicio = DateTime.Today;
                DateTime fechaFin = fechaInicio.AddDays(7);
                mln.GenerarAutomatico(fechaInicio, fechaFin);
            } else
            {
                DateTime fechaInicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);
                mln.GenerarAutomatico(fechaInicio,fechaFin);

            }

            MessageBox.Show(
            "Misas " + valor + " generadas correctamente",
            "Éxito",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }
    }
}
