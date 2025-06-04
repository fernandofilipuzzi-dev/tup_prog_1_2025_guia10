
namespace Ejercicio5.Models
{
    internal class Servicio
    {
        int[] CantidadesPorRubro=new int[5];
        public double[] MontosPorRubro=new double[5];
        
        public int NumeroTransaccionMayor;
        public double MontoTransaccionMayor;

        int contadorDeTransacciones;

        public Servicio()
        {
            for (int n = 0; n < 5; n++)
            {
                CantidadesPorRubro[n] = 0;
                MontosPorRubro[n] = 0;
            }
        }

        public void EvaluarTransaccionPuntoDeVenta(int nroTransaccion, int rubro, int cantidad, double monto)
        {
            CantidadesPorRubro[rubro - 1] += cantidad;
            MontosPorRubro[rubro - 1] += monto;
            
            if (contadorDeTransacciones == 0 || monto > MontoTransaccionMayor)
            {
                NumeroTransaccionMayor = nroTransaccion;
                MontoTransaccionMayor = monto;
            }
            contadorDeTransacciones++;
        }
        public double[] CalcularPorcentajesCantidadVentasPorRubro()
        {
            double[] porcentajes = new double[5];
            for(int n=0; n<5; n++)
            {
                double porcentaje = 0;
                if (CantidadesPorRubro[n] > 0)
                {
                    porcentajes[n] = (CantidadesPorRubro[n] * 100) / contadorDeTransacciones;    
                }
                porcentajes[n] = porcentaje;
            }
            return porcentajes;
        }
        
        public double CalcularRecaudacionTotal()
        {
            double total = 0;
            for (int n = 0; n < 5; n++)
            {
                total += MontosPorRubro[n];
            }
            return total;
        }
    }
}
