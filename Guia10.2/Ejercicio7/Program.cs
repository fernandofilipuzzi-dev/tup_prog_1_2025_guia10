using Ejercicio6.Models;

namespace Ejercicio6
{
    internal class Program
    {
        static Juego juego;
        static int[] Ganadas = new int[100];
        static int cantidadQueHanJugado = 0;

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
                Console.WriteLine("Presione cualquier tecla para continuar (Escape para interrumpir el juego)");

                juego.Jugar();

                for (int n = 0; n<juego.PosicionJugadores.Length; n++)
                {
                    Console.WriteLine($"Jugador {n + 1} está en la posición {juego.PosicionJugadores[n]}");
                }

                key = Console.ReadKey();
            }
            while (key.Key == ConsoleKey.Escape);
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
