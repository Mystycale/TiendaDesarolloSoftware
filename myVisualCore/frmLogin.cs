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
        public string Codigo = "NA";
        public string Nombre = "NA";
        public string Apellido = "NA";
        public int TipoPerfil = 0;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string clave = txtClave.Text;

            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.USUARIODataTable tblUsuarios = null;

            try
            {
                tblUsuarios = client.SelectUsuarios();
            }
            catch (Exception exx)
            {
                MessageBox.Show("Ocurrio un error: \n" + exx.Message, "Core", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataRowCollection myDataRowCollection = tblUsuarios.Rows;

            if (myDataRowCollection == null)
            {
                MessageBox.Show("Algo salio mal.", "Core", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool encontrado = false;


            foreach (var item in tblUsuarios)
            {
                if (codigo == item.usr_codigo && clave == item.usr_clave)
                {
                    Nombre = item.usr_nombre;
                    Apellido = item.usr_apellido;
                    TipoPerfil = item.usr_perfil_id;
                    Codigo = codigo;


                    MessageBox.Show(item.usr_nombre);

                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                MessageBox.Show("Bienvenido, administrador " + Nombre + " " + Apellido + ". Perfil: " + TipoPerfil.ToString(), "Core", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("Usuario no encontrado.", "Core", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
