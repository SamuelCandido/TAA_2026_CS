namespace Problema01.TiposDeEntrega
{
    internal class Sedex : ITipoDeEntrega
    {
        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0) 
                throw new ArgumentOutOfRangeException(nameof(pesoTotalKg), "O peso deve ser maior que zero.");
                
            if (pesoTotalKg <= 0.5) return 12.50;
            if (pesoTotalKg <= 1.0) return 20.00;

            double pesoAdicionalGramas = (pesoTotalKg - 1.0) * 1000;
            double blocosAdicionais = Math.Ceiling(pesoAdicionalGramas / 100);
            
            return 46.50 + (blocosAdicionais * 1.50);
        }
    }
}