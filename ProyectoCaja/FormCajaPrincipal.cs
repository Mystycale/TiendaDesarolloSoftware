using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    public partial class FormCajaPrincipal : Form
    {
        public FormCajaPrincipal()
        {
            InitializeComponent();
            lblHora.Text = "¡Bienvenido!\n" + DateTime.Now.ToLongTimeString() + "\n" + DateTime.Now.ToLongDateString();
        }

        #region Botones
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana2(new FormFacturacionCotizacion(), panelCajaPrincipal);
        }
        private void btnOtros_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana2(new FormOtros(), panelCajaPrincipal);
        }
        #endregion

        #region Propiedades
        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "¡Bienvenido!\n" + DateTime.Now.ToLongTimeString() + "\n" + DateTime.Now.ToLongDateString();
        }
        #endregion
    }
}
