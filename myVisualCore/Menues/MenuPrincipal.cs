using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Modelos;
using static System.Net.Mime.MediaTypeNames;

namespace myVisualCore
{
    public static class MenuPrincipal
    {
        private static string[] OpcionesMenuPrincipal = new string[]
        {
            " [Productos] ",
            " [Servicios] ",
            " [Clientes] ",
            " [Cajeros] ",
            " [Facturas] ",
            " [Corizaciones] ",
            " [Usuarios] ",
            " [Cerrar seccion] "
        };

        private static int x;
        private static int y;

        public static void Ejecutar(CoreUser actualCoreUser)
        {
            bool loop = true;
            int posicionSeleccion = 0;
            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            Console.Clear();
            actualCoreUser.Mostrar();
            Console.WriteLine("************************");
            Console.WriteLine("*    MENU PRINCIPAL    *");
            Console.WriteLine("************************\n");

            x = Console.CursorLeft;
            y = Console.CursorTop;

            string resultado = MostrarOpciones(OpcionesMenuPrincipal, posicionSeleccion);

            while (loop)
            {
                Console.Clear();
                actualCoreUser.Mostrar();
                Console.WriteLine("************************");
                Console.WriteLine("*    MENU PRINCIPAL    *");
                Console.WriteLine("************************\n");

                x = Console.CursorLeft;
                y = Console.CursorTop;

                resultado = MostrarOpciones(OpcionesMenuPrincipal, posicionSeleccion);

                while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (posicionSeleccion == OpcionesMenuPrincipal.Length - 1) continue;
                            posicionSeleccion++;
                            break;

                        case ConsoleKey.UpArrow:
                            if (posicionSeleccion == 0) continue;
                            posicionSeleccion--;
                            break;

                        default:
                            break;
                    }


                    Console.CursorLeft = x;
                    Console.CursorTop = y;

                    resultado = MostrarOpciones(OpcionesMenuPrincipal, posicionSeleccion);
                }


                switch (posicionSeleccion)
                {
                    case 0:
                    case 1:
                    case 2:
                        continue;

                    case 3:
                        Console.Clear();
                        MenuCajero.Ejecutar(actualCoreUser);
                        break;

                    case 4:
                    case 5:
                    case 6:
                        continue;
                    case 7:
                        Console.Clear();
                        loop = false;
                        break;
                }
                posicionSeleccion = 0;
            }
            return;
        }

        private static string MostrarOpciones(String[] items, int _posicionSeleccion)
        {
            string seleccionActual = string.Empty;
            int destacado = 0;

            Array.ForEach(items, element =>
            {
                if (destacado == _posicionSeleccion)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(element + "<< ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    seleccionActual = element;
                }
                else
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.CursorLeft = 0;
                    Console.WriteLine(element);
                }

                destacado++;

            });

            return seleccionActual;
        }

    }
}
