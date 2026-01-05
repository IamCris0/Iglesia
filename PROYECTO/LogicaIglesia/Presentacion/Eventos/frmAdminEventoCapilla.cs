using Logica.Eventos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Eventos
{
    public partial class frmAdminEventoCapilla : Form
    {
        public frmAdminEventoCapilla()
        {
            InitializeComponent();
        }

        EventoCapillaLN ecln = new EventoCapillaLN();

        public void Listar (string valor )
        {
            dataGridView1.DataSource = ecln.Listar(valor);
        }

        private void frmAdminEventoCapilla_Load(object sender, EventArgs e)
        {
            Listar("");
        }
    }
}
