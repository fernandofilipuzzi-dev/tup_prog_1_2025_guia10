
namespace Ejercicio5.Models
{
    internal class Juego
    {
        static Random azar = new Random();

        public int[] PosicionJugadores;
        int[,] PosicionesEscaleras;
        int[,] PosicionesSerpientes;

        public int IdxGanador = -1;

        public bool Finalizado = false;


        public Juego(int cantJugadores)
        {
            PosicionJugadores = new int[cantJugadores];
            for (int n = 0; n < PosicionJugadores.Length; n++)
            {
                PosicionJugadores[n] = 1;
            }

            int cantidadSerpientes = azar.Next(2, 5);
            PosicionesSerpientes = new int[cantidadSerpientes, 2];
            for (int n = 0; n < cantidadSerpientes; n++)
            {
                int cola = azar.Next(1,101);
                int cabeza = azar.Next(cola, 101);
                PosicionesSerpientes[n, 0] = cola;
                PosicionesSerpientes[n, 1] = cabeza;
            }

            int cantidadEscaleras = azar.Next(2, 5);
            PosicionesEscaleras = new int[cantidadEscaleras, 2];
            for (int n = 0; n < cantidadEscaleras; n++)
            {
                int pie = azar.Next(1, 101);
                int cabezal = azar.Next(pie, 101);
                PosicionesEscaleras[n, 0] = pie;
                PosicionesEscaleras[n, 1] = cabezal;
            }
        }

        public void Jugar()
        {
            if (Finalizado == false)
            {
                for (int n = 0; n < +PosicionJugadores.Length; n++)
                {
                    PosicionJugadores[n] += azar.Next(1, 7);

                    EvaluarSerpientes();
                    EvaluarEscaleras();
                }

                EvaluarFinJuego();

                EvaluarGanador();
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

        private void EvaluarFinJuego()
        {
            Finalizado |= false;
            int n = 0;
            while (Finalizado == false && n < PosicionJugadores.Length)
            {
                Finalizado |= PosicionJugadores[n] >= 100;
                n++;
            }
        }

        private void EvaluarGanador()
        {
            int idxGanador = 0;

            int llegaron = 0;
            int n = 0;
            while ( n < PosicionJugadores.Length)
            {
                if (PosicionJugadores[n] >= 100)
                {
                    idxGanador = n;
                    llegaron++;
                }
                n++;
            }

            if (llegaron == 1)
                IdxGanador = idxGanador;
        }
    }
}
