using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCore.Modelos;

namespace myVisualCore
{
    public partial class frmRegistrarProducto : Form
    {
        public frmRegistrarProducto()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            ServicioDelCore.WC

            myWCProducto.codigo = txtCodigo.Text;
            myWCProducto.nombre = txtNombre.Text;
            myWCProducto.desc = txtCantidad.Text;
            myWCProducto.stock = int.Parse(txtNombre.Text);
            myWCProducto.precio = decimal.Parse(txtPrecio.Text);

            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();
            int respWCQwery;

            try
            {
                respWCQwery = client.InsertCliente(myWCCliente);
                if (respWCQwery == 1)
                {
                    DialogResult r = MessageBox.Show("El cliente fue creado correctamente.", "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK) { this.Close(); }
                }
            }
            catch (Exception exx)
            {
                //TODO: log LA EXEPTION
                MessageBox.Show("Ocurrio un error al crear el cliente. \nIntentelo más tarde.",/*exx.Message,*/ "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistrarCajero_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
