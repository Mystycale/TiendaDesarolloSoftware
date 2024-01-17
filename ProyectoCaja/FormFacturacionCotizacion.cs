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
    public partial class FormFacturacionCotizacion : Form
    {

        public FormFacturacionCotizacion()
        {
            InitializeComponent();

            cmbCotizacion.Items.Add("No");
            cmbCotizacion.Items.Add("Si");
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
    }
}
