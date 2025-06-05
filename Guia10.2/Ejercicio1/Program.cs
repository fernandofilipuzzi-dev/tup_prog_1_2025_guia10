using Ejercicio1.Models;

namespace Ejercicio1
{
    internal class Program
    {
        static Servicio servicio = new Servicio();

        #region metodos 
        static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine(@"Ingrese las siguiente opciones:
1- Procesar un solo número
2- Procesar varios números.
3- Mostrar máximo y mínimo.
4- Mostrar promedio.
5- Mostrar cantidad de números ingresados.
6- Ordenar y mostrar Listado
7- Verificar si existe un valor (Buscar valor)
8- Mostrar listado que superaron el promedio
(otro)- Salir.");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }
      
        static void MostrarPantallaSolicitarNumero()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un número:\n\n");
            int valor = Convert.ToInt32(Console.ReadLine());
            servicio.RegistrarValor(valor);
        }
        static void MostrarPantallaSolicitarVariosNumeros()
        {
            Console.Clear();
            Console.WriteLine("Ingrese  cuantos números va a ingresar\n\n");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            for (int n = 0; n < cantidad; n++)
            {
                MostrarPantallaSolicitarNumero();
            }
        }
        static void MostrarPantallaMaximoMinimo()
        {
            Console.Clear();
            Console.WriteLine($@"     Máximo y Mínimo

   Máximo: { servicio.CalcularMaximo():f2}
  Mímimo: { servicio.CalcularMinimo():f2}

Presione una tecla para volver al menú principal");

            Console.ReadKey();
        }
        static void MostrarPantallaCalcularYMostrarPromedio()
        {
            Console.Clear();

            Console.WriteLine("Pantalla de promedio\n\n");

            if (servicio.Contador > 0)
            {
                Console.WriteLine("Promedio: " + servicio.CalcularPromedio());
            }
            else
            {
                Console.WriteLine("Promedio: No se han ingresado números");
            }

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }
        static void MostrarPantallaCantidad()
        {
            Console.Clear();

            Console.WriteLine("Pantalla de cantidad de valores procesados\n\n");

            if (servicio.Contador > 0)
            {
                Console.WriteLine("Cantidad: " + servicio.Contador);
            }
            else
            {
                Console.WriteLine("Cantidad: No se han ingresado números");
            }

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }
        static void MostrarPantallaOrdenarListadoYMostrar()
        {
            Console.Clear();

            Console.WriteLine("Pantalla - Ordenar y mostrar listado ordenado\n\n");

            servicio.OrdenarLista();

            for (int n = 0; n < servicio.Contador; n++)
            {
                Console.Write($"{servicio.Lista[n],4}");
            }

            Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
            Console.ReadKey();
        }
        static void MostrarPantallaBuscarNumero()
        {
            Console.Clear();

            Console.WriteLine("Pantalla verificar número\n\n");

            Console.WriteLine("Ingrese un número a buscar: ");
            int valor = Convert.ToInt32(Console.ReadLine());

            int idx=servicio.BuscarValor(valor);

            if (idx > 0)
            {
                Console.WriteLine($"Existe! posición:{idx}");
            }
            else
            {
                Console.WriteLine("No existe el valor ingresado en la lista de números procesados.");
            }

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }
        static void MostrarPantallaListaSuperioresAlPromedio()
        {
            Console.Clear();

            Console.WriteLine("Pantalla - Listado superiores al promedio\n\n");

            int cantidad;
            int [] lista=servicio.ListaSuperioresAlPromedio(out cantidad);

            for (int n = 0; n < cantidad; n++)
            {
                Console.Write($"{lista[n],4}");
            }

            Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        #endregion

        static void Main(string[] args)
        {
            int op = MostrarPantallaSolicitarOpcionMenu();

            #region iterar opciones menú
            while (op != -1)
            {
                #region verificar opción
                switch (op)
                {
                    case 1:
                        MostrarPantallaSolicitarNumero();
                        break;
                    case 2:
                        MostrarPantallaSolicitarVariosNumeros();
                        break;
                    case 3:
                        MostrarPantallaMaximoMinimo();
                        break;
                    case 4:
                        MostrarPantallaCalcularYMostrarPromedio();
                        break;
                    case 5:
                        MostrarPantallaCantidad();
                        break;
                    case 6:
                        MostrarPantallaOrdenarListadoYMostrar();
                        break;
                    case 7:
                        MostrarPantallaBuscarNumero();
                        break;
                    case 8:
                        MostrarPantallaListaSuperioresAlPromedio();
                        break;
                    default:
                        op = -1;
                        break;
                }
                #endregion

                #region solicitar opción
                if (op != -1)
                    op = MostrarPantallaSolicitarOpcionMenu();
                #endregion
            }
            #endregion
        }
    }
}
