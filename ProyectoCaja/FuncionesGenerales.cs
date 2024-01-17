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
        private static Form ventanaActual2;

        public static void abrirVentana(Form form, Panel panel)
        {
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

        public static void abrirVentana2(Form form, Panel panel)
        {
            if(ventanaActual2 != null)
            {
                ventanaActual2.Close();
            }

            ventanaActual2 = form;

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
