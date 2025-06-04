
namespace Ejercicio6.Models
{
    internal class Juego
    {
        static Random azar = new Random();

        public int[] PosicionJugadores;
        int[,] PosicionesEscaleras;
        int[,] PosicionesSerpientes;

        public int idxGanador = -1;


        public Juego(int cantJugadores)
        {
            PosicionJugadores = new int[cantJugadores];
            for (int n = 0; n < PosicionJugadores.Length; n++)
            {
                PosicionJugadores[n] = 1;
            }

            int cantidadSerpientes = azar.Next(2, 5);
            PosicionesSerpientes = new int[cantidadSerpientes, 2];
            for (int n = 0; n < PosicionesSerpientes.Length; n++)
            {
                int cola = azar.Next(1,101);
                int cabeza = azar.Next(cola, 101);
                PosicionesSerpientes[n, 0] = cola;
                PosicionesSerpientes[n, 1] = cabeza;
            }

            int cantidadEscaleras = azar.Next(2, 5);
            PosicionesEscaleras = new int[cantidadEscaleras, 2];
            for (int n = 0; n < PosicionesEscaleras.Length; n++)
            {
                int pie = azar.Next(1, 101);
                int cabezal = azar.Next(pie, 101);
                PosicionesEscaleras[n, 0] = pie;
                PosicionesEscaleras[n, 1] = cabezal;
            }
        }

        public void Jugar()
        {
            for (int n = 0; n<+PosicionJugadores.Length; n++)
            {
                PosicionJugadores[n] += azar.Next(1, 7);

                EvaluarSerpientes();
                EvaluarEscaleras();
            }
        }

        private void EvaluarSerpientes()
        {
            for (int n = 0; n < PosicionesSerpientes.GetLength(0); n++)
            {
                for (int j = 0; j < PosicionJugadores.Length; j++)
                {
                    if (PosicionJugadores[j] == PosicionesSerpientes[n, 0])
                    {
                        PosicionJugadores[j] = PosicionesSerpientes[n, 1];
                    }
                }
            }
        }

        private void EvaluarEscaleras()
        {
            for (int n = 0; n < PosicionesEscaleras.GetLength(0); n++)
            {
                for (int j = 0; j < PosicionJugadores.Length; j++)
                {
                    if (PosicionJugadores[j] == PosicionesEscaleras[n, 0])
                    {
                        PosicionJugadores[j] = PosicionesEscaleras[n, 1];
                    }
                }
            }
        }
    }
}
