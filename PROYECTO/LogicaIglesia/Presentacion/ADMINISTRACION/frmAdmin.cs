using Presentacion.Comunidades;
using Presentacion.Configuracion;
using Presentacion.Eventos;
using Presentacion.Formacion;
using Presentacion.Seguridad;
using Presentacion.Ubicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.ADMINISTRACION
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        public static frmParroquia op = new frmParroquia();


        public static void Regresar ()
        {
            op.panel3.Controls.Clear();
        }

        public void Fondo ()
        {
            panel1.Controls.Clear();

            op.TopLevel = false;
            op.FormBorderStyle = FormBorderStyle.None;
            op.Dock = DockStyle.Fill;

            panel1.Controls.Add(op);
            op.Show();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            Fondo();
        }

        public void InsertarFRM (Form frm)
        {
            op.panel3.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            op.panel3.Controls.Add(frm);
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void catequesisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormacion frm = new frmFormacion();
            InsertarFRM(frm);
        }

        private void rolSismteaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminRolSistema frm = new frmAdminRolSistema();
            InsertarFRM(frm);
        }

        private void capillasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdminCapilla frm = new frmAdminCapilla();
            InsertarFRM(frm);
        }

        private void comunidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminCEB frm = new frmAdminCEB();
            InsertarFRM(frm);
        }

        private void eventosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdminEventoCapilla frm = new frmAdminEventoCapilla();
            InsertarFRM(frm);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmConf frm = new frmConf();
            InsertarFRM(frm);
        }

        private void comunionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Comunion");
            InsertarFRM(frm);
        }

        private void infanciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Iniciacion Cristiana");
            InsertarFRM(frm);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmAdminMisa frm = new frmAdminMisa();
            InsertarFRM(frm);
        }

        private void bautizoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Bautizo");
            InsertarFRM(frm);
        }

        private void preJuvenilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Pre-Juvenil");
            InsertarFRM(frm);
        }

        private void confirmacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Confirmacion");
            InsertarFRM(frm);
        }

        private void matrimonioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRLaicoFormacion frm = new frmCRLaicoFormacion("Matrimonio");
            InsertarFRM(frm);
        }
    }
}
