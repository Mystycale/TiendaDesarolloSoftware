using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    internal class FuncionesGenerales
    {
        #region Ventanas
        private static Form ventanaActual;
        public static void abrirVentana(Form form, Panel panel)
        {
            //Si existe una ventana abierta, se cierra.
            if (ventanaActual != null)
                ventanaActual.Close();

            ventanaActual = form;

            //Se declara como formulario secundario.
            form.TopLevel = false;

            //Cambios en el estilo del formulario.
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;


            panel.Controls.Add(form);

            //Se trae el formulario por encima de lo demás y se muestra.
            form.BringToFront();
            form.Show();
        }
        #endregion
    }
}
