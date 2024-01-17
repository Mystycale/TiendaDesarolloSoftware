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

            comboBox1.Items.Add("Si");
            comboBox1.Items.Add("No");

            comboBox1.SelectedIndex = 1;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox10.Text = comboBox1.Text;
        }
    }
}
