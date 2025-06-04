
namespace Ejercicio4.Models
{
    internal class Servicio
    {
        public double Caja;

        public void RegistrarAcceso(bool esTicketValido, int tipoVehiculo, int cantidadTipo, int numerosDias)
        {
            if (esTicketValido == false)
            { 
                double valorBase = DeterminarValorVehiculo(tipoVehiculo);
                double valorBaseTotal = cantidadTipo * valorBase;
                double valorDiasTotal = valorBaseTotal * DeterminarPorcentaje(numerosDias);
                double valorIva = valorDiasTotal * 21 / 100;
                double subTotalConIva = valorDiasTotal + valorIva;
                double eco = subTotalConIva * 15 / 100;
                double monto = subTotalConIva + eco;

                Caja += monto;
            }
        }

        double DeterminarValorVehiculo(int tipo)
        {
            double valor = 0;
            switch (tipo)
            {
                case 1: valor = 100; break;
                case 2: valor = 800; break;
                case 3: valor = 1000; break;
                case 4: valor = 1500; break;
                case 5: valor = 5000; break;
                case 6: valor = 1200; break;
            }
            return valor;
        }

        double DeterminarPorcentaje(int dias)
        {
            if (dias == 1)
                return 100;
            else if (dias == 2)
                return 120;
            else if (dias == 3)
                return 220;
            else if (dias == 4)
                return 380;
            else if (dias >= 5 && dias <= 10)
                return 380;
            return 0;
        }
    }
}
