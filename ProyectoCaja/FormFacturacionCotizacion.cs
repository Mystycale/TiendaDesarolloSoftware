using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    public partial class FormFacturacionCotizacion : Form
    {
        public FormFacturacionCotizacion()
        {
            InitializeComponent();

            cmbCotizacion.Items.Add("No");
            cmbCotizacion.Items.Add("Si");
            btnBuscarProd.Enabled = false;
            cmbCotizacion.SelectedIndex = 0;
        }

        #region Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Propiedades
        private void txtPRODID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSERVID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCLIEID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            string codProd = txtPROD.Text + txtPRODID.Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando para ejecutar el stored procedure
                using (SqlCommand command = new SqlCommand("BuscarProductoPorCodigo", connection))
                {
                    // Especificar que el comando es un stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Añadir el parámetro de entrada (@codigo)
                    command.Parameters.AddWithValue("@codigo", codProd);

                    // Ejecutar el comando y obtener un lector de datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas en el resultado
                        if (reader.HasRows)
                        {
                            // Leer la primera fila
                            reader.Read();

                            // Mostrar el nombre y el precio en los textboxes
                            txtNomPROD.Text = reader["prod_nombre"].ToString();
                            txtPrePROD.Text = reader["prod_precio"].ToString();
                        }
                        else
                        {
                            // Si no se encontraron resultados, mostrar un mensaje
                            MessageBox.Show("Producto no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPrePROD.Clear();
                            txtPRODID.Clear();
                            txtNomPROD.Clear();
                        }
                    }
                }
            }
        }

        private void txtPRODID_TextChanged(object sender, EventArgs e)
        {
            if (txtPRODID.Text.Length < 6)
            {
                btnBuscarProd.Enabled = false;
            }
            else
            {
                btnBuscarProd.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codigo = txtSERV.Text + txtSERVID.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("BuscarServicio", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Codigo", codigo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string nombre = reader["serv_nombre"].ToString();
                                decimal precio = Convert.ToDecimal(reader["serv_precio"]);

                                txtNomSERV.Text = nombre;
                                txtPreSERV.Text = precio.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Servicio no encontrado");
                                txtSERVID.Clear();
                                txtNomSERV.Clear();
                                txtPreSERV.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string codCliente = txtCLIE.Text + txtCLIEID.Text;
            string nomCliente;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("BuscarClientePorCodigo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodigoCliente", codCliente);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nomCliente = reader["NombreCompleto"].ToString();
                                txtNomCLIE.Text = nomCliente;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string prodID = txtPROD.Text + txtPRODID.Text;
            string prodnom = txtNomPROD.Text;
            decimal prodPrecio = decimal.Parse(txtPrePROD.Text);
            int canProd = int.Parse(txtCanPROD.Text);

            string servID = txtSERV.Text + txtSERVID.Text;
            string servnom = txtNomSERV.Text;
            decimal servPrecio = decimal.Parse(txtPreSERV.Text);

            string clieID = txtCLIE.Text + txtCLIEID.Text;
            string clienom = txtNomCLIE.Text;

            string factID = txtFACT.Text + txtFACTID.Text;

            string cotizar = cmbCotizacion.Text;

            int metodoPago = 1;
            decimal total = servPrecio + prodPrecio;
            DateTime fecha = DateTime.Now;
            string codigoCajero = "CAJR000001";

            bool cotiz;

            if (cotizar == "Si")
            {
                cotiz = true;
            }
            else
            {
                cotiz = false;
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ppInsertFactura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenadod
                        command.Parameters.AddWithValue("@fct_codigo", factID);
                        command.Parameters.AddWithValue("@fct_cotizacion", cotiz);
                        command.Parameters.AddWithValue("@fct_fecha", fecha);
                        command.Parameters.AddWithValue("@fct_total", total);
                        command.Parameters.AddWithValue("@fct_metodoPago", metodoPago);
                        command.Parameters.AddWithValue("@fct_cjr_codigo", codigoCajero);
                        command.Parameters.AddWithValue("@fct_clt_codigo", clieID);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Factura insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormReporte formReporte = new FormReporte();

                        // Mostrar el formulario
                        formReporte.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
