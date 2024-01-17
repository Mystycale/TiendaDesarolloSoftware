﻿using myVisualCore.Menues.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Modelos;

namespace myVisualCore.Menues.Producto
{
    internal class MenuServicio
    {
        private static int x;
        private static int y;


        public static void Ejecutar(CoreUser actualCoreUser)
        {
            switch (actualCoreUser.TipoPerfil)
            {
                case 1:
                    string[] OpcionesMenuCajero1 = new string[] {
            " [Crear servicio] ",
            " [Mostrar servicios] ",
            " [Actualizar servicio] ",
            " [Eliminar servicio] ",
            " [Volver al menú principal] "};
                    Ejecutar1(OpcionesMenuCajero1, actualCoreUser);
                    break;

                case 2:
                    string[] OpcionesMenuCajero2 = new string[] {
            " [Mostrar servicios] ",
            " [Actualizar servicio] ",
            " [Volver al menú principal] " };

                    Ejecutar2(OpcionesMenuCajero2, actualCoreUser);
                    break;
                case 3:
                    string[] OpcionesMenuCajero3 = new string[] {
            " [Mostrar servicios] ",
            " [Volver al menú principal] " };

                    Ejecutar3(OpcionesMenuCajero3, actualCoreUser);
                    break;
            }
        }

        #region::::::::::::::::::::::: ADMINISTRADOR
        #region ::::::::::::Atajo
        public static void Ejecutar1(string[] OpcionesMenuCajero, CoreUser actualCoreUser)
        {
            bool loop = true;
            int posicionSeleccion = 0;
            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            Console.Clear();
            actualCoreUser.Mostrar();
            Console.WriteLine("***********************");
            Console.WriteLine("*    MENU SERVICIO    *");
            Console.WriteLine("***********************\n");

            x = Console.CursorLeft;
            y = Console.CursorTop;

            string resultado = MostrarOpciones1(OpcionesMenuCajero, posicionSeleccion);

            while (loop)
            {
                Console.Clear();
                actualCoreUser.Mostrar();
                Console.WriteLine("***********************");
                Console.WriteLine("*    MENU SERVICIO    *");
                Console.WriteLine("***********************\n");
                x = Console.CursorLeft;
                y = Console.CursorTop;

                resultado = MostrarOpciones1(OpcionesMenuCajero, posicionSeleccion);

                while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (posicionSeleccion == OpcionesMenuCajero.Length - 1) continue;
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

                    resultado = MostrarOpciones1(OpcionesMenuCajero, posicionSeleccion);
                }
                #endregion ::::::::::::Atajo

                switch (posicionSeleccion)
                {
                    case 0:
                        frmRegistrarServicio myFrmRegistrarServicio = new frmRegistrarServicio();
                        myFrmRegistrarServicio.ShowDialog();
                        break;

                    case 1:
                        FuncionesServicio.MostrarServicios();
                        break;

                    case 2:
                    case 3:
                        continue;
                    case 4:
                        Console.Clear();
                        loop = false;
                        break;
                }
            }
            return;
        }
        private static string MostrarOpciones1(String[] items, int _posicionSeleccion)
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
        #endregion ::::::::::::::::::::::: ADMINISTRADOR

        #region::::::::::::::::::::::: MANTENIMIENTO
        public static void Ejecutar2(string[] OpcionesMenuCajero, CoreUser actualCoreUser)
        {
            bool loop = true;
            int posicionSeleccion = 0;
            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            Console.Clear();
            actualCoreUser.Mostrar();
            Console.WriteLine("***********************");
            Console.WriteLine("*    MENU SERVICIO    *");
            Console.WriteLine("***********************\n");

            x = Console.CursorLeft;
            y = Console.CursorTop;

            string resultado = MostrarOpciones2(OpcionesMenuCajero, posicionSeleccion);

            while (loop)
            {
                Console.Clear();
                actualCoreUser.Mostrar();
                Console.WriteLine("***********************");
                Console.WriteLine("*    MENU SERVICIO    *");
                Console.WriteLine("***********************\n");
                x = Console.CursorLeft;
                y = Console.CursorTop;

                resultado = MostrarOpciones2(OpcionesMenuCajero, posicionSeleccion);

                while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (posicionSeleccion == OpcionesMenuCajero.Length - 1) continue;
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

                    resultado = MostrarOpciones2(OpcionesMenuCajero, posicionSeleccion);
                }

                switch (posicionSeleccion)
                {
                    case 0:
                        FuncionesServicio.MostrarServicios();
                        break;
                    case 1:
                        continue;
                    case 2:
                        Console.Clear();
                        loop = false;
                        break;
                }
            }
            return;
        }
        private static string MostrarOpciones2(String[] items, int _posicionSeleccion)
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
        #endregion ::::::::::::::::::::::: MANTENIMEINTO

        #region ::::::::::::::::::::::: LECTURA
        public static void Ejecutar3(string[] OpcionesMenuCajero, CoreUser actualCoreUser)
        {
            bool loop = true;
            int posicionSeleccion = 0;
            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            Console.Clear();
            actualCoreUser.Mostrar();
            Console.WriteLine("***********************");
            Console.WriteLine("*    MENU SERVICIO    *");
            Console.WriteLine("***********************\n");

            x = Console.CursorLeft;
            y = Console.CursorTop;

            string resultado = MostrarOpciones3(OpcionesMenuCajero, posicionSeleccion);

            while (loop)
            {
                Console.Clear();
                actualCoreUser.Mostrar();
                Console.WriteLine("***********************");
                Console.WriteLine("*    MENU SERVICIO    *");
                Console.WriteLine("***********************\n");

                x = Console.CursorLeft;
                y = Console.CursorTop;

                resultado = MostrarOpciones3(OpcionesMenuCajero, posicionSeleccion);

                while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (posicionSeleccion == OpcionesMenuCajero.Length - 1) continue;
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

                    resultado = MostrarOpciones3(OpcionesMenuCajero, posicionSeleccion);
                }

                switch (posicionSeleccion)
                {
                    case 0:
                        FuncionesServicio.MostrarServicios();
                        break;
                    case 1:
                        Console.Clear();
                        loop = false;
                        break;
                }
            }
            return;
        }
        private static string MostrarOpciones3(String[] items, int _posicionSeleccion)
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
        #endregion ::::::::::::::::::::::: MANTENIMEINTO

    }

}
