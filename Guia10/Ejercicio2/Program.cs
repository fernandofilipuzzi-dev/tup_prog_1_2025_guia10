
using System;
using Ejercicio2.Models;

namespace Ejercicio2
{
    class Program
    {
        Servicio servicio = new Servicio();

        static int SocitarOpcionMenu()
        {
            Console.WriteLine("Ingrese la opcion deseada:");
            Console.WriteLine("1- Registrar nota alumno ");
            Console.WriteLine("2- Opcion 2");
            Console.WriteLine("3- Opcion 3");
            Console.WriteLine("(Otro salir)- Salir");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        static void Main(string[] args)
        {
            int op = SocitarOpcionMenu();
            while (op!=-1)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Opcion 1");
                        break;
                    case 2:
                        Console.WriteLine("Opcion 2");
                        break;
                    default :
                        op= -1;
                        break;
                }

                if(op != -1)
                    int op = SocitarOpcionMenu();
            }
        }
    }    
}