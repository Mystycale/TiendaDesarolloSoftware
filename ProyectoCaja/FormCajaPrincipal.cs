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
            lblHora.Text = DateTime.Now.ToLongTimeString() + "\n" + DateTime.Now.ToLongDateString();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString() + "\n" + DateTime.Now.ToLongDateString();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana(new FormFacturacionCotizacion(), panelCajaPrincipal);
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {

        }
    }
}
