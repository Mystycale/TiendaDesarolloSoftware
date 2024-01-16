using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    public partial class FormLogin : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormLogin()
        {
            InitializeComponent();
            gpAdmin.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Info("La aplicacion ha subido"); //ejemplo de como usar el log
            //log.Error("");
            //log.Debug("");
        }

        #region Botones

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (gpAdmin.Visible == false)
            {
                gpAdmin.Visible = true;
            }
            else { gpAdmin.Visible = false; }
        }

        private void btnMostrarContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '\0';
        }

        private void btnMostrarContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            FuncionesGenerales.abrirVentana(new FormCajaPrincipal(), panelLogin);
        }

        private void btnIngresarAdmin_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana(new FormRegistrarCajero(), panelLogin);
        }

        private void panelLogin_Click(object sender, EventArgs e)
        {
            gpAdmin.Visible = false;
        }

        #endregion

    }
}
