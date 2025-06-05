
namespace Ejercicio1.Models
{
    internal class Servicio
    {
        public int[] Lista = new int[1000];
        public int Contador = 0;

        public Servicio()
        {
        }

        public void RegistrarValor(int valor)
        {
            Lista[Contador] += valor;
            Contador++;
        }

        public double CalcularPromedio()
        {
            int acumulador = 0;
            double promedio = 0;

            for (int n = 0; n < Contador; n++)
            {
                acumulador += Lista[n];
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
                if (n == 0 || Lista[n] > maximo)
                {
                    maximo = Lista[n];
                }
            }
            return maximo; 
        }

        public int CalcularMinimo()
        {
            int minimo = 0;
            for (int n = 0; n < Contador; n++)
            {
                if (n == 0 || Lista[n] < minimo)
                {
                    minimo = Lista[n];
                }
            }
            return minimo;
        }

        public void OrdenarLista()
        {
            for (int i = 0; i < Contador - 1; i++)
            {
                for (int j = i + 1; j < Contador; j++)
                {
                    if (Lista[i] > Lista[j])
                    {
                        Intercambiar(i, j);
                    }
                }
            }
        }

        void Intercambiar(int i, int j)
        {
            int aux = Lista[i];
            Lista[i] = Lista[j];
            Lista[j] = aux;
        }

        public int BuscarValor(int buscado)
        {
            int idx = -1;
            int n = 0;
            while (n < Contador && idx == -1)
            {
                if (Lista[n] == buscado)
                {
                    idx = n;
                }
                n++;
            }
            return idx;
        }

        public int[] ListaSuperioresAlPromedio(out int contadorSuperiores)
        {
            double promedio = CalcularPromedio();

            int[] superiores = new int[Contador];
            contadorSuperiores = 0;
            for (int n = 0; n < Contador; n++)
            {
                if (Lista[n] > promedio)
                {
                    superiores[contadorSuperiores] = Lista[n];
                    contadorSuperiores++;
                }
            }

            int[] resultado = new int[contadorSuperiores];
            for (int i = 0; i < contadorSuperiores; i++)
            {
                resultado[i] = superiores[i];
            }
            return resultado;
        }
    }
}
