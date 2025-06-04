
namespace Ejercicio3.Models
{
    internal class Servicio
    {
        public int CantidadEncuestados;

        int[] tiposTransportes = new int[100];
        double[] distancias = new double[100];
        int contadorEncuestados;

        public void RegistrarEncuesta(int tipoTransporte, double distancia)
        {
            tiposTransportes[CantidadEncuestados] = tipoTransporte;
            distancias[CantidadEncuestados] = distancia;
            contadorEncuestados++;            
        }

        public double CalcularPromedioPorTipo(int tipoTransporte)
        {
            double promedio = 0;

            int contador=0;
            double acumulador=0;
            for(int n=0; n<contadorEncuestados; n++)
            {
                if (tiposTransportes[n] == tipoTransporte)
                {
                    acumulador += distancias[n];
                    contador++;                    
                }
            }
            if(contador>0) promedio = acumulador / contador;    
            return promedio;
        }
    }
}
