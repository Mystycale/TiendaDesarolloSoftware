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
    public partial class frmRegistrarServicio : Form
    {
        public frmRegistrarServicio()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ServicioDelCore.WCServicio myWCServicio = new ServicioDelCore.WCProducto();

            myWCServicio.codigo = txtCodigo.Text;
            myWCServicio.nombre = txtNombre.Text;
            myWCServicio.desc = txtDescripcion.Text;
            myWCServicio.precio = decimal.Parse(txtPrecio.Text);

            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();
            int respWCQwery;

            try
            {
                respWCQwery = client.InsertServicio(myWCServicio);
                if (respWCQwery == 1)
                {
                    DialogResult r = MessageBox.Show("El servicio fue creado correctamente.", "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK) { this.Close(); }
                }
            }
            catch (Exception exx)
            {
                //TODO: log LA EXEPTION
                MessageBox.Show("Ocurrio un error al crear el servicio. \nIntentelo más tarde.",/*exx.Message,*/ "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistrarCajero_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
