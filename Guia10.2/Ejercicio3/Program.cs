using Ejercicio3.Models;

namespace Ejercicio3
{
    internal class Program
    {
        static Servicio servicio = new Servicio();

        #region metodos 

        static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese las siguiente opciones:");
            Console.WriteLine("1- Registrar encuesta");
            Console.WriteLine("2- Registrar una cantidad de encuestas");
            Console.WriteLine("3- Mostrar pocentajes de distancia por tipo de transporte.");
            Console.WriteLine("4- Mostrar cantidad de encuestados.");
            Console.WriteLine("(otro)- Salir.");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarPantallaSolicitarEncuesta()
        {
            int tipoVehiculo;
            double distancia;

            Console.Clear();

            Console.WriteLine("Tipo de vehículo");
            tipoVehiculo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Distancia recorrida");
            distancia = Convert.ToDouble(Console.ReadLine());

            servicio.RegistrarEncuesta(tipoVehiculo, distancia);
        }

        static void MostrarPantallaSolicitarVariasEncuestas()
        {
            int tipoVehiculo;
            double distancia;

            Console.Clear();

            Console.WriteLine("Tipo de vehículo (-1 corta)");
            tipoVehiculo = Convert.ToInt32(Console.ReadLine());

            while (tipoVehiculo != -1)
            {
                Console.WriteLine("Distancia recorrida");
                distancia = Convert.ToDouble(Console.ReadLine());

                servicio.RegistrarEncuesta(tipoVehiculo, distancia);

                Console.WriteLine("Tipo de vehículo (-1 corta)");
                tipoVehiculo = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void MostrarPantallaPromediosResultados()
        {
            int tipoVehiculo;
            double distancia;

            Console.Clear();

            Console.WriteLine("Promedio de distancia recorrida por tipo de vehículo");

            Console.WriteLine("Bicicleta:" + servicio.CalcularPromedioPorTipo(1).ToString("0.00"));
            Console.WriteLine("Motocicleta:" + servicio.CalcularPromedioPorTipo(2).ToString("0.00"));
            Console.WriteLine("Automóvil:" + servicio.CalcularPromedioPorTipo(3).ToString("0.00"));
            Console.WriteLine("Transporte público:" + servicio.CalcularPromedioPorTipo(4).ToString("0.00"));

            Console.WriteLine("\n\nPresione una tecla para continuar.");
            Console.ReadKey();
        }

        static void MostrarPantallaTotalEncuestados()
        {
            Console.Clear();

            Console.WriteLine("Total de encuestados:");

            Console.WriteLine(servicio.CantidadEncuestados);

            Console.WriteLine("\n\nPresione una tecla para continuar.");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {
            int op = MostrarPantallaSolicitarOpcionMenu();

            #region iterar cada persona encuestada
            while (op != -1)
            {
                #region iterar opciones menú
                switch (op)
                {
                    case 1:
                        MostrarPantallaSolicitarEncuesta();
                        break;
                    case 2:
                        MostrarPantallaSolicitarVariasEncuestas();
                        break;
                    case 3:
                        MostrarPantallaPromediosResultados();
                        break;
                    case 4:
                        MostrarPantallaTotalEncuestados();
                        break;
                    default:
                        op = -1;
                        break;
                }
                #endregion

                #region solicitar opción menu
                if (op != -1)
                    op = MostrarPantallaSolicitarOpcionMenu();
                #endregion
            }
            #endregion
        }
    }
}
