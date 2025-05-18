using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static Servicio servicio = new Servicio();

        #region metodos 
        static int SolicitarOpcionMenu()
        {
            Console.Clear();
            Console.WriteLine("Ingrese las siguiente opciones:\n");
            Console.WriteLine("1- Solicitar un solo número");
            Console.WriteLine("2- Solicitar varios números.");
            Console.WriteLine("3- Mostrar máximo y mínimo.");
            Console.WriteLine("4- Mostrar promedio");
            Console.WriteLine("(Otro)- Salir");

            int op = Convert.ToInt32(Console.ReadLine());
            
            return op;
        }
        static void SolicitarNumero()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un número ");
            int valor = Convert.ToInt32(Console.ReadLine());
            servicio.RegistrarValor(valor);
        }
        static void SolicitarVariosNumeros()
        {
            Console.Clear();
            Console.WriteLine("Ingrese  cuantos números va a ingresar");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            for (int n = 0; n < cantidad; n++)
            {
                SolicitarNumero();
            }
        }
        static void MostrarMaximo()
        {
            Console.Clear();
            Console.WriteLine("Mostrar máximo: " + servicio.CalcularMaximo());

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void MostrarMinimo()
        {
            Console.Clear();
            Console.WriteLine("Mostrar mímimo: " + servicio.CalcularMinimo());

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void CalcularYMostrarPromedio()
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
        #endregion

        static void Main(string[] args)
        {

            int op = 0;

            op = SolicitarOpcionMenu();
            while (op != -1)
            {
                switch (op)
                {
                    case 1:
                        SolicitarNumero();
                        break;
                    case 2:
                        SolicitarVariosNumeros();
                        break;
                    case 3:
                        MostrarMaximo();
                        MostrarMinimo();
                        break;
                    case 4:
                        CalcularYMostrarPromedio();
                        break;
                    default:
                        op = -1;
                        break;
                }

                if(op>-1)
                    op = SolicitarOpcionMenu();
            }
        }
    }
}
