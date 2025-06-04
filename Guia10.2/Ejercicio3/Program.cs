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

            Console.WriteLine(@"Ingrese las siguiente opciones:

1- Registrar encuesta
2- Registrar una cantidad de encuestas
3- Mostrar promedios de distancias recorridas por tipo de vehículo.
4- Mostrar cantidad de encuestados.
(otro)- Salir.");

            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarPantallaSolicitarEncuesta()
        {
            int tipoVehiculo;
            double distancia;

            Console.Clear();

            Console.WriteLine("Tipo de vehículo (1- bici, 2-motocicleta, 3- automóvil, 4-transporte público.)");
            tipoVehiculo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Distancia recorrida (km)");
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
            Console.Clear();

            Console.WriteLine($@"Promedio de distancia recorrida por tipo de vehículo

  Bicicleta: {servicio.CalcularPromedioPorTipo(1):f2}
  Motocicleta: {servicio.CalcularPromedioPorTipo(2):f2}
  Automóvil:  {servicio.CalcularPromedioPorTipo(3):f2}
  Transporte público: {servicio.CalcularPromedioPorTipo(4):f2}

  Presione una tecla para continuar.");
            Console.ReadKey();
        }

        static void MostrarPantallaTotalEncuestados()
        {
            Console.Clear();

            Console.WriteLine($@"Total de encuestados:
{servicio.CantidadEncuestados}");

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
