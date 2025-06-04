using Ejercicio2.Models;

namespace Ejercicio2
{
    internal class Program
    {
        static Servicio servicio = new Servicio();

        #region metodos 
        static int MostrarPantallaSolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine(@"Ingrese las siguiente opciones:

1- Registrar un alumno
2- Mostrar Alumno con mayor y menor nota
3- Mostrar el listado de alumnos ordenados por número de libreta
4- Mostrar promedio general y el listado que superaron el promedio
5- Buscar alumno por número de libreta
(otro)- Salir.");

            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void MostrarPantallaSolicitarAlumno()
        {
            Console.Clear();
            Console.WriteLine("Ingrese los datos del alumno \n\n");

            Console.WriteLine("Ingrese el número de libreta:");
            int libreta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del alumno:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la nota:");
            double nota = Convert.ToDouble(Console.ReadLine());
                        
            bool exito=servicio.RegistrarAlumno(libreta,nombre,nota);
            if(exito)
                Console.WriteLine("Alumno registrado correctamente");
            else
                Console.WriteLine("No se ha podido registrar el alumno.");

            Console.WriteLine("\n\n\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarPantallaMostrarAlumnoMayorYMenorNota()
        {
            Console.Clear();
            Console.WriteLine("Alumno con la mayor y menor nota \n\n");
                       

            int idx = servicio.CalcularAlumnoMayorNota();
            Console.WriteLine($"\n\nAlumno con la mayor nota:");
            if (idx > -1)
            {
                Console.WriteLine($"Libreta: {servicio.Libretas[idx]}, Nombre: {servicio.Nombres[idx]}, Notas: {servicio.Notas[idx]:f2}");
            }
            else
            {
                Console.WriteLine($"No se ingresaron alumnos");
            }

            idx = servicio.CalcularAlumnoMenorNota();
            Console.WriteLine($"\n\nAlumno con menor nota");
            if (idx > -1)
            {
                Console.WriteLine($"Libreta: {servicio.Libretas[idx]}, Nombre: {servicio.Nombres[idx]}, Notas: {servicio.Notas[idx]:f2}");
            }
            else
            {
                Console.WriteLine($"No se ingresaron alumnos");
            }

            Console.WriteLine("\n\n\nPresione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarPantallaListadoOrdenadosPorLibreta()
        {
            Console.WriteLine("Listado de alumnos\n\n");

            servicio.OrdenadaAlumnosPorLibreta();

            Console.WriteLine($"\n\n {"Libreta",10}| {"Nombre",20}| {"Nota",10:f2}");
            for (int n = 0; n < servicio.Cantidad; n++)
            { 
                Console.WriteLine($" {servicio.Libretas[n],10}| {servicio.Nombres[n],20}| {servicio.Notas[n],10:f2}");
            }

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarPantallaPromedioYListadoSuperaronPromedio() 
        {
            Console.WriteLine("Listado de alumnos que superaron el promedio\n\n");

            Console.WriteLine($"El promedio general es: {servicio.CalcularPormedio():f2}\n\n");

            int cantidadMayores;
            int[] idxsMayoresAlPromedio = servicio.ListarAlumnosSuperaronElPromedio(out cantidadMayores);

            Console.WriteLine($"\n\n {"Libreta",10}| {"Nombre",20}| {"Nota",10:f2}");
            for (int n = 0; n < cantidadMayores; n++)
            {
                int idx = idxsMayoresAlPromedio[n];
                Console.WriteLine($" {servicio.Libretas[idx],10}| {servicio.Nombres[idx],20}| {servicio.Notas[idx],10:f2}");
            }

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarPantallaDatosAlumno() 
        {
            Console.Clear();
            Console.WriteLine("Alumno con la mayor y menor nota \n\n");

            Console.WriteLine("Ingrese el número de libreta del alumno:\n");
            int libreta = Convert.ToInt32(Console.ReadLine());

            int idx = servicio.BuscarPorLibreta(libreta);
            Console.WriteLine($"\n\nDatos del alumno:");
            if (idx > -1)
            {
                Console.WriteLine($"Libreta: {servicio.Libretas[idx]}, Nombre: {servicio.Nombres[idx]}, Notas: {servicio.Notas[idx]:f2}");
            }
            else
            {
                Console.WriteLine($"No se ha encontrado el alumno.\n\n\n");
            }
                       

            Console.WriteLine("\n\n\nPresione una tecla para continuar");
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
                        MostrarPantallaSolicitarAlumno();
                        break;
                    case 2:
                        MostrarPantallaMostrarAlumnoMayorYMenorNota();
                        break;
                    case 3:
                        MostrarPantallaListadoOrdenadosPorLibreta();
                        break;
                    case 4:
                        MostrarPantallaPromedioYListadoSuperaronPromedio();
                        break;
                    case 5:
                        MostrarPantallaDatosAlumno();
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
