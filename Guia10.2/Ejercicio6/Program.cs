using Ejercicio5.Models;

namespace Ejercicio5
{
    internal class Program
    {
        static Juego juego;
        static int[] partidasGanadas = new int[10];

        #region metodos de impresión de pantallas
        static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine(@"Ingrese las siguiente opciones:
1- Iniciar Juego nuevo
2- Mostrar Estadistica Juego
(otro)- Salir.");

            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarPantallaJuegoNuevo()
        {
            Console.Clear();
            Console.WriteLine("En juego!!!!:\n\n");

            Console.WriteLine("Ingrese la cantidad de jugadores:");
            int cantidadJugadores = Convert.ToInt32(Console.ReadLine());

            juego = new Juego(cantidadJugadores);
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Presione cualquier tecla para continuar (Escape para interrumpir el juego)\n\n");
                key = Console.ReadKey();

                juego.Jugar();

                for (int n = 0; n<juego.PosicionJugadores.Length; n++)
                {
                    Console.WriteLine($"Jugador {n + 1} está en la posición {juego.PosicionJugadores[n]}");
                }
            }
            while (key.Key != ConsoleKey.Escape && juego.Finalizado==false);

            if (key.Key != ConsoleKey.Escape)
            {
                if (juego.IdxGanador > -1)
                {
                    partidasGanadas[juego.IdxGanador]++;

                    Console.WriteLine($"Ganador: Jugador número {juego.IdxGanador+1}");
                }
                else
                {
                    Console.WriteLine("No hay ganador, el juego terminó sin que nadie llegue a la meta.");
                }
            }
            else
            {
                Console.WriteLine("Juego interrumpido");
            }

            Console.WriteLine("\n\n\nPresione una tecla para volver al menú principal.");
            Console.ReadKey();
        }

        static void MostrarPantallaEstadisticaJuego()
        {
            Console.Clear();
            Console.WriteLine("En juego!!!!:\n\n");

            Console.WriteLine($"{"nro jugador",15}|{"partidasGanadas",8}");
            for (int n = 0; n < partidasGanadas.Length; n++)
            {
                Console.WriteLine($"{partidasGanadas[n],15}|{partidasGanadas[n],8}");
            }
            
            Console.WriteLine("\n\n\nPresione una tecla para volver al menú principal.");
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
                        MostrarPantallaJuegoNuevo();
                        break;
                    case 2:
                        MostrarPantallaEstadisticaJuego();
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
