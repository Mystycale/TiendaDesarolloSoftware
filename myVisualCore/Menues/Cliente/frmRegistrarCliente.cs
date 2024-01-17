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
    public partial class frmRegistrarCliente : Form
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            ServicioDelCore.WCCliente myWCCliente = new ServicioDelCore.WCCliente();

            myWCCliente.clt_codigo = txtCodigo.Text;
            myWCCliente.clt_nombre = txtNombre.Text;
            myWCCliente.clt_cedula = txtCedula.Text;
            myWCCliente.clt_apellido = txtApellido.Text;
            myWCCliente.clt_telefono = txtTelefono.Text;
            myWCCliente.clt_direccion = txtDireccion.Text;
            myWCCliente.clt_saldo = int.Parse(txtSaldo.Text);

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
