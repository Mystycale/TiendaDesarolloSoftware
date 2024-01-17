using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            string cajrID = txtCAJR.Text + txtCAJRID.Text;  
            string contra = txtContraseña.Text;

            int resultado = AutenticarCajero(cajrID, contra);

            if (resultado == 1)
            {
                FuncionesGenerales.abrirVentana(new FormCajaPrincipal(), panelLogin);
            }
            else
            {
                MessageBox.Show("Inicio de sesión fallido. Credenciales incorrectas.");
            }
        }

        private void btnIngresarAdmin_Click(object sender, EventArgs e)
        {
            if(txtAdminUser.Text == "ADMIN" && txtAdminContra.Text == "Admin01")
            {
                FuncionesGenerales.abrirVentana(new FormRegistrarCajero(), panelLogin);
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }

        }

        private void panelLogin_Click(object sender, EventArgs e)
        {
            gpAdmin.Visible = false;
        }

        #endregion

        #region Propiedades
        private void txtCAJRID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnMostrarContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '\0';
        }

        private void btnMostrarContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }
        #endregion

        #region Funciones

        private int AutenticarCajero(string cajrID, string contra)
        {
            int resultado = -1;  // Valor predeterminado para un resultado no válido

            // Usar la conexión y ejecutar el procedimiento almacenado
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("AutenticarCajero", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoCajero", cajrID);
                        cmd.Parameters.AddWithValue("@Contrasena", contra);

                        // Obtener el resultado del procedimiento almacenado
                        resultado = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al autenticar: " + ex.Message);
                }
            }
            return resultado;
        }

        #endregion
    }
}
