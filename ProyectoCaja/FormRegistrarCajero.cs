using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCaja
{
    public partial class FormRegistrarCajero : Form
    {
        public FormRegistrarCajero()
        {
            InitializeComponent();

            cmbSucursales.Items.AddRange(new string[] { "Principal", "Sucursal 2", "Sucursal 3", "Sucursal 4" });
            cmbSucursales.SelectedIndex = 0;
        }

        #region Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string cajrID, cajrContra, cajrSucursal, cajrNombre, cajrApellido, cajrCedula, cajrTelefono, cajrDireccion;
            DateTime fechaIngreso;

            cajrID = txtCAJR.Text + txtCAJRID.Text;
            cajrContra = txtContra.Text;
            cajrSucursal = cmbSucursales.Text;
            cajrNombre = txtNombre.Text;
            cajrApellido = txtApellido.Text;
            cajrCedula = txtCedula.Text;
            cajrTelefono = txtTelefono.Text;
            cajrDireccion = txtDireccion.Text;
            fechaIngreso = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
            {
                {
                    try
                    {
                        connection.Open();

                        // Crear un objeto SqlCommand para el stored procedure
                        using (SqlCommand cmd = new SqlCommand("spInsertarCajero", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agregar parámetros al stored procedure
                            cmd.Parameters.AddWithValue("@cjr_id", cajrID);
                            cmd.Parameters.AddWithValue("@cjr_cedula", cajrCedula);
                            cmd.Parameters.AddWithValue("@cjr_nombre", cajrNombre);
                            cmd.Parameters.AddWithValue("@cjr_apellido", cajrApellido);
                            cmd.Parameters.AddWithValue("@cjr_telefono", cajrTelefono);
                            cmd.Parameters.AddWithValue("@cjr_direccion", cajrDireccion);
                            cmd.Parameters.AddWithValue("@cjr_fechaIngreso", fechaIngreso);
                            cmd.Parameters.AddWithValue("@cjr_sucursal", cajrSucursal);
                            cmd.Parameters.AddWithValue("@cjr_contra", cajrContra);
                            cmd.Parameters.AddWithValue("@cjr_estado", 1);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Datos insertados correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al insertar datos: " + ex.Message);
                    }
                }
            }
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

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}
