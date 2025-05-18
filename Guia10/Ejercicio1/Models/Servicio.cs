using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class Servicio
    {
        int[] lista = new int[1000];
        public int Contador = 0;

        public Servicio()
        {
        }

        public double CalcularPromedio()
        {
            int acumulador = 0;
            double promedio = 0;

            for (int n = 0; n < Contador; n++)
            {
                acumulador += lista[n];
            }
            if (Contador>0)
            {
                promedio=1.0*acumulador / Contador;
            }
            return promedio;
        }

        public int CalcularMaximo()
        {
            int maximo=0;
            for (int n = 0; n < Contador; n++)
            {
                if (Contador == 0 || lista[n] > maximo)
                {
                    maximo = lista[n];
                }
            }
            return maximo; 
        }

        public int CalcularMinimo()
        {
            int minimo = 0;
            for (int n = 0; n < Contador; n++)
            {
                if (Contador == 0 || lista[n] < minimo)
                {
                    minimo = lista[n];
                }
            }
            return minimo;
        }

        public void RegistrarValor(int valor)
        {
            lista[Contador] += valor;
            Contador++;
        }
    }
}
