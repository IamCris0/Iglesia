using Logica.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Seguridad
{
    public partial class frmAdminRolSistema : Form
    {
        public frmAdminRolSistema()
        {
            InitializeComponent();
        }

        RolSistemaLN rln = new RolSistemaLN();

        private void frmAdminRolSistema_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rln.Listar();
        }
    }
}
