﻿using System;
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
    public partial class FormOtros : Form
    {
        public FormOtros()
        {
            InitializeComponent();
        }

        #region Botones
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
