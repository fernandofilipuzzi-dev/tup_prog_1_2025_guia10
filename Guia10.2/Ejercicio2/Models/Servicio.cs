
namespace Ejercicio2.Models
{
    internal class Servicio
    {
        public string[] Nombres = new string[100];
        public int[] Libretas = new int[100];
        public double[] Notas = new double[100];
        public int Cantidad = 0;

        public bool RegistrarAlumno(int libreta, string nombre, double nota)
        {
            if (Cantidad < 100)
            {
                Nombres[Cantidad] = nombre;
                Libretas[Cantidad] = libreta;
                Notas[Cantidad] = nota;
                Cantidad++;
                return true;
            }
            return false;
        }

        public double CalcularPormedio()
        {
            double acumulador = 0;
            for (int n = 0; n < Cantidad; n++)
            {
                acumulador += Notas[n];
            }
            if (Cantidad > 0)
            {
                return acumulador / Cantidad;
            }
            return 0;
        }

        public int CalcularAlumnoMayorNota()
        {
            int idxMayorNota = -1;
            double notaMayor=0;
            for (int n = 0; n < Cantidad; n++)
            {
                if (n == 0 || Notas[n] > notaMayor)
                {
                    idxMayorNota = n;
                }
            }
            return idxMayorNota;
        }

        public int CalcularAlumnoMenorNota()
        {
            int idxMenorNota = -1;
            double notaMenor = 0;
            for (int n = 0; n < Cantidad; n++)
            {
                if (n == 0 || Notas[n] < notaMenor)
                {
                    idxMenorNota = n;
                }
            }
            return idxMenorNota;
        }

        public void OrdenadaAlumnosPorLibreta()
        {
            for (int i = 0; i < Cantidad; i++)
            {
                for (int j = i + 1; j < Cantidad; j++)
                {
                    if (Notas[i] > Notas[j])
                    {

                        Intercambiar(i, j);
                    }
                }
            }
        }

        void Intercambiar(int idx, int idy)
        {
            double tempNota = Notas[idx];
            Notas[idx] = Notas[idy];
            Notas[idy] = tempNota;

            string tempNombre = Nombres[idx];
            Nombres[idx] = Nombres[idy];
            Nombres[idy] = tempNombre;

            int tempLibreta = Libretas[idx];
            Libretas[idx] = Libretas[idy];
            Libretas[idy] = tempLibreta;
        }

        public int BuscarPorLibreta(int libreta)
        {
            int idx=-1;
            for (int n = 0; n < Cantidad; n++)
            {
                if (Libretas[n] == libreta)
                {
                    idx = n;
                }
            }
            return idx; 
        }

        public int[] ListarAlumnosSuperaronElPromedio(out int cantidadMayores)
        { 
            int[] mayorsAlPromedio = new int[Cantidad];
            cantidadMayores = 0;
            for (int n=0; n<Cantidad; n++)
            {
                if (Notas[n] > CalcularPormedio())
                {
                    mayorsAlPromedio[n] = n;
                    cantidadMayores++;
                }
            }
            return mayorsAlPromedio;
        }
    }
}
