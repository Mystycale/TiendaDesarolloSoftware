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
    public partial class frmRegistrarCajero : Form
    {
        public frmRegistrarCajero()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //WCCajero myWCCajero = new WCCajero();
            //WCRespuesta myWCRespuesta = new WCRespuesta();

            ServicioDelCore.WCCajero myWCCajero = new ServicioDelCore.WCCajero();
            //ServicioDelCore.WCRespuesta myWCRespuesta = new ServicioDelCore.WCRespuesta();

            myWCCajero.cjr_codigo = txtCodigo.Text;
            myWCCajero.cjr_nombre = txtNombre.Text;
            myWCCajero.cjr_cedula = txtCedula.Text;
            myWCCajero.cjr_apellido = txtApellido.Text;
            myWCCajero.cjr_telefono = txtTelefono.Text;
            myWCCajero.cjr_direccion = txtDireccion.Text;

            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();
            int respWCQwery;

            try
            {
                respWCQwery = client.InsertCajero(myWCCajero);
                if (respWCQwery == 1)
                {
                    DialogResult r = MessageBox.Show("El cajero fue creado correctamente.", "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK) { this.Close(); }
                }
            }
            catch (Exception exx)
            {
                //TODO: log LA EXEPTION
                MessageBox.Show("Ocurrio un error al crear el cajero. \nAsegurate de que la cedula y el codigo sean correctos",/*exx.Message,*/ "Mensaje del core", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistrarCajero_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
