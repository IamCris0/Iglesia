using CrystalDecisions.CrystalReports.Engine;
using Datos.LinqToSQL;
using Datos.Ubicaciones;
using Entidades.Reportes;
using Entidades.Ubicaciones.Vistas;
using Logica.Reportes;
using Logica.Ubicaciones;
using Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formacion
{
    public partial class frmCRLaicoFormacion : Form
    {
        public frmCRLaicoFormacion(string formacion)
        {
            InitializeComponent();
            CargarCapillas("");
            label6.Text = $"Catequesis de {formacion}";
            this.formacion = formacion;
            comboBox1.SelectedIndex = 0;
            isCargando = false; 
        }

        string formacion = "";
        VReporteLaicoDetalleLN vrldln = new VReporteLaicoDetalleLN();
        DBC ds = new DBC();
        Dictionary<string, int> dicFormaciones = new Dictionary<string, int>
        {
            { "Iniciacion Cristiana", 1 },
            { "Comunion", 2 },
            { "Pre-Juvenil", 3 },
            { "Confirmacion", 4 },
            { "Bautizo", 5 },
            { "Matrimonio", 6 }
        };
        CapillaLN cln = new CapillaLN();


        public void CargarCapillas(string valor)
        {
            List<VCapilla> listaCapilla = cln
                .Listar(valor)
                .OrderBy(l => l.Nombre)
                .ToList();

            VCapilla opcionVacia = new VCapilla();
            opcionVacia.IdCapilla = 0; 
            opcionVacia.Nombre = "--- Seleccione una Capilla ---";

            listaCapilla.Insert(0, opcionVacia);

            comboBox2.DataSource = null;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdCapilla";
            comboBox2.DataSource = listaCapilla;

            comboBox2.SelectedIndex = 0;
        }
        public void GenerarReporte(string laico, int? idCapilla, string estado)
        {
            try
            {
                ds.sp_Reporte_Laico_Detalle.Clear();

                if (string.IsNullOrEmpty(this.formacion) || !dicFormaciones.ContainsKey(this.formacion))
                {
                    return;
                }

                int idFormacion = dicFormaciones[this.formacion];

                List<VReporteLaicoDetalle> le = vrldln.Listar(laico, idCapilla, idFormacion, estado);

                if (le == null || le.Count == 0)
                {
                    crystalReportViewer1.ReportSource = null; // Limpiamos el visor si no hay datos
                    return;
                }

                foreach (VReporteLaicoDetalle item in le)
                {
                    var row = ds.sp_Reporte_Laico_Detalle.Newsp_Reporte_Laico_DetalleRow();

                    row.Laico = item.Laico;
                    row.Capilla = item.Capilla ?? "N/A";
                    row.Formacion = item.Formacion ?? "N/A";
                    row.EstadoFormacion = item.EstadoFormacion ?? "N/A";

                    if (item.FechaInicioFormacion.HasValue)
                        row.FechaInicioFormacion = item.FechaInicioFormacion.Value;

                    if (item.FechaFinFormacion.HasValue)
                        row.FechaFinFormacion = item.FechaFinFormacion.Value;

                    row.RolFuncional = item.RolFuncional ?? "N/A";

                    ds.sp_Reporte_Laico_Detalle.Addsp_Reporte_Laico_DetalleRow(row);
                }

                CRLaicoFormacion cr = new CRLaicoFormacion();
                cr.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCRLaicoFormacion_Load(object sender, EventArgs e)
        {
            GenerarReporte("", null, "");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? idCapilla = (int)comboBox2.SelectedValue;
            if (idCapilla == 0)
                idCapilla = null;

            string estado = comboBox1.Text;
            if (estado.Equals("--- Seleccione un Estado ---"))
                estado = "";

            GenerarReporte(textBox1.Text, idCapilla, estado);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? idCapilla = (int)comboBox2.SelectedValue;
            if (idCapilla == 0)
                idCapilla = null;

            string estado = comboBox1.Text;
            if (estado.Equals("--- Seleccione un Estado ---"))
                estado = "";

            GenerarReporte(textBox1.Text, idCapilla, estado);
        }

        bool isCargando = true;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void timerBusqueda_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int? idCapilla = (int)comboBox2.SelectedValue;
                if (idCapilla == 0)
                    idCapilla = null;

                string estado = comboBox1.Text;
                if (estado.Equals("--- Seleccione un Estado ---"))
                    estado = "";

                GenerarReporte(textBox1.Text, idCapilla, estado);
            }
        }
    }
}
