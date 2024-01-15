using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCaja
{
    public partial class FormLogin : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Info("La aplicacion ha subido"); //ejemplo de como usar el log
            //log.Error("");
            //log.Debug("");
        }

        #region Botones

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana(new FormRegistrarCajero(), panelLogin);
        }

        private void btnMostrarContra_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '\0';
        }

        private void btnMostrarContra_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FuncionesGenerales.abrirVentana(new FormCajaPrincipal(), panelLogin);
        }

        #endregion


        public class RoundedPanel : Panel
        {
            private int cornerRadius = 15;

            public int CornerRadius
            {
                get { return cornerRadius; }
                set
                {
                    if (value >= 0)
                    {
                        cornerRadius = value;
                        Invalidate();
                    }
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using (GraphicsPath path = GetRoundedPath(ClientRectangle, cornerRadius))
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }

            private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
            {
                GraphicsPath path = new GraphicsPath();

                int diameter = radius * 2;
                Size size = new Size(diameter, diameter);
                Rectangle arc = new Rectangle(bounds.Location, size);

                path.AddArc(arc, 180, 90); // top-left
                arc.X = bounds.Right - diameter;
                path.AddArc(arc, 270, 90); // top-right
                arc.Y = bounds.Bottom - diameter;
                path.AddArc(arc, 0, 90);   // bottom-right
                arc.X = bounds.Left;
                path.AddArc(arc, 90, 90);  // bottom-left

                path.CloseFigure();

                return path;
            }
        }
    }
}
