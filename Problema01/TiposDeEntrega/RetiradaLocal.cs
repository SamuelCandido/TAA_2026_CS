namespace Problema01.TiposDeEntrega
{
    internal class RetiradaLocal : ITipoDeEntrega
    {
        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0) 
                throw new ArgumentOutOfRangeException(nameof(pesoTotalKg), "O peso deve ser maior que zero.");
                
            return 0.00;
        }
    }
}