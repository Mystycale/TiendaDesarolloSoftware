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
            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();
            //WCCajero myWCCajero = new WCCajero();
            //WCRespuesta myWCRespuesta = new WCRespuesta();

            ServicioDelCore.WCCajero myWCCajero = new ServicioDelCore.WCCajero();
            ServicioDelCore.WCRespuesta myWCRespuesta = new ServicioDelCore.WCRespuesta();

            myWCCajero.cjr_codigo = txtCodigo.Text;
            myWCCajero.cjr_nombre = txtNombre.Text;
            myWCCajero.cjr_cedula = txtCedula.Text;
            myWCCajero.cjr_apellido = txtApellido.Text;
            myWCCajero.cjr_telefono = txtTelefono.Text;
            myWCCajero.cjr_direccion = txtDireccion.Text;

            myWCRespuesta = client.InsertCajero(myWCCajero);

            //MessageBox.Show(, "Mensaje del sistema");
            MessageBox.Show(myWCRespuesta.Mensaje.ToString(), "Mensaje del sistema");
        }

    }
}
