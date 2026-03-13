namespace Problema01.TiposDeEntrega
{
    internal class IEncomendaPAC : ITipoDeEntrega
    {
        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0 || pesoTotalKg > 2.0) 
                throw new ArgumentOutOfRangeException(nameof(pesoTotalKg), "PAC aceita apenas pedidos maiores que zero e até 2kg.");

            if (pesoTotalKg <= 1.0) return 10.00;
            
            return 15.00;
        }

    }
}