namespace Problema01.TiposDeEntrega
{
    internal class Sedex : ITipoDeEntrega
    {
        private const double PesoLimiteMinimoKg = 0.5;
        private const double PesoLimiteLeveKg = 1.0;
        private const double ValorPesoMinimo = 12.50;
        private const double ValorPesoLeve = 20.00;
        private const double ValorBase = 46.50;
        private const double ValorPorBlocoAdicional = 1.50;
        private const double GramasPorBloco = 100.0;
        private const double ConversaoKgParaGramas = 1000.0;

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            ValidadorDePeso.Validar(pesoTotalKg);

            if (pesoTotalKg <= PesoLimiteMinimoKg) return ValorPesoMinimo;
            if (pesoTotalKg <= PesoLimiteLeveKg) return ValorPesoLeve;

            double pesoAdicionalGramas = Math.Round((pesoTotalKg - PesoLimiteLeveKg) * ConversaoKgParaGramas, 2);
            double blocosAdicionais = Math.Ceiling(pesoAdicionalGramas / GramasPorBloco);

            return ValorBase + (blocosAdicionais * ValorPorBlocoAdicional);
        }
    }
}