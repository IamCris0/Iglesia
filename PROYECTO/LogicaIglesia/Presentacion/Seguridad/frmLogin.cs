using Entidades.Seguridad;
using Logica.Seguridad;
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


namespace Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        public string ObtenerHash (string password)
        {
            return uln.HashSHA256(password);
        }

        public void CambiarContraseñas (string valor)
        {
            Usuario usuario = uln.ObtenerPorId(5);
            Usuario nuevo = new Usuario(usuario.IdUsuario, usuario.Email,
                ObtenerHash(valor), usuario.IdLaico, usuario.IdSacerdote);
            uln.Modificar(nuevo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        UsuarioLN uln = new UsuarioLN();    
        private void CentrarPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text;
            string contraseña = textBox2.Text;
        
            Usuario usuario = uln.ObtenerPorMail(mail);
            bool existe = usuario != null;


            if (existe) 
            {
                string contraseñaBD = usuario.PasswordHash;
                bool esValida = uln.HashSHA256(contraseña) == contraseñaBD;

                if (esValida)
                {
                    frmAdmin frm = new frmAdmin();
                    frm.Show();
                    this.Hide();
                } else
                {
                    label4.Text = "Error. Contraseña Incorrecta.";
                    textBox2.Clear();
                }
            } else
            {
                label4.Text = "Error. Usuario no Encontrado.";
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnIngresar.PerformClick(); 
            }
        }
    }
}
