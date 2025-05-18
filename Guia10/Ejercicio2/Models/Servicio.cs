namespace Ejercicio2.Models
{
    public class Servicio
    {
        string[] nombres = new string[100];
        int[] numeroLibreta = new string[100];

        double[] notas = new double[100];

        int cantidad = 0;

        public void RegistrarAlumno(string nombre, int numero, double nota)
        {
            nombres[cantidad] = nombre;
            numeroLibreta[cantidad] = numero;
            notas[cantidad] = nota;
            cantidad++;
        }

        public double CalcularPromedios()
        {
            double suma = 0;
            for (int i = 0; i < cantidad; i++)
            {
                suma += notas[i];
            }
            return suma / cantidad;
        }

        public string[] AlumnosSuperaronPromedio()
        {
            double promedio = CalcularPromedios();
            string[] alumnos = new string[cantidad];
            int contador = 0;

            for (int i = 0; i < cantidad; i++)
            {
                if (notas[i] > promedio)
                {
                    alumnos[contador] = nombres[i];
                    contador++;
                }
            }

            return alumnos;
        }
   
    }
}