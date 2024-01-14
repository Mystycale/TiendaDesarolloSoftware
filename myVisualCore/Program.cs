using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            CoreProgram();


        }

        private static void CoreProgram()
        {
            while (true)
            {
                Console.WriteLine("------MENU------");
                Console.WriteLine("1. Registrar cajero");

                

                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    frmRegistrarCajero myFrmRegistrarCajero = new frmRegistrarCajero();
                    Application.Run(myFrmRegistrarCajero);                    

                    Console.WriteLine("Fin");

                }

            }
        }
    }
}
