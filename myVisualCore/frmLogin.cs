using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myVisualCore
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string codigo = txtContrasenia.Text;
            string clave = txtCodigo.Text;

            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.USUARIODataTable tblUsuarios = null;

            try
            {
                tblUsuarios = client.BuscarUsuario(codigo, clave);
            }
            catch (Exception exx)
            {
                MessageBox.Show("Ocurrio un error: \n" + exx.Message, "Core", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            if (tblUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("Ese usuaro no existe.", "Core", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowCollection myDataRowCollection = tblUsuarios.Rows;

            string nombre = "NA";
            string apellido = "NA";
            string tipoPerfil = "00";


            foreach (DataRow item in myDataRowCollection)
            {
                nombre = item[0].ToString();
                apellido = item[1].ToString();
                tipoPerfil = item[1].ToString();
            }

            MessageBox.Show("Bienvenido, administrador " + nombre + " " + apellido + ". Perfil: " + tipoPerfil.ToString(), "Core", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
