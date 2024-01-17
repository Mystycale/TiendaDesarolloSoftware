using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCore.Modelos;

namespace myVisualCore
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CoreUser actualCoreUser = new CoreUser();

            frmLogin frmLogin = new frmLogin();
            Application.Run(frmLogin);

            actualCoreUser.Codigo = frmLogin.Codigo;
            actualCoreUser.Nombre = frmLogin.Nombre;
            actualCoreUser.Apellido = frmLogin.Apellido;
            actualCoreUser.TipoPerfil = frmLogin.TipoPerfil;


            CoreProgram(actualCoreUser);


        }

        private static void CoreProgram(CoreUser actualCoreUser)
        {
            while (true)
            {
                Console.WriteLine("------MENU------");
                Console.WriteLine("1. Registrar cajero");
                Console.WriteLine("2. Login");


                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    frmRegistrarCajero myFrmRegistrarCajero = new frmRegistrarCajero();
                    Application.Run(myFrmRegistrarCajero);

                    Console.WriteLine("Fin");

                }
                else if (op == 2)
                {
                    frmLogin frmLogin = new frmLogin();
                    Application.Run(frmLogin);
                }

                Console.WriteLine(actualCoreUser.Nombre);

            }
        }
    }
}
