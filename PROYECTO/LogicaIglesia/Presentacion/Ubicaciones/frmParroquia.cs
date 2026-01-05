using Entidades.Ubicaciones;
using Logica.Ubicaciones;
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
    public partial class frmParroquia : Form
    {
        public frmParroquia()
        {
            InitializeComponent();
        }

        ParroquiaLN pln = new ParroquiaLN();


        private void frmParroquia_Load(object sender, EventArgs e)
        {
            Parroquia op = pln.Listar()[0];
            label1.Text = op.Zona;            
        }
    }
}
